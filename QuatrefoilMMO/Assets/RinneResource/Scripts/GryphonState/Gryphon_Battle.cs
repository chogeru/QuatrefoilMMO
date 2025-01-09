using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RinneResourceStateMachineAI
{
    public class Gryphon_Battle : State<EnemyAI>
    {
        public Gryphon_Battle(EnemyAI owner) : base(owner) {}

        private Parameters m_parameters;
        private Animator m_animator;
        public override void Enter()
        {
            Debug.Log("Gryphon_Battle起動");
            //パラメーターコンポーネント取得
            m_parameters = owner.GetParameters();
            //アニメーターコンポーネント取得
            m_animator = owner.GetAnimator();
            //体力が半分以下で行動が変化
            if(m_parameters.m_status.HP < m_parameters.m_status.HP / 2)
            {
                //空中に移動
                //m_animator.SetTrigger("Fly");
            }
            
        }

        public override void Stay()
        {
            
        }

        public override void Exit()
        {
            
        }

        
    }
}

