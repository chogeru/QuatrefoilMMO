using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mitemran : MonoBehaviour
{
    public Text m_nameText;
    public Text m_setumeiText;
    public Text m_countText;

    private void Update()
    {
        if (MInventory2.m_instance == null) return;
        MItemdata99 item = MInventory2.m_instance.selectItem;
        if(item != null)
        {
            m_nameText.text = item.data.Getitemname;
            m_setumeiText.text = item.data.Getitemsetuemi;
            m_countText.text = $"×{item.count}";

        }
        else
        {
            m_nameText.text = "";
            m_setumeiText.text = "";
            m_countText.text = "";
        }
    }
}
