using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbubuResouse.Log;

namespace RinneResourceStateMachineAI
{
    public class HobGoblin_Down : State<EnemyAI>
    {
        //アニメーターコンポーネント
        private Animator m_animator;
        //コンストラクタ
        public HobGoblin_Down(EnemyAI owner) : base(owner) { }

        public override void Enter()
        {
            DebugUtility.Log("HobGoblin_Downを起動しました");
            //コンポーネント取得
            m_animator = owner.GetAnimator();
            m_animator.SetTrigger("IsDown");
        }

        public override void Stay()
        {

        }

        public override void Exit()
        {
            DebugUtility.Log("HobGoblin_Downを終了しました");
        }
    }
}

