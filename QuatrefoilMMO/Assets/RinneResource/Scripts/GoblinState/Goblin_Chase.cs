using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RinneResourceStateMachineAI
{
    public class Goblin_Chase : State<EnemyAI>
    {
        public Goblin_Chase(EnemyAI owner) : base(owner) {}

        public override void Enter()
        {
            Debug.Log("Goblin_Chaseを起動しました");
            //移動スピード
            owner.m_agent.speed *= 1.5f;
            //ナビゲーション開始
            owner.m_agent.isStopped = false;
            //チェイスアニメーション起動
            owner.m_animator.SetBool("IsRun_Enemy", true);
        }

        public override void Stay()
        {
            //ターゲットとの距離
            float targetLength = owner.m_eye.m_posdelta.magnitude;

            //ターゲットを追いかける
            owner.m_agent.SetDestination(owner.m_targetplayer.transform.position);
            
            //攻撃の間合いに入ったら
            if(targetLength < 4.0f)
            {
                //攻撃ステートに切り替え
                owner.ChangeState(AIState.Attack_Mode);
            }
        }

        public override void Exit()
        {
            Debug.Log("Goblin_Chaseを終了しました");
            //ナビゲーション終了
            owner.m_agent.isStopped = true;
            //チェイスアニメーション終了
            owner.m_animator.SetBool("IsRun_Enemy", false);
        }
    }
}

