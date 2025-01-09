using UnityEngine;
using static Mitemdata;

[CreateAssetMenu(menuName ="Data/Create PlayerStatusData")]
public class Mplayerdata : ScriptableObject
{
    public string NAME;     //キャラ・敵名
    public int MAXHP;       //最大HP
    public int MAXMP;       //最大MP
    public int ATK;         //攻撃力
    public int DEF;         //防御力
    public int INT;         //魔力
    public int RES;         //魔法防御力
    public int AGI;         //移動速度
    public int LV;          //レベル
    public int EXP;         //経験値
    public int GOLD;        //所持金

    public int PlayerMAXHP; //キャラ自体の最大HP
    public int PlayerMAXMP; //キャラ自体の最大MP
    public int PlayerATK;   //キャラ自体の攻撃力
    public int PlayerDEF;   //キャラ自体の防御力
    public int PlayerINT;   //キャラ自体の魔力
    public int PlayerRES;   //キャラ自体の魔法抵抗力
    public int PlayerAGI;   //キャラ自体の移動速度

    public int GrowMAXHP;   //最大HPの成長率
    public int GrowMAXMP;   //最大MPの成長率
    public int GrowATK;     //攻撃力の成長率
    public int GrowDEF;     //防御力の成長率
    public int GrowINT;     //魔力の成長率
    public int GrowRES;     //魔法抵抗力の成長率
    public int GrowAGI;     //移動速度の成長率

    public int FirstMAXHP;  //最大HPの初期
    public int FirstMAXMP;  //最大MPの初期
    public int FirstATK;    //攻撃力の初期
    public int FirstDEF;    //防御力の初期
    public int FirstINT;    //魔力の初期
    public int FirstRES;    //魔法抵抗力の初期
    public int FirstAGI;    //移動速度の初期

    public Mitemdata Soubi1;
    public Mitemdata Soubi2;
    public Mitemdata Soubi3;
    public Mitemdata Soubi4;

    public m_itemsoubitype m_Soubitype1;
    public m_itemsoubitype m_Soubitype2;
    public m_itemsoubitype m_Soubitype3;
    public m_itemsoubitype m_Soubitype4;
}
