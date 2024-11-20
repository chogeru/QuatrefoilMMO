using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MagicaCloth2.TeamManager;
using static UnityEditor.Progress;

[CreateAssetMenu(menuName = "Data/Create ItemDataBase")]

public class Mitemdatabase : ScriptableObject
{
    [SerializeField]
    private List<Mitemdata> m_itemLists = new List<Mitemdata>();

    //アイテムリストを返す
    public List<Mitemdata> GetItemLists()
    {
        return m_itemLists;
    }
}
