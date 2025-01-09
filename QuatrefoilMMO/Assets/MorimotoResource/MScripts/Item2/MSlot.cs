using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class MSlot : MonoBehaviour
{
    public Image m_icon;
    public GameObject m_removeButton;
    private MItemSourceData m_item2;
    private Text m_nametext;
    public Text Getname
    {
        get { return m_nametext; }
    }
    private Text m_setumeitext;
    public Text Getsetumei
    {
        get { return m_setumeitext; }
    }

    //アイテムを追加
    public void AddItem(MItemSourceData newItem)
    {
        m_item2 = newItem;
        m_icon.sprite = newItem.Getsprite;
        m_icon.enabled = true;
        m_removeButton.SetActive(true);
        m_nametext.text = newItem.Getitemname;
        m_setumeitext.text = newItem.Getitemsetuemi;
    }

    //アイテムをクリア
    public void ClearItem()
    {
        m_item2 = null;
        m_icon.sprite = null;
        m_icon.enabled = false;
        m_removeButton.SetActive(false);
        m_nametext.text = null;
        m_setumeitext.text = null;
    }

    //アイテム削除
    public void OnRemoveButton()
    {
        MInventory2.m_instance.Remove(m_item2);
    }

    //アイテムを使用
    public void UseItem()
    {
        if (m_item2 == null) return;
        //MPlayerControllerFencer.UseItem();
    }

}
