using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RinneResourceStateMachineAI
{
    [System.Serializable]
    public class QuestBattleData : ScriptableObject
    {
        public List<EnemyManager> entryEnemy;
    }

    [System.Serializable]
    public class EnemyManager : ScriptableObject
    {
        public string m_name;
        public string[] m_state;
        public GameObject obj;


        ////敵データを格納する構造体
        //[System.Serializable]
        //public struct ENEMY
        //{
        //    public string m_name;       //名前
        //    public string[] m_state;    //使用するステート
        //    public GameObject obj;      //使用する見た目
        //    public float m_hp;          //体力
        //}

        ////敵の構造体を格納するリスト
        //[SerializeField]
        //public List<ENEMY> enemy = new List<ENEMY>();

        //[SerializeField]
        //public ENEMY[] ene;

        /*void Start()
        {
            
            //敵データの構造体をリストに追加する
            //構造体の数だけループ
            for(int cnt = 0; cnt > enemy.Count;cnt++)
            {
                enemy.Add(ene[cnt]);
            }
            Debug.Log("リストへの追加完了");
            
    }
    void Update()
        {
            
        }*/
    }
}

