using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create ItemData")]
public class Mitemdata : ScriptableObject
{
    public enum m_itemtype
    {
        剣,
        杖,
        銃,
        斧,
        弓,
        拳,
        鎧,
        飾,
        癒,
        物,
        宝,
    }

    public enum m_itemsoubitype
    {
        Weapon,
        Armor,
        Accessory,
        Others,
    }

    /*
    public enum m_itemtype
    {
        Sword,
        Rod,
        Gun,
        Axe,
        Bow,
        Knuckle,
        Armor,
        Recovery,
        Nomal,
        Important
    }
    */

    //アイテムの名前
    [SerializeField]
    private string m_Itemname;
    //アイテムのタイプ
    [SerializeField]
    private m_itemtype m_Itemtype;
    //アイテム装備のタイプ
    [SerializeField]
    private m_itemsoubitype m_Itemsoubitype;
    //アイテムのアイコン
    [SerializeField]
    private Sprite m_Itemicon;
    //アイテムの説明
    [SerializeField]
    private string m_Itemexplanation;
    //アイテムの持てる最大個数
    [SerializeField]
    private int m_Itemlimit;

    public int ItemHP;          //アイテムHP回復
    public int ItemMP;          //アイテムMP回復
    public int ItemATK;         //アイテム攻撃力
    public int ItemDEF;         //アイテム防御力
    public int ItemINT;         //アイテム魔力
    public int ItemRES;         //アイテム魔法防御力
    public int ItemAGI;         //アイテム移動速度

    public string ItemHyouziRank;     //アイテム等級

    public string GetItemname()
    {
        return m_Itemname;
    }

    public string GetItemtypehyouzi()
    {
        return m_Itemtype.ToString();
    }

    public m_itemsoubitype GetItemsoubitype()
    {
        return m_Itemsoubitype;
    }

    public Sprite GetItemicon()
    {
        return m_Itemicon;
    }

    public string GetItemexplanation()
    {
        return m_Itemexplanation;
    }

    public int GetItemlimit()
    {
        return m_Itemlimit;
    }

    public int GetItemHP()
    {
        return ItemHP;
    }

    public int GetItemMP()
    {
        return ItemMP;
    }

    public int GetItemATK()
    {
        return ItemATK;
    }

    public int GetItemDEF()
    {
        return ItemDEF;
    }

    public int GetItemINT()
    {
        return ItemINT;
    }

    public int GetItemRES()
    {
        return ItemRES;
    }

    public int GetItemAGI()
    {
        return ItemAGI;
    }

    public string GetSoubiRank()
    {
        return ItemHyouziRank;
    }

}
