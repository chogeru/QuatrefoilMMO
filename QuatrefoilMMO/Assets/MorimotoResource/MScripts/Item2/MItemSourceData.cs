using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムの種類（列挙型）
public enum ItemType
{
    Sword = 0,      //剣
    Wand = 1,       //杖
    Gun = 2,        //銃
    Ax = 3,         //斧
    Bow = 4,        //弓
    Fist = 5,       //拳
    Armor = 6,      //鎧
    Accessory = 7,  //アクセサリ
    Tool = 8,       //道具
    Recovery = 9,   //回復
    Important = 10, //重要
}

public enum ItemEffectType
{
    None = -1,
    RecoveryHP,
}

//アイテムのソースデータ
[CreateAssetMenu(menuName ="MAsset/ItemSourceData")]
public class MItemSourceData : ScriptableObject
{
    //アイテム識別ID
    [SerializeField]
    private string m_id;
    //IDを取得
    public string Getid
    {
        get { return m_id; }
    }

    //アイテムの名前
    [SerializeField]
    private string m_name;
    //アイテム名を取得
    public string Getitemname
    {
        get { return m_name; }
    }

    //アイテムの種類
    [SerializeField]
    private ItemType m_itemType;
    //アイテムの種類を取得
    public ItemType Getitemtype
    {
        get { return m_itemType; }
    }

    //アイテムの説明
    [SerializeField]
    private string m_setumei;
    //アイテム名を取得
    public string Getitemsetuemi
    {
        get { return m_setumei; }
    }

    //アイテムの見た目
    [SerializeField]
    private Sprite m_sprite;
    //アイテムの見た目を取得
    public Sprite Getsprite
    {
        get { return m_sprite; }
    }

    [SerializeField]
    private ItemEffectType m_effectType = ItemEffectType.None;
    public ItemEffectType GetEffectType
    {
        get { return m_effectType; }
    }

    //アイテムの体力
    [SerializeField]
    private int m_HP;
    //アイテムの見た目を取得
    public int GetHP
    {
        get { return m_HP; }
    }

    //アイテムの攻撃力
    [SerializeField]
    private int m_ATK;
    //アイテムの見た目を取得
    public int GetATK
    {
        get { return m_ATK; }
    }

    //アイテムの防御力
    [SerializeField]
    private int m_DEF;
    //アイテムの見た目を取得
    public int GetDEF
    {
        get { return m_DEF; }
    }
}
