using RinneResourceStateMachineAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RinneResource
{
    public class BossBattleMovie : MonoBehaviour
    {
        [SerializeField,Header("生成するボスモンスターのバトルデータ")]
        private EnemyManager m_enemymanager;

        [SerializeField]
        private FadeControl m_fadecontrol;

        private GameObject m_obj;
        private EnemyAI m_enemyai;
        private int m_count;

        public GameObject m_player;
        public GameObject m_camera;

        private void OnTriggerEnter(Collider other)
        {
            ////パラメータを持つオブジェクト
            if (other.GetComponent<Parameters>())
            {
                Parameters player = other.GetComponent<Parameters>();
                //取得したパラメータのタイプがプレイヤーかつ出現数が１体以下なら
                if (player.GetParameterType() == "Player" && m_count < 1)
                {
                    //2秒でフェードアウト
                    m_fadecontrol.FadeOut(2.0f, () => {
                        BossSpawn();        //ボス生成
                        m_camera.SetActive(false);
                        m_fadecontrol.FadeIn(2.0f); //２秒でフェードイン
                    });
                }
            }
        }
        //ボスモンスターのスポーン処理
        private void BossSpawn()
        {
            //ボスモンスターリポップ
            m_obj = Instantiate(m_enemymanager.obj, this.transform.position, this.transform.rotation, this.transform);
            //ポップしたモンスターのコンポーネントを取得
            m_enemyai = m_obj.GetComponent<EnemyAI>();
            //生成したモンスターにステートを追加
            for (int n = 0; n < m_enemymanager.m_state.Length; n++)
            {
                if (!m_enemyai.AddStateByName(m_enemymanager.m_state[n]))
                    Destroy(m_obj);
            }
            m_count++;
        }

        public void CountDown()
        {
            m_count--;
        }
    }
}

