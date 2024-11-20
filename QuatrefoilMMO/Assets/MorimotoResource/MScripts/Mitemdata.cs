using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create ItemData")]
public class Mitemdata : ScriptableObject
{
    public enum m_itemtype
    {
        Sword,
        Rod,
        Gun,
        Axe,
        Bow,
        Armor,
        Recovery,
        Nomal,
        Important
    }

    //アイテムの名前
    [SerializeField]
    private string m_Itemname;
    //アイテムのタイプ
    [SerializeField]
    private m_itemtype m_Itemtype;
    //アイテムのアイコン
    [SerializeField]
    private Sprite m_Itemicon;
    //アイテムの説明
    [SerializeField]
    private string m_Itemexplanation;
    //アイテムの持てる最大個数
    [SerializeField]
    private int m_Itemlimit;

    public string GetItemname()
    {
        return m_Itemname;
    }

    public m_itemtype GetItemtype()
    {
        return m_Itemtype;
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
}
