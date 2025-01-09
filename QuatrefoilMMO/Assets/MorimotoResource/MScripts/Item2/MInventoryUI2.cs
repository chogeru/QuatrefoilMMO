using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MInventoryUI2 : MonoBehaviour
{
    public Transform m_inventory;
    private MSlot[] m_slots;

    private void Start()
    {
    }

    //UI更新
    public void UpdateUI()
    {
        if (m_slots == null)
        {
            m_slots = m_inventory.GetComponentsInChildren<MSlot>();
        }
        Debug.Log("UI更新中...");
        for (int i = 0; i < m_slots.Length; i++)
        {
            if (i < MInventory2.m_instance.m_item2s.Count)
            {
                MItemdata99 item = MInventory2.m_instance.m_item2s[i];
                m_slots[i].AddItem(item);
            }
            else
            {
                m_slots[i].ClearItem();
            }
        }
    }

    public void SetSelect(int index, bool select)
    {
        if (m_slots == null) return;
        if (!(0 <= index && index < m_slots.Length))
        {
            return;
        }
        m_slots[index].SetSelect(select);
    }
}
