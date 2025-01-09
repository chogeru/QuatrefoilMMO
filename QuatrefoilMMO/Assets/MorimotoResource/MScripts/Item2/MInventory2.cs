using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MInventory2 : MonoBehaviour
{
    public static MInventory2 m_instance; //シングルトンパターン
    private MInventoryUI2 m_inventoryUI;  //UI更新用の参照

    //アイテムリスト
    public List<MItemSourceData> m_item2s = new List<MItemSourceData>();

    private void Awake()
    {
        if(m_instance == null)
        {
            m_instance = this;
        }
    }

    private void Start()
    {
        m_inventoryUI = GetComponent<MInventoryUI2>();
        m_inventoryUI.UpdateUI();
    }

    //アイテムを追加
    public void Add(MItemSourceData item)
    {
        m_item2s.Add(item);
        m_inventoryUI.UpdateUI();
    }

    //アイテムを削除
    public void Remove(MItemSourceData item)
    {
        m_item2s.Remove(item);
        m_inventoryUI.UpdateUI();
    }
}
