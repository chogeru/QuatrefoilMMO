using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RinneResourceStateMachineAI
{
    public class Enemyeye : MonoBehaviour
    {
        private EnemyAI m_enemyai;                      //エネミーAI
        private Parameters m_parameters;                //パラメーター
        private SphereCollider m_spherecollider;        //探知距離用スフィアコライダー
        public GameObject m_player;                     //プレイヤー
        public Vector3 m_posdelta;                      //プレイヤーとの距離ベクトル

        void Start()
        {
            //コンポーネント取得
            m_enemyai = GetComponentInParent<EnemyAI>();
            m_parameters = GetComponentInParent<Parameters>();
            m_spherecollider = GetComponent<SphereCollider>();
            //視野距離の設定
            m_spherecollider.radius = m_parameters.m_status.MaxDistance;
        }


        void Update()
        {
            //一度発見したプレイヤーとの距離を図り続ける
            if(m_player != null) m_posdelta = m_player.transform.position - transform.position;
            //高さは考慮しない
            m_posdelta.y = 0;

        }

        //接触している間
        private void OnTriggerStay(Collider other)
        {
            //接触したオブジェクトがパラメータをもっている時
            if (other.GetComponent<Parameters>())
            {
                Parameters parameters = other.GetComponent<Parameters>();
                //接触したパラメーターのタイプがプレイヤーの時
                if (parameters.GetParameterType() == "Player")
                {
                    //検知したプレイヤーをターゲットにする
                    if (m_enemyai.m_targetplayer == null) m_enemyai.m_targetplayer = other.gameObject;
                    m_player = other.gameObject;

                    float targetAngle = Vector3.Angle(transform.forward, m_posdelta);
                    //視野のレイを表示
                    Debug.DrawRay(transform.position, m_posdelta, Color.blue);
                    //ターゲットが視野範囲に入っている時
                    if (targetAngle < m_parameters.m_status.MaxAngle)
                    {
                        //レイキャストで判定
                        if (Physics.Raycast(transform.position, m_posdelta, out RaycastHit hit))
                        {
                            //レイに当たっているのがプレイヤー
                            if (hit.collider == other)
                            {
                                Debug.Log("プレイヤー発見");
                                m_parameters.m_status.IsFlag = true;
                                return;
                            }
                            //それ以外
                            //else
                            //{
                            //    Debug.Log("プレイヤー未発見");
                            //    ep.m_parameters.IsFlag = false;
                            //    return;
                            //}
                        }
                    }
                }
            }

        }

    }
}

