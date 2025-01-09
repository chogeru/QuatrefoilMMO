using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbubuResouse.Log;

/// <summary>
/// グリフォンの死亡状態クラス
/// </summary>

namespace RinneResourceStateMachineAI
{
    public class Gryphon_Down : State<EnemyAI>
    {
        private Animator m_animator;
        //コンストラクタ
        public Gryphon_Down(EnemyAI owner) : base(owner) { }

        public override void Enter()
        {
            DebugUtility.Log("Gryphon_Downを起動しました");
            m_animator = owner.GetAnimator();
            m_animator.SetTrigger("IsDown");
        }

        public override void Stay()
        {

        }

        public override void Exit()
        {
            DebugUtility.Log("Gryphon_Downを終了しました");
        }
    }
}

