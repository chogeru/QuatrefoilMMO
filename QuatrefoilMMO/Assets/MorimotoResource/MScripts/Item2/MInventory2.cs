using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MInventory2 : MonoBehaviour
{
    public static MInventory2 m_instance; //シングルトンパターン
    private MInventoryUI2 m_inventoryUI;  //UI更新用の参照
    public Button m_useButton;

    //アイテムリスト
    public List<MItemdata99> m_item2s = new List<MItemdata99>();
    public int m_selctIndex = -1;
    public MItemdata99 selectItem
    {
        get
        {
            if (m_selctIndex < 0) return null;
            return m_item2s[m_selctIndex];
        }
    }

    private void Awake()
    {
        if(m_instance == null)
        {
            m_instance = this;
        }
        m_useButton.onClick.AddListener(OnClickUse);
    }

    private void Start()
    {
        m_inventoryUI = GetComponent<MInventoryUI2>();
        m_inventoryUI.UpdateUI();

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        UnSelectSlot();
    }

    //アイテムを追加
    public void Add(MItemSourceData item)
    {
        MItemdata99 slot = m_item2s.Find(_ => _.data == item);
        if(slot != null)
        {
            slot.Add(1);
        }
        else
        {
            slot = new MItemdata99();
            slot.data = item;
            slot.count = 1;
            m_item2s.Add(slot);
        }
        m_inventoryUI.UpdateUI();
    }

    //アイテムを削除
    public void Remove(MItemSourceData item)
    {
        MItemdata99 slot = m_item2s.Find(_ => _.data == item);
        if (slot != null)
        {
            UnSelectSlot();
            m_item2s.Remove(slot);
        }
        m_inventoryUI.UpdateUI();
    }

    public void Use(MItemSourceData item)
    {
        MItemdata99 slot = m_item2s.Find(_ => _.data == item);
        if (slot != null)
        {
            slot.Use();
            if (slot.count <= 0)
            {
                UnSelectSlot();
                m_item2s.Remove(slot);
            }
        }
        m_inventoryUI.UpdateUI();
    }

    public void SelectSlot(MItemdata99 data)
    {
        int index = m_item2s.IndexOf(data);
        if (index == m_selctIndex) return;

        if (m_selctIndex >= 0)
        {
            m_inventoryUI.SetSelect(m_selctIndex, false);
        }
        m_selctIndex = index;
        m_inventoryUI.SetSelect(m_selctIndex, true);
    }

    public void UnSelectSlot()
    {
        if (m_selctIndex < 0) return;
        m_inventoryUI.SetSelect(m_selctIndex, false);
        m_selctIndex = -1;
    }

    private void OnClickUse()
    {
        if (m_selctIndex < 0) return;
        Use(m_item2s[m_selctIndex].data);
    }

    private void Update()
    {
        m_useButton.gameObject.SetActive(m_selctIndex >= 0);
    }
}
