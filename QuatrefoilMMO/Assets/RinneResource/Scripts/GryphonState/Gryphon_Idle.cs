using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// グリフォンの通常状態クラス
/// </summary>

namespace RinneResourceStateMachineAI
{
    public class Gryphon_Idle : State<EnemyAI>
    {
        public Gryphon_Idle(EnemyAI owner) : base(owner) {}

        public override void Enter()
        {
            Debug.Log("Gryphon_Idle起動");
        }

        public override void Stay()
        {
            
        }

        public override void Exit()
        {
            Debug.Log("Gryphon_Idle停止");
        }
    }
}

