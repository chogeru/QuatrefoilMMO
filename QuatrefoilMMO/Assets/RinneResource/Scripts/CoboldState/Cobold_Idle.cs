using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbubuResouse.Log;

/// <summary>
/// コボルドの通常状態クラス
/// </summary>

namespace RinneResourceStateMachineAI
{
    public class Cobold_Idle : State<EnemyAI>
    {
        private Animator m_animator;
        private Parameters m_parameters;

        //コンストラクタ
        public Cobold_Idle(EnemyAI owner) : base(owner) { }

        //このAIが起動した瞬間に実行(Startと同義)
        public override void Enter()
        {
            DebugUtility.Log("Cobold_Idleを起動しました");
            //アニメーションコンポーネント取得
            m_animator = owner.GetAnimator();
            //パラメータコンポーネント取得
            m_parameters = owner.GetParameters();
            //バトルアニメーション解除
            m_animator.SetBool("IsBattleMode_Enemy", false);
        }

        //このAIが起動中に常に実行(Updateと同義)
        public override void Stay()
        {
            //プレイヤー発見
            if (m_parameters.m_status.IsFlag)
            {
                //バトルモードに変更
                owner.ChangeState(AIState.Battle_Mode);
            }

            //死亡を検知したなら
            if (m_parameters.GetDown())
            {
                owner.ChangeState(AIState.Down_Mode);
            }
        }

        //このAIが終了した瞬間に実行
        public override void Exit()
        {
            DebugUtility.Log("Cobold_Idleを終了しました");
        }
    }
}

