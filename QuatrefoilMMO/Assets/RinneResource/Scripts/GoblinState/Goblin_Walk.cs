using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AbubuResouse.Log;

/// <summary>
/// ゴブリンの移動状態クラス
/// </summary>

namespace RinneResourceStateMachineAI
{
    public class Goblin_Walk : State<EnemyAI>
    {
        private Vector3 target_point;
        private Animator m_animator;
        private NavMeshAgent m_navmeshagent;
        private Parameters m_parameters;
        //コンストラクタ
        public Goblin_Walk(EnemyAI owner) : base(owner) {}
        //このAIが起動した瞬間に実行(Startと同義)
        public override void Enter()
        {
            DebugUtility.Log("Goblin_Walkを起動しました");
            //アニメーションコンポーネント取得
            m_animator = owner.GetAnimator();
            //ナビメッシュコンポーネント取得
            m_navmeshagent = owner.GetNavMeshAgent();
            //パラメータコンポーネント取得
            m_parameters = owner.GetParameters();
            //歩きアニメーション起動
            m_animator.SetBool("IsWalk_Enemy", true);
            //ナビゲーション開始
            m_navmeshagent.isStopped = false;
            //移動スピードを歩きスピードに変化
            m_navmeshagent.speed = m_parameters.m_status.AGI;
            //目標移動地点
            target_point = new Vector3(Random.Range(-49.0f, 49.0f), owner.transform.position.y, Random.Range(-49.0f, 49.0f));
        }

        //このAIが起動中に常に実行(Updateと同義)
        public override void Stay()
        {
            Debug.Log(target_point);
            //プレイヤー発見
            if (m_parameters.m_status.IsFlag)
            {
                //臨戦態勢に移行
                owner.ChangeState(AIState.Battle_Mode);
            }
            //owner.transform.position += new Vector3(0.0f, 0.0f, 0.01f);

            target_point.y = owner.transform.position.y;
            //X座標、Z座標の0～5までの中をランダムに移動
            m_navmeshagent.SetDestination(target_point);
            
            if(owner.transform.localPosition == target_point)
            {
                owner.ChangeState(AIState.Idle_Mode);
            }
        }

        //このAIが終了した瞬間に実行
        public override void Exit()
        {
            //移動アニメーション解除
            m_animator.SetBool("IsWalk_Enemy", false);
            //ナビゲーション終了
            m_navmeshagent.isStopped = true;
            DebugUtility.Log("Goblin_Walkを終了しました");
        }
    }
}

