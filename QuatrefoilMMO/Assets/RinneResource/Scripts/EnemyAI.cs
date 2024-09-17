using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StateMachineAI
{
    public enum AIState
    {
        Idle_Mode,
        Walk_Mode,
        Chase_Mode,
        Attack_Mode
    }
    public class EnemyAI 
        : StatefulObjectBase<EnemyAI,AIState>
    {
        private void Start()
        {
            //ステートリストに各ステート追加
            stateList.Add(new Goblin_Idle(this));
            stateList.Add(new Goblin_Walk(this));

            //ステートマシーンを自身として設定
            stateMachine = new StateMachine<EnemyAI>();

            //初期起動時は、Idleに移行させる
            ChangeState(AIState.Idle_Mode);
        }
    }
}