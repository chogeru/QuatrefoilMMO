using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachineAI
{
    public class Goblin_Walk : State<EnemyAI>
    {
        float time;     //経過時間

        //コンストラクタ
        public Goblin_Walk(EnemyAI owner) : base(owner) {}
        //このAIが起動した瞬間に実行(Startと同義)
        public override void Enter()
        {
            Debug.Log("Goblin_Walkを起動しました");
            time = 0.0f;
        }

        //このAIが起動中に常に実行(Updateと同義)
        public override void Stay()
        {
            time += Time.deltaTime;
            owner.transform.position += new Vector3(0.0f, 0.0f, 0.01f);
            if(time >= 5.0f)
            {
                owner.ChangeState(AIState.Idle_Mode);
            }
        }

        //このAIが終了した瞬間に実行
        public override void Exit()
        {
            Debug.Log("Goblin_Walkを終了しました");
        }
    }
}

