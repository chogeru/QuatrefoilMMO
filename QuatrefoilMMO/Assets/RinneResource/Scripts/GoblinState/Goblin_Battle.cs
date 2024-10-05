using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RinneResourceStateMachineAI
{
    public class Goblin_Battle : State<EnemyAI>
    {
        private float m_elapsedtime;    //経過時間
        private float m_actiontime;     //行動変化の時間
        private float m_cooltime;       //ステートの切り替え時間
        private int n;

        //コンストラクタ
        public Goblin_Battle(EnemyAI owner) : base(owner) {}

        public override void Enter()
        {
            Debug.Log("Goblin_Battleを起動しました");
            //戦闘態勢アニメーション起動
            owner.m_animator.SetBool("IsBattleMode_Enemy", true);
            //4から12秒はこのステートで待機
            m_cooltime = Random.Range(4, 12);
            //初回発見時は様子見
            n = Random.Range(1, 5);
        }

        public override void Stay()
        {
            //プレイヤーの方向を見る
            owner.transform.LookAt(owner.m_targetplayer.transform.position);
            //ターゲットとの距離
            float targetLength = owner.m_eye.m_posdelta.magnitude;
            
            //2秒経過ごとに
            if(m_actiontime > 2f)
            {
                //アニメーションのリセット
                owner.m_animator.SetBool("IsBattleBack", false);
                owner.m_animator.SetBool("IsBattleForward", false);
                owner.m_animator.SetBool("IsBattleLeft", false);
                owner.m_animator.SetBool("IsBattleRight", false);
                //行動を切り替え
                n = Random.Range(1, 5);
                m_actiontime -= 2f;
            }
            
            //距離を詰めたり離したり等で様子を見る
            if (n == 1)
            {
                //後ろに下がる
                owner.m_animator.SetBool("IsBattleBack", true);
                //移動処理
                owner.transform.position -= owner.m_enemyparameters.m_parameters.AGI / 2 * owner.transform.forward * Time.deltaTime;
            }
            else if(n == 2)
            {
                //プレイヤーに近づく
                owner.m_animator.SetBool("IsBattleForward", true);
                //移動処理
                owner.transform.position += owner.m_enemyparameters.m_parameters.AGI / 2 * owner.transform.forward * Time.deltaTime;
            }
            else if(n == 3)
            {
                //プレイヤーとの距離を保ちつつ左に移動
                owner.m_animator.SetBool("IsBattleLeft", true);
                //移動処理
                owner.transform.position -= owner.m_enemyparameters.m_parameters.AGI / 2 * owner.transform.right * Time.deltaTime;
            }
            else if(n == 4)
            {
                //プレイヤーとの距離を保ちつつ右に移動
                owner.m_animator.SetBool("IsBattleRight", true);
                //移動処理
                owner.transform.position += owner.m_enemyparameters.m_parameters.AGI / 2 * owner.transform.right * Time.deltaTime;
            }

            //距離に応じた行動をする
            if(m_elapsedtime > m_cooltime)
            {
                //プレイヤーとの距離に応じた行動を取る
                if (targetLength < 2)
                {
                    //攻撃範囲内なら
                    //攻撃
                    Debug.Log("攻撃します");
                    owner.ChangeState(AIState.Attack_Mode);
                }
                else
                {
                    //プレイヤーが遠い時
                    //攻撃範囲内まで追いかける
                    Debug.Log("追いかけます");
                    owner.ChangeState(AIState.Chase_Mode);
                }
            }

            //経過時間処理
            m_elapsedtime += Time.deltaTime;
            m_actiontime += Time.deltaTime;
        }

        public override void Exit()
        {
            owner.m_animator.SetBool("IsBattleBack", false);
            owner.m_animator.SetBool("IsBattleForward", false);
            owner.m_animator.SetBool("IsBattleLeft", false);
            owner.m_animator.SetBool("IsBattleRight", false);
            m_elapsedtime = 0.0f;
            Debug.Log("Goblin_Battleを終了しました");
        }
    }
}

