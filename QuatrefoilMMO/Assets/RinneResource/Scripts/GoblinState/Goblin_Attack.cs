using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbubuResouse.Log;

/// <summary>
/// ゴブリンの攻撃状態クラス
/// </summary>

namespace RinneResourceStateMachineAI
{
    public class Goblin_Attack : State<EnemyAI>
    {
        private float m_elapsedtime;
        private float m_cooltime;

        public Goblin_Attack(EnemyAI owner) : base(owner) {}

        public override void Enter()
        {
            DebugUtility.Log("Goblin_Attackを起動しました");
            Attack1();
            m_cooltime = 2;
        }

        public override void Stay()
        {
            //攻撃の後隙時間
            //ステートの切り替え
            if (m_cooltime < m_elapsedtime)
            {
                owner.ChangeState(AIState.Battle_Mode);
            }

            m_elapsedtime += Time.deltaTime;
        }

        public override void Exit()
        {
            m_elapsedtime -= m_cooltime;
            //当たり判定削除
            owner.m_hitbox.SetActive(false);
            DebugUtility.Log("Goblin_Attackを終了しました");
        }

        //攻撃１
        private void Attack1()
        {
            owner.m_animator.SetTrigger("IsAttack1_Enemy");
            //当たり判定出現
            owner.m_hitbox.SetActive(true);
        }
    }
}

