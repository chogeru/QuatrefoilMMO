using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPickUpItem : MonoBehaviour
{
    //Itemデータを入れる
    public MItemSourceData m_item2;

    public void OnTriggerEnter(Collider other)
    {
        PickUp();
    }

    //インベントリにアイテムを追加
    public void PickUp()
    {
        MInventory2.m_instance.Add(m_item2);
        Debug.Log(m_item2.name + "を入手しました");
        Destroy(gameObject);
    }
}
