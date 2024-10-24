using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParameters : MonoBehaviour
{
    [System.Serializable]
    public struct Parameters
    {
        public string type;         //種類
        public float LV;            //レベル
        public float HP;            //体力
        public float MP;            //魔力
        public float ATK;           //攻撃力
        public float DEF;           //物理防御力
        public float RES;           //魔法防御力
        public float AGI;           //素早さ
        public float EXP;           //経験値
        public float MaxDistance;   //探索距離
        public float MaxAngle;      //探索範囲
        public bool IsFlag;         //探索フラグ
    }

    [SerializeField]
    public Parameters m_parameters;

    void Start()
    {
        
    }

    
    void Update()
    {
        //ヒットポイントが0で削除
        if(m_parameters.HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //攻撃ヒット時の処理
    public void AttackHit(float ATK)
    {
        m_parameters.HP = m_parameters.HP - ATK;
    }
}
