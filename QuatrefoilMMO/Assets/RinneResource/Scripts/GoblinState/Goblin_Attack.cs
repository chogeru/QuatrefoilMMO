using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RinneResourceStateMachineAI
{
    public class Goblin_Attack : State<EnemyAI>
    {
        private float m_elapsedtime;
        private float m_cooltime;
        public Goblin_Attack(EnemyAI owner) : base(owner) {}

        public override void Enter()
        {
            Debug.Log("Goblin_Attackを起動しました");
            m_cooltime = 2;
        }

        public override void Stay()
        {
            //攻撃

            //攻撃後の後隙

            //ステートの切り替え
            if(m_cooltime < m_elapsedtime)
            {
                owner.ChangeState(AIState.Battle_Mode);
            }
            

            m_elapsedtime += Time.deltaTime;
        }

        public override void Exit()
        {
            Debug.Log("Goblin_Attackを終了しました");
        }
    }
}

