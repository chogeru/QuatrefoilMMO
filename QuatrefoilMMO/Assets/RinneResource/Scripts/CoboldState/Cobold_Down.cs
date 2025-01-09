using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbubuResouse.Log;

/// <summary>
/// コボルドの死亡状態クラス
/// </summary>

namespace RinneResourceStateMachineAI
{
    public class Cobold_Down : State<EnemyAI>
    {
        private Animator m_animator;
        //コンストラクタ
        public Cobold_Down(EnemyAI owner) : base(owner) { }

        public override void Enter()
        {
            DebugUtility.Log("Cobold_Downを起動しました");
            m_animator = owner.GetAnimator();
            m_animator.SetTrigger("IsDown");
        }

        public override void Stay()
        {

        }

        public override void Exit()
        {
            DebugUtility.Log("Cobold_Downを終了しました");
        }
    }
}

