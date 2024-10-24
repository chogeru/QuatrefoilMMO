using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RinneResourceStateMachineAI
{
    public class Enemyeye : MonoBehaviour
    {
        private EnemyAI ea;             //エネミーAI
        private EnemyParameters ep;     //パラメーター
        private SphereCollider sc;      //探知距離用スフィアコライダー
        public GameObject m_player;     //プレイヤー
        public Vector3 m_posdelta;      //プレイヤーとの距離ベクトル

        void Start()
        {
            //コンポーネント取得
            ea = GetComponentInParent<EnemyAI>();
            ep = GetComponentInParent<EnemyParameters>();
            sc = GetComponent<SphereCollider>();
            //視野距離の設定
            sc.radius = ep.m_parameters.MaxDistance;
        }


        void Update()
        {
            //一度発見したプレイヤーとの距離を図り続ける
            if(m_player != null) m_posdelta = m_player.transform.position - transform.position;

        }

        //接触している間
        private void OnTriggerStay(Collider other)
        {
            //接触したオブジェクトがパラメータをもっている時
            if (other.GetComponent<EnemyParameters>())
            {
                EnemyParameters parameters = other.GetComponent<EnemyParameters>();
                //接触したパラメーターのタイプがプレイヤーの時
                if (parameters.m_parameters.type == "プレイヤー")
                {
                    //検知したプレイヤーをターゲットにする
                    if (ea.m_targetplayer == null) ea.m_targetplayer = other.gameObject;
                    m_player = other.gameObject;

                    float targetAngle = Vector3.Angle(transform.forward, m_posdelta);
                    //視野のレイを表示
                    Debug.DrawRay(transform.position, m_posdelta, Color.blue);
                    //ターゲットが視野範囲に入っている時
                    if (targetAngle < ep.m_parameters.MaxAngle)
                    {
                        //レイキャストで判定
                        if (Physics.Raycast(transform.position, m_posdelta, out RaycastHit hit))
                        {
                            //レイに当たっているのがプレイヤー
                            if (hit.collider == other)
                            {
                                Debug.Log("プレイヤー発見");
                                ep.m_parameters.IsFlag = true;
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

