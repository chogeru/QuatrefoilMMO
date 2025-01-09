using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RinneResourceStateMachineAI
{
    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField,Header("スポーンするまでのクールタイム")]
        private float m_cooltime = 5;
        [SerializeField, Header("スポーンする最大数")]
        private int m_maxspawncnt = 2;
        [SerializeField,Header("このポイントから出現する敵")]
        private EnemyManager[] enemydata;

        //現在の時間
        private float m_elapsedtime;
        //現在スポーンしたモンスターの合計
        private int m_spawncnt;

        private void Start()
        {
            //スポーンカウントの初期状態は0
            m_spawncnt = 0;
            //開始後すぐモンスター召喚
            m_elapsedtime = m_cooltime;
        }

        //現在のスポーンした数を取得
        public int GetSpawncnt()
        {
            return m_spawncnt;
        }

        //撃破されたので数を減らす
        public int DownSpawncnt()
        {
            return m_spawncnt--;
        }

        void Update()
        {
            //最大数スポーンしていない
            if(m_spawncnt < m_maxspawncnt)
            {
                //クールタイム終了
                if (m_elapsedtime > m_cooltime)
                {
                    //出現する敵からランダムで選ばれる
                    int enemy_no = Random.Range(0, enemydata.Length);
                    //モンスタースポーン
                    GameObject Obj = Instantiate(enemydata[enemy_no].obj, this.transform.position, this.transform.rotation, this.transform);
                    //スポーンした数を増やす
                    m_spawncnt++;

                    //Debug.Log($"ポップ数:{m_spawncnt}体");

                    //ポップしたモンスターのコンポーネントを取得
                    EnemyAI enemyai = Obj.GetComponent<EnemyAI>();
                    //生成したモンスターにステートを追加
                    for (int n = 0; n < enemydata[enemy_no].m_state.Length; n++)
                    {
                        if (!enemyai.AddStateByName(enemydata[enemy_no].m_state[n]))
                            Destroy(Obj);
                    }
                    //時間リセット
                    m_elapsedtime -= m_cooltime;
                }
                //経過時間の処理
                m_elapsedtime += Time.deltaTime;
            }
        }
    }
}

