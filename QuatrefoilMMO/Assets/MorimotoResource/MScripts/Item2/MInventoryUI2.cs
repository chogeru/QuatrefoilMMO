using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MInventoryUI2 : MonoBehaviour
{
    public Transform m_inventory;
    private MSlot[] m_slots;

    private void Start()
    {
        m_slots = m_inventory.GetComponentsInChildren<MSlot>();
    }

    //UI更新
    public void UpdateUI()
    {
        Debug.Log("UI更新中...");
        for (int i = 0; i < m_slots.Length; i++)
        {
            if (i < MInventory2.m_instance.m_item2s.Count)
            {
                m_slots[i].AddItem(MInventory2.m_instance.m_item2s[i]);
            }
            else
            {
                m_slots[i].ClearItem();
            }
        }
    }
}
