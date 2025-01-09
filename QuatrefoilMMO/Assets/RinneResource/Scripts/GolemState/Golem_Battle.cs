using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbubuResouse.Log;

/// <summary>
/// ゴーレムの戦闘状態クラス
/// </summary>

namespace RinneResourceStateMachineAI
{
    public class Golem_Battle : State<EnemyAI>
    {
        private Animator m_animator;
        private Parameters m_parameters;
        private Enemyeye m_enemyeye;

        private float m_elapsedtime;    //経過時間
        private float m_actiontime;     //行動変化の時間
        private float m_cooltime;       //ステートの切り替え時間
        //コンストラクタ
        public Golem_Battle(EnemyAI owner) : base(owner) { }

        public override void Enter()
        {
            DebugUtility.Log("Golem_Battleを起動しました");
            //アニメーションコンポーネント取得
            m_animator = owner.GetAnimator();
            //パラメータコンポーネント取得
            m_parameters = owner.GetParameters();
            //視野判定コンポーネント取得
            m_enemyeye = owner.GetEnemyeye();
            //戦闘態勢アニメーション起動
            m_animator.SetTrigger("IsLook");
            //2から3秒はこのステートで待機
            m_cooltime = Random.Range(2, 3);
        }

        public override void Stay()
        {
            //nullチェック
            if (owner.m_targetplayer != null)
            {
                //プレイヤーの方向を見る
                owner.transform.LookAt(owner.m_targetplayer.transform.position);
            }
            //Y軸以外は動かしたくないので0で固定
            Vector3 eulerAngles = owner.transform.eulerAngles;
            eulerAngles.x = 0;
            eulerAngles.z = 0;
            owner.transform.eulerAngles = eulerAngles;
            //ターゲットとの距離
            float targetLength = m_enemyeye.m_posdelta.magnitude;

            //距離に応じた行動をする
            if (m_elapsedtime > m_cooltime)
            {
                //プレイヤーとの距離に応じた行動を取る
                if (targetLength < 3f)
                {
                    //攻撃範囲内なら
                    //攻撃
                    DebugUtility.Log("攻撃します");
                    owner.ChangeState(AIState.Attack_Mode);
                }
                else
                {
                    //プレイヤーが遠い時
                    //攻撃範囲内まで追いかける
                    DebugUtility.Log("追いかけます");
                    owner.ChangeState(AIState.Chase_Mode);
                }
            }

            //あまりに距離が離れたら戦わない
            if (targetLength > 20 || owner.m_targetplayer == null)
            {
                //通常状態へ変更
                owner.ChangeState(AIState.Idle_Mode);
                //未発見状態に変更
                m_parameters.m_status.IsFlag = false;
            }

            //経過時間処理
            m_elapsedtime += Time.deltaTime;
            m_actiontime += Time.deltaTime;

            //死亡を検知したなら
            if (m_parameters.GetDown())
            {
                owner.ChangeState(AIState.Down_Mode);
            }
        }

        public override void Exit()
        {
            m_elapsedtime = 0.0f;
            //検知フラグオフ
            m_parameters.m_status.IsFlag = false;
            DebugUtility.Log("Golem_Battleを終了しました");
        }
    }
}
