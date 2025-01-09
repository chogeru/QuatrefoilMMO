using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class MSlot : MonoBehaviour
{
    public Image m_icon;
    public Image m_frame;
    public Button m_button;
    public GameObject m_removeButton;
    private MItemdata99 m_item2;

    private void Awake()
    {
        SetSelect(false);
        m_button.onClick.AddListener(OnClick);
    }

    public void SetSelect(bool select)
    {
        m_frame.enabled = select;
    }

    //アイテムを追加
    public void AddItem(MItemdata99 newItem)
    {
        m_item2 = newItem;
        m_icon.sprite = newItem.data.Getsprite;
        m_icon.enabled = true;
        m_removeButton.SetActive(true);
    }

    //アイテムをクリア
    public void ClearItem()
    {
        m_item2 = null;
        m_icon.sprite = null;
        m_icon.enabled = false;
        m_removeButton.SetActive(false);
    }

    //アイテム削除
    public void OnRemoveButton()
    {
        MInventory2.m_instance.Remove(m_item2.data);
    }

    //アイテムを使用
    public void UseItem()
    {
        if (m_item2 == null) return;
        Debug.Log("使う");
        MInventory2.m_instance.Use(m_item2.data);
    }

    private void OnClick()
    {
        MInventory2.m_instance.SelectSlot(m_item2);
    }
}
