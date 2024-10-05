using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RinneResourceStateMachineAI
{
    public class Goblin_Walk : State<EnemyAI>
    {
        private Vector3 target_point;
        //コンストラクタ
        public Goblin_Walk(EnemyAI owner) : base(owner) {}
        //このAIが起動した瞬間に実行(Startと同義)
        public override void Enter()
        {
            Debug.Log("Goblin_Walkを起動しました");
            //歩きアニメーション起動
            owner.m_animator.SetBool("IsWalk_Enemy", true);
            //ナビゲーション開始
            owner.m_agent.isStopped = false;
            //移動スピードを歩きスピードに変化
            owner.m_agent.speed = owner.m_enemyparameters.m_parameters.AGI;
            //目標移動地点
            target_point = new Vector3(Random.Range(-49.0f, 49.0f), owner.transform.position.y, Random.Range(-49.0f, 49.0f));
        }

        //このAIが起動中に常に実行(Updateと同義)
        public override void Stay()
        {
            //プレイヤー発見
            if (owner.m_enemyparameters.m_parameters.IsFlag)
            {
                //臨戦態勢に移行
                owner.ChangeState(AIState.Battle_Mode);
            }
            //owner.transform.position += new Vector3(0.0f, 0.0f, 0.01f);
            
            //X座標、Z座標の0～5までの中をランダムに移動
            owner.m_agent.SetDestination(target_point);
            
            if(owner.transform.position == target_point)
            {
                owner.ChangeState(AIState.Idle_Mode);
            }
        }

        //このAIが終了した瞬間に実行
        public override void Exit()
        {
            //移動アニメーション解除
            owner.m_animator.SetBool("IsWalk_Enemy", false);
            //ナビゲーション終了
            owner.m_agent.isStopped = true;
            Debug.Log("Goblin_Walkを終了しました");
        }
    }
}

