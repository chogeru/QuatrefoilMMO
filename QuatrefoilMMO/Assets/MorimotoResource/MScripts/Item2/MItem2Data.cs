using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MItem2Data
{
    public string m_id;   //アイテムid
    private int m_count;  //所持数

    //コンストラクタ
    public MItem2Data(string id, int count = 1)
    {
        this.m_id = id;
        this.m_count = count;
    }

    //所持数カウントアップ
    public void CountUp(int value = 1)
    {
        m_count += value;
    }

    //所持数カウントダウン
    public void CountDwon(int value = 1)
    {
        m_count -= value;
    }    
}

//アイテム管理クラス
public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private List<MItemSourceData> m_itemSourceDataList;
    private List<MItem2Data> m_playerItemDataList = new List<MItem2Data>();

    private void Awake()
    {
        LoadItemSourceData();
    }

    //アイテムをロードする
    private void LoadItemSourceData()
    {
        m_itemSourceDataList = Resources.LoadAll("ScriptableObject", typeof(MItemSourceData)).Cast<MItemSourceData>().ToList();
    }

    //アイテムソースデータを取得
    public MItemSourceData GetMItemSourceData(string id)
    {
        //アイテムを検索
        foreach(var sourceData in m_itemSourceDataList)
        {
            //IDが一致していたら
            if (sourceData.Getid == id)
            {
                return sourceData;
            }
        }
        return null;
    }

    //アイテム取得
    public void CountItem(string itemid, int count)
    {
        for (int i = 0; i < m_playerItemDataList.Count; i++)
        {
            //IDが一致していたらカウント
            if (m_playerItemDataList[i].m_id == itemid)
            {
                m_playerItemDataList[i].CountUp(count);
                break;
            }
        }

        //IDが一致しなければアイテムを追加
        MItem2Data mItem2Data = new MItem2Data(itemid, count);
        m_playerItemDataList.Add(mItem2Data);
    }
}
