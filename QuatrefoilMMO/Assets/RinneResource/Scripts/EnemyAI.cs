using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;
using AbubuResouse.Log;

using System.Linq;
using System.Text;
using System.Reflection;

namespace RinneResourceStateMachineAI
{
    public enum AIState
    {
        Idle_Mode,
        Walk_Mode,
        Battle_Mode,
        Chase_Mode,
        Attack_Mode,
        Lost_Mode
    }

    public class EnemyAI
        : StatefulObjectBase<EnemyAI, AIState>
    {
        //アニメーションコンポーネント
        public Animator m_animator;
        //ナビメッシュコンポーネント
        public NavMeshAgent m_agent;
        //リジッドボディーコンポーネント
        public Rigidbody m_rb;
        //敵のパラメーター
        public EnemyParameters m_enemyparameters;
        //敵のスポーン
        public EnemySpawn m_enemyspawn;
        //視野判定処理
        public Enemyeye m_eye;
        //ターゲットプレイヤー
        public GameObject m_targetplayer;
        //UI
        public GameObject m_ui;
        //首
        public Transform m_neck;
        //当たり判定コリジョン
        public GameObject m_hitbox;

        private void Start()
        {
            //アニメーションコンポーネント取得
            m_animator = GetComponent<Animator>();
            //ナビメッシュコンポーネント取得
            m_agent = GetComponent<NavMeshAgent>();
            //リジッドボディーコンポーネント取得
            m_rb = GetComponent<Rigidbody>();
            //パラメータコンポーネント取得
            m_enemyparameters = GetComponent<EnemyParameters>();
            //敵ポップコンポーネント取得
            m_enemyspawn = GetComponentInParent<EnemySpawn>();
            //視野判定処理コンポーネント取得
            m_eye = GetComponentInChildren<Enemyeye>();
            //オブジェクトの首を取得
            //m_neck = animator.GetBoneTransform(HumanBodyBones.Neck);

            //初回起動時は攻撃用当たり判定をオフにする
            m_hitbox.SetActive(false);
            //発見時のUIをオフにする
            m_ui.SetActive(false);
            //ステートマシーンを自身として設定
            stateMachine = new StateMachine<EnemyAI>();

            //初期起動時は、Idleに移行させる
            ChangeState(AIState.Idle_Mode);
        }

        ///<summary>
        ///クラス名を元にステートを生成して追加する
        ///</summary>
        ///<param name="Classname">生成するクラスの名前</param>
        public bool AddStateByName(string ClassName)
        {
            try
            {
                // 現在のアセンブリからクラスを取得
                Type StateType = Assembly.GetExecutingAssembly().GetType($"RinneResourceStateMachineAI.{ClassName}");

                // クラスが見つからなかった場合の対処
                if (StateType == null)
                {
                    DebugUtility.LogError($"{ClassName} クラスが見つかりませんでした。");
                    return true;
                }

                // 型が State<AITester> かどうかをチェック
                if (!typeof(State<EnemyAI>).IsAssignableFrom(StateType))
                {
                    DebugUtility.LogError($"{ClassName} は State<EnemyAI> 型ではありません。\nだからよ…止まるんじゃ…ねぇぞ…。");
                    return true;
                }

                // インスタンスを生成
                System.Reflection.ConstructorInfo Constructor =
                    StateType.GetConstructor(new[] { typeof(EnemyAI) });


                if (Constructor == null)
                {
                    DebugUtility.LogError($"{ClassName} のコンストラクタが見つかりませんでした。\nああ――今夜はこんなにも、月が綺麗だ――。");
                    return true;
                }

                State<EnemyAI> StateInstance =
                    Constructor.Invoke(new object[] { this }) as State<EnemyAI>;

                if (StateInstance != null)
                {
                    // ステートリストに追加
                    stateList.Add(StateInstance);
                    DebugUtility.Log($"{ClassName} をステートリストに追加しました。");
                    return true;
                }
                else
                {
                    DebugUtility.LogError($"{ClassName} のインスタンス生成に失敗しました。みんな死ぬしかないじゃない!!");
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                DebugUtility.LogError($"エラーが発生しました。ありえんw: {ex.Message}");
                return false;
            }
        }

        //自分が削除された時
        private void OnDestroy()
        {
            //ポップした数を減らす
            m_enemyspawn.m_spawncnt--;
        }
    }
}
