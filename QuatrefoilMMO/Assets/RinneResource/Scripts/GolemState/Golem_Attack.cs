using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbubuResouse.Log;

/// <summary>
/// ゴーレムの攻撃状態クラス
/// </summary>

namespace RinneResourceStateMachineAI
{
    public class Golem_Attack : State<EnemyAI>
    {
        private float m_elapsedtime;
        private float m_cooltime;

        private Animator m_animator;
        private Parameters m_parameters;
        private GameObject m_attackbox;
        //コンストラクタ
        public Golem_Attack(EnemyAI owner) : base(owner) { }

        public override void Enter()
        {
            DebugUtility.Log("Golem_Attackを起動しました");
            //アニメーションコンポーネント取得
            m_animator = owner.GetAnimator();
            //パラメータコンポーネント取得
            m_parameters = owner.GetParameters();
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

            //死亡を検知したなら
            if (m_parameters.GetDown())
            {
                owner.ChangeState(AIState.Battle_Mode);
            }

            m_elapsedtime += Time.deltaTime;
        }

        public override void Exit()
        {
            m_elapsedtime -= m_cooltime;
            DebugUtility.Log("Golem_Attackを終了しました");
        }

        //攻撃１
        private void Attack1()
        {
            m_animator.SetTrigger("IsAttack");
        }
    }
}

