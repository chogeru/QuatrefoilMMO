using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AbubuResouse.Log;

/// <summary>
/// ゴーレムの追尾状態クラス
/// </summary>

namespace RinneResourceStateMachineAI
{
    public class Golem_Chase : State<EnemyAI>
    {
        private Animator m_animator;
        private NavMeshAgent m_navmeshagent;
        private Parameters m_parameters;
        private Enemyeye m_enemyeye;
        //コンストラクタ
        public Golem_Chase(EnemyAI owner) : base(owner) { }
        public override void Enter()
        {
            DebugUtility.Log("Golem_Chaseを起動しました");
            //アニメーションコンポーネント取得
            m_animator = owner.GetAnimator();
            //ナビメッシュコンポーネント取得
            m_navmeshagent = owner.GetNavMeshAgent();
            //パラメータコンポーネント取得
            m_parameters = owner.GetParameters();
            //視野判定コンポーネント取得
            m_enemyeye = owner.GetEnemyeye();
            //ナビゲーション開始
            m_navmeshagent.isStopped = false;
            //チェイスアニメーション起動
            m_animator.SetBool("IsChase", true);
        }

        public override void Stay()
        {
            //ターゲットとの距離
            float targetLength = m_enemyeye.m_posdelta.magnitude;

            //ターゲットを追いかける
            m_navmeshagent.SetDestination(owner.m_targetplayer.transform.position);

            //攻撃の間合いに入ったら
            if (targetLength < 3f)
            {
                //攻撃ステートに切り替え
                owner.ChangeState(AIState.Attack_Mode);
            }

            //あまりに距離が離れたら戦わない
            if (targetLength > 20)
            {
                //通常状態へ変更
                owner.ChangeState(AIState.Idle_Mode);
                //未発見状態に変更
                m_parameters.m_status.IsFlag = false;
            }

            //死亡を検知したなら
            if (m_parameters.GetDown())
            {
                owner.ChangeState(AIState.Battle_Mode);
            }
        }

        public override void Exit()
        {
            DebugUtility.Log("Golem_Chaseを終了しました");
            //ナビゲーション終了
            m_navmeshagent.isStopped = true;
            //チェイスアニメーション終了
            m_animator.SetBool("IsChase", false);
            //検知フラグオフ
            m_parameters.m_status.IsFlag = false;
        }
    }
}
