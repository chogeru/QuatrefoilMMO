using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbubuResouse.Log;

/// <summary>
/// グリフォンの通常状態クラス
/// </summary>

namespace RinneResourceStateMachineAI
{
    public class Gryphon_Idle : State<EnemyAI>
    {
        public Gryphon_Idle(EnemyAI owner) : base(owner) {}

        private Parameters m_parameters;
        public override void Enter()
        {
            DebugUtility.Log("Gryphon_Idle起動");
            //パラメーターコンポーネント取得
            m_parameters = owner.GetParameters();
        }

        public override void Stay()
        {
            //探索フラグがオンなら
            if(m_parameters.m_status.IsFlag)
            {
                //バトルモードに移行
                owner.ChangeState(AIState.Battle_Mode);
            }
        }

        public override void Exit()
        {
            Debug.Log("Gryphon_Idle停止");
        }
    }
}

