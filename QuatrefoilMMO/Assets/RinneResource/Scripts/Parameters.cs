using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    public enum charatype
    {
        Player,
        Enemy,
        Boss,
        NPC,
    }
    
    [System.Serializable]
    public struct Parameter
    {
        [SerializeField,Header("全キャラ共通")]
        public charatype type;      //種類
        public float LV;            //レベル
        public float HP;            //体力
        public float MP;            //魔力
        public float ATK;           //攻撃力
        public float DEF;           //物理防御力
        public float RES;           //魔法防御力
        public float AGI;           //素早さ
        [SerializeField,Header("敵キャラ共通")]
        public float EXP;           //経験値
        public float MaxDistance;   //探索距離
        public float MaxAngle;      //探索範囲
        public bool IsFlag;         //探索フラグ
    }

    private bool m_isdown = false;      //死亡フラグ

    [SerializeField]
    public Parameter m_status;

    private void Update()
    {
        //ヒットポイントが0で削除
        if (m_status.HP <= 0)
        {
            m_isdown = true;
        }
    }

    //攻撃ヒット時の処理
    public void AttackHit(float ATK)
    {
        m_status.HP = m_status.HP - ATK;
    }

    //種類を文字列に変換して取得
    public string GetParameterType()
    {
        return m_status.type.ToString();
    }

    public bool GetDown()
    {
        return m_isdown;
    }
}
