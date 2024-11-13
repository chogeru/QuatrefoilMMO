using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    [System.Serializable]
    public struct Parameter
    {
        //全キャラ共通
        public string type;         //種類
        public float LV;            //レベル
        public float HP;            //体力
        public float MP;            //魔力
        public float ATK;           //攻撃力
        public float DEF;           //物理防御力
        public float RES;           //魔法防御力
        public float AGI;           //素早さ
        //Enemyのみ共通
        public float EXP;           //経験値
        public float MaxDistance;   //探索距離
        public float MaxAngle;      //探索範囲
        public bool IsFlag;         //探索フラグ         
    }

    [SerializeField]
    public Parameter m_status;

    private void Update()
    {
        //ヒットポイントが0で削除
        if (m_status.HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //攻撃ヒット時の処理
    public void AttackHit(float ATK)
    {
        m_status.HP = m_status.HP - ATK;
    }

}
