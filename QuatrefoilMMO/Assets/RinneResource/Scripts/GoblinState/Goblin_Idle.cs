using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbubuResouse.Log;

/// <summary>
///ゴブリンの通常状態クラス 
/// </summary>

namespace RinneResourceStateMachineAI
{
    public class Goblin_Idle : State<EnemyAI>
    {
        private Animator m_animator;
        private Parameters m_parameters;

        float m_elapsedtime;        //経過時間
        float m_cooltime;           //クールタイム

        //コンストラクタ
        public Goblin_Idle(EnemyAI owner) : base(owner) {}
        //このAIが起動した瞬間に実行(Startと同義)
        public override void Enter()
        {
            DebugUtility.Log("Goblin_Idleを起動しました");
            //アニメーションコンポーネント取得
            m_animator = owner.GetAnimator();
            //パラメータコンポーネント取得
            m_parameters = owner.GetParameters();
            //バトルアニメーション解除
            m_animator.SetBool("IsBattleMode_Enemy", false);

            m_elapsedtime = 0.0f;
            //1から5秒をランダム
            m_cooltime = Random.Range(1.0f, 5.0f);
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
            //クールタイム経過
            if (m_elapsedtime > m_cooltime)
            {
                //移動モードに変更
                owner.ChangeState(AIState.Walk_Mode);
            }
            //経過時間処理
            m_elapsedtime += Time.deltaTime;
        }

        //このAIが終了した瞬間に実行
        public override void Exit()
        {
            DebugUtility.Log("Goblin_Idleを終了しました");
        }
    }
}

