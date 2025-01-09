using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbubuResouse.Log;

/// <summary>
/// ゴブリンの死亡状態クラス
/// </summary>

namespace RinneResourceStateMachineAI
{
    public class Goblin_Down : State<EnemyAI>
    {
        private Animator m_animator;
        //コンストラクタ
        public Goblin_Down(EnemyAI owner) : base(owner) {}
        
        public override void Enter()
        {
            DebugUtility.Log("Goblin_Downを起動しました");
            m_animator = owner.GetAnimator();
            m_animator.SetTrigger("IsDown");
        }

        public override void Stay()
        {
            
        }

        public override void Exit()
        {
            DebugUtility.Log("Goblin_Downを終了しました");
        }

    }
}

