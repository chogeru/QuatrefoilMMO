using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineAI
{
    public class Goblin_Idle : State<EnemyAI>
    {
        float time;     //経過時間

        //コンストラクタ
        public Goblin_Idle(EnemyAI owner) : base(owner) {}
        //このAIが起動した瞬間に実行(Startと同義)
        public override void Enter()
        {
            Debug.Log("Goblin_Idleを起動しました");

            time = 0.0f;
        }

        //このAIが起動中に常に実行(Updateと同義)
        public override void Stay()
        {
            time += Time.deltaTime;

            //３秒経過
            if (time > 3.0f)
            {
                //移動モードに変更
                owner.ChangeState(AIState.Walk_Mode);
            }

        }

        //このAIが終了した瞬間に実行
        public override void Exit()
        {
            Debug.Log("Goblin_Idleを終了しました");
        }
    }
}

