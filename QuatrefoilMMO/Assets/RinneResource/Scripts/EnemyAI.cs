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
using RinneResource;

/// <summary>
/// モンスターAI
/// </summary>

namespace RinneResourceStateMachineAI
{
    public enum AIState
    {
        Idle_Mode,
        Battle_Mode,
        Chase_Mode,
        Attack_Mode,
        Down_Mode,
    }

    public class EnemyAI
        : StatefulObjectBase<EnemyAI, AIState>
    {
        //アニメーションコンポーネント
        private Animator m_animator;
        //ナビメッシュコンポーネント
        private NavMeshAgent m_agent;
        //リジッドボディーコンポーネント
        private Rigidbody m_rb;
        //敵のパラメーター
        private Parameters m_parameters;
        //小型敵のスポーン
        private EnemySpawn m_enemyspawn;
        //ボスのスポーン
        private BossBattleMovie m_bossbattlemovie;
        //視野判定処理
        private Enemyeye m_eye;
        //ターゲットプレイヤー
        public GameObject m_targetplayer;
        //UI
        public GameObject m_ui;
        private Game m_game;
        
        [SerializeField,Header("攻撃用当たり判定")]
        private GameObject m_attackbox;

        private void Start()
        {
            //アニメーションコンポーネント取得
            m_animator = GetComponent<Animator>();
            //ナビメッシュコンポーネント取得
            m_agent = GetComponent<NavMeshAgent>();
            //リジッドボディーコンポーネント取得
            m_rb = GetComponent<Rigidbody>();
            //パラメータコンポーネント取得
            m_parameters = GetComponent<Parameters>();
            //敵ポップコンポーネント取得
            m_enemyspawn = GetComponentInParent<EnemySpawn>();
            //視野判定処理コンポーネント取得
            m_eye = GetComponentInChildren<Enemyeye>();
            //オブジェクトの首を取得
            //m_neck = animator.GetBoneTransform(HumanBodyBones.Neck);

            m_game = GameObject.Find("GameManager").GetComponent<Game>();
            //初回起動時は攻撃用当たり判定をオフにする
            m_attackbox.SetActive(false);
            //発見時のUIをオフにする
            if(m_ui != null) m_ui.SetActive(false);
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
            if(m_enemyspawn != null)m_enemyspawn.DownSpawncnt();
            if (m_bossbattlemovie != null) m_bossbattlemovie.CountDown();

            m_game.Addcnt();
            //ランダムでアイテムをドロップさせる
        }

        //アイテムドロップ
        private void LostItem()
        {
            
        }

        //攻撃用当たり判定を取得
        public GameObject GetAttackBox()
        {
            return m_attackbox;
        }

        //アニメーションコンポーネント取得
        public Animator GetAnimator()
        {
            return m_animator;
        }

        //ナビメッシュコンポーネント取得
        public NavMeshAgent GetNavMeshAgent()
        {
            return m_agent;
        }

        //リジッドボディーコンポーネント取得
        public Rigidbody GetRigidbody()
        {
            return m_rb;
        }

        //パラメーターコンポーネント取得
        public Parameters GetParameters()
        {
            return m_parameters;
        }

        //スポーンポイントコンポーネント取得
        public EnemySpawn GetEnemySpawn()
        {
            return m_enemyspawn;
        }

        //視野判定コンポーネント取得
        public Enemyeye GetEnemyeye()
        {
            return m_eye;
        }

        void Kill()
        {
            Destroy(this.gameObject);
        }

        void OnHitBox()
        {
            m_attackbox.SetActive(true);
        }

        void OffHitBox()
        {
            m_attackbox.SetActive(false);
        }
    }
}
