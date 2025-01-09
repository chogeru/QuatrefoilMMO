using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.AI;

using UnityEngine.UI;
using static Mitemdata;
using static MagicaCloth2.TeamManager;
using static UnityEditor.Progress;

public class Mitemkanri : MonoBehaviour
{
    [SerializeField]
    private Mitemdatabase m_itemDataBase;

    //作った各アイテムのiconを指定(スロットの番号順に)
    [SerializeField] private GameObject m_icon1;
    [SerializeField] private GameObject m_icon2;
    [SerializeField] private GameObject m_icon3;
    [SerializeField] private GameObject m_icon4;
    [SerializeField] private GameObject m_icon5;
    [SerializeField] private GameObject m_icon6;
    [SerializeField] private GameObject m_icon7;
    [SerializeField] private GameObject m_icon8;
    [SerializeField] private GameObject m_icon9;
    [SerializeField] private GameObject m_icon10;
    [SerializeField] private GameObject m_icon11;
    [SerializeField] private GameObject m_icon12;
    [SerializeField] private GameObject m_icon13;
    [SerializeField] private GameObject m_icon14;
    [SerializeField] private GameObject m_icon15;
    [SerializeField] private GameObject m_icon16;
    [SerializeField] private GameObject m_icon17;
    [SerializeField] private GameObject m_icon18;
    [SerializeField] private GameObject m_icon19;
    [SerializeField] private GameObject m_icon20;
    [SerializeField] private GameObject m_icon21;
    [SerializeField] private GameObject m_icon22;
    [SerializeField] private GameObject m_icon23;
    [SerializeField] private GameObject m_icon24;
    [SerializeField] private GameObject m_icon25;
    [SerializeField] private GameObject m_icon26;
    [SerializeField] private GameObject m_icon27;
    [SerializeField] private GameObject m_icon28;
    [SerializeField] private GameObject m_icon29;
    [SerializeField] private GameObject m_icon30;
    [SerializeField] private GameObject m_icon31;
    [SerializeField] private GameObject m_icon32;
    [SerializeField] private GameObject m_icon33;
    [SerializeField] private GameObject m_icon34;
    [SerializeField] private GameObject m_icon35;
    [SerializeField] private GameObject m_icon36;
    [SerializeField] private GameObject m_icon37;
    [SerializeField] private GameObject m_icon38;
    [SerializeField] private GameObject m_icon39;
    [SerializeField] private GameObject m_icon40;

    //トグルグループであるinventoryを指定
    [SerializeField]
    private ToggleGroup m_togglegroup;

    //アイテム説明表示欄
    //説明欄のTextMeshProを指定
    [SerializeField]
    private TextMeshProUGUI m_itemname;
    [SerializeField]
    private TextMeshProUGUI m_itemsetumei;

    //アイテム数管理
    private Dictionary<Mitemdata, int> m_itemkazu = new Dictionary<Mitemdata, int>();

    //持ち物管理
    public List<Mitemdata> m_MotimonoList = new List<Mitemdata>();

    //アイコン管理の配列
    private Image[] m_Icons = new Image[40];

    private void Start()
    {
        //初期化アイテム処理
        for (int i = 0; i < m_itemDataBase.GetItemLists().Count; i++)
        {
            //アイテム数を全て0に
            m_itemkazu.Add(m_itemDataBase.GetItemLists()[i], 0);
        }

        //持っている初期アイテム設定
        //ポーションの数を2にする
        m_itemkazu[m_itemDataBase.GetItemLists()[1]] = 2;
        //ロングソードの数を1にする
        m_itemkazu[m_itemDataBase.GetItemLists()[0]] = 1;
        m_itemkazu[m_itemDataBase.GetItemLists()[2]] = 1;
        m_itemkazu[m_itemDataBase.GetItemLists()[3]] = 1;
        m_itemkazu[m_itemDataBase.GetItemLists()[4]] = 1;
        m_itemkazu[m_itemDataBase.GetItemLists()[5]] = 1;
        m_itemkazu[m_itemDataBase.GetItemLists()[6]] = 1;

        //持ち物更新処理を呼び出す
        Motimonokoushin();
    }

    //どこからでもアクセス可能　返り値なし
    public void Motimonokoushin()
    {
        //持ち物更新処理
        //持ち物リストのクリア
        m_MotimonoList.Clear();

        //持っている個数が1個以上のアイテムを持ち物リストに追加する
        for (int i = 0; i < m_itemkazu.Count; i++)
        {
            var e = m_itemkazu[m_itemDataBase.GetItemLists()[i]];

            if (e > 0)
            {
                m_MotimonoList.Add(m_itemDataBase.GetItemLists()[i]);
            }
        }

        //アイテムスロットのアイコンimageをGetComponentしてアイコン配列に代入
        m_Icons[0] = m_icon1.GetComponent<Image>();
        m_Icons[1] = m_icon2.GetComponent<Image>();
        m_Icons[2] = m_icon3.GetComponent<Image>();
        m_Icons[3] = m_icon4.GetComponent<Image>();
        m_Icons[4] = m_icon5.GetComponent<Image>();
        m_Icons[5] = m_icon6.GetComponent<Image>();
        m_Icons[6] = m_icon7.GetComponent<Image>();
        m_Icons[7] = m_icon8.GetComponent<Image>();
        m_Icons[8] = m_icon9.GetComponent<Image>();
        m_Icons[9] = m_icon10.GetComponent<Image>();
        m_Icons[10] = m_icon11.GetComponent<Image>();
        m_Icons[11] = m_icon12.GetComponent<Image>();
        m_Icons[12] = m_icon13.GetComponent<Image>();
        m_Icons[13] = m_icon14.GetComponent<Image>();
        m_Icons[14] = m_icon15.GetComponent<Image>();
        m_Icons[15] = m_icon16.GetComponent<Image>();
        m_Icons[16] = m_icon17.GetComponent<Image>();
        m_Icons[17] = m_icon18.GetComponent<Image>();
        m_Icons[18] = m_icon19.GetComponent<Image>();
        m_Icons[19] = m_icon20.GetComponent<Image>();
        m_Icons[20] = m_icon21.GetComponent<Image>();
        m_Icons[21] = m_icon22.GetComponent<Image>();
        m_Icons[22] = m_icon23.GetComponent<Image>();
        m_Icons[23] = m_icon24.GetComponent<Image>();
        m_Icons[24] = m_icon25.GetComponent<Image>();
        m_Icons[25] = m_icon26.GetComponent<Image>();
        m_Icons[26] = m_icon27.GetComponent<Image>();
        m_Icons[27] = m_icon28.GetComponent<Image>();
        m_Icons[28] = m_icon29.GetComponent<Image>();
        m_Icons[29] = m_icon30.GetComponent<Image>();
        m_Icons[30] = m_icon31.GetComponent<Image>();
        m_Icons[31] = m_icon32.GetComponent<Image>();
        m_Icons[32] = m_icon33.GetComponent<Image>();
        m_Icons[33] = m_icon34.GetComponent<Image>();
        m_Icons[34] = m_icon35.GetComponent<Image>();
        m_Icons[35] = m_icon36.GetComponent<Image>();
        m_Icons[36] = m_icon37.GetComponent<Image>();
        m_Icons[37] = m_icon38.GetComponent<Image>();
        m_Icons[38] = m_icon39.GetComponent<Image>();
        m_Icons[39] = m_icon40.GetComponent<Image>();

        //各アイコンの画像をnullにする(一旦全て空スロットとする)
        m_Icons[0].sprite = null;
        m_Icons[1].sprite = null;
        m_Icons[2].sprite = null;
        m_Icons[3].sprite = null;
        m_Icons[4].sprite = null;
        m_Icons[5].sprite = null;
        m_Icons[6].sprite = null;
        m_Icons[7].sprite = null;
        m_Icons[8].sprite = null;
        m_Icons[9].sprite = null;
        m_Icons[10].sprite = null;
        m_Icons[11].sprite = null;
        m_Icons[12].sprite = null;
        m_Icons[13].sprite = null;
        m_Icons[14].sprite = null;
        m_Icons[15].sprite = null;
        m_Icons[16].sprite = null;
        m_Icons[17].sprite = null;
        m_Icons[18].sprite = null;
        m_Icons[19].sprite = null;
        m_Icons[20].sprite = null;
        m_Icons[21].sprite = null;
        m_Icons[22].sprite = null;
        m_Icons[23].sprite = null;
        m_Icons[24].sprite = null;
        m_Icons[25].sprite = null;
        m_Icons[26].sprite = null;
        m_Icons[27].sprite = null;
        m_Icons[28].sprite = null;
        m_Icons[29].sprite = null;
        m_Icons[30].sprite = null;
        m_Icons[31].sprite = null;
        m_Icons[32].sprite = null;
        m_Icons[33].sprite = null;
        m_Icons[34].sprite = null;
        m_Icons[35].sprite = null;
        m_Icons[36].sprite = null;
        m_Icons[37].sprite = null;
        m_Icons[38].sprite = null;
        m_Icons[39].sprite = null;

        //各アイコンのカラー設定。以下の数値だと灰色のような色となる(空スロット表現用)
        m_Icons[0].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[1].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[2].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[3].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[4].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[5].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[6].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[7].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[8].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[9].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[10].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[11].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[12].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[13].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[14].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[15].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[16].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[17].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[18].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[19].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[20].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[21].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[22].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[23].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[24].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[25].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[26].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[27].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[28].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[29].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[30].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[31].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[32].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[33].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[34].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[35].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[36].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[37].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[38].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);
        m_Icons[39].color = new Color(0.2196f, 0.2196f, 0.2196f, 1f);

        //持ち物リストの要素数だけ繰り返す
        for (int i = 0; i < m_MotimonoList.Count; i++)
        {
            //持ち物リストのi番目をfに代入
            var f = m_MotimonoList[i];
            //fにアイコンを配列に代入
            m_Icons[i].sprite = f.GetItemicon();
            //配列のアイコンカラーを白色にする(アイコンを見やすくするため)
            m_Icons[i].color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void slotkoushin()
    {
        //スロット更新処理
        //選択されているトグル(選択されているアイテムスロット)を代入
        Toggle tgl = m_togglegroup.ActiveToggles().FirstOrDefault();

        //選択されているトグルのゲームオブジェクト名を代入
        string x = tgl.name;

        //Parseにより文字列の数字をint型やfloat型にできる　今回はint型にしてyに代入
        int y = int.Parse(x);

        //持ち物リストの要素数がy以上かどうかを確認する
        if (m_MotimonoList.Count >= y)
        {
            //選択されているトグルはアイコン表示されている
            //持ち物リストのy-1番(リストが始まるのが0番目からであるため)の名前と個数をz、kに代入
            string z = m_MotimonoList[y - 1].GetItemname();

            int k = m_itemkazu[m_MotimonoList[y - 1]];

            //zとkを合わせてアイテム名の文字列を作成しtextに出す
            m_itemname.text = ($"{z}×{k}");

            //持ち物リストのアイテムの説明をjに代入しtextに出す
            string j = m_MotimonoList[y - 1].GetItemexplanation();
            m_itemsetumei.text = j;
        }
        else
        {
            //条件に当てはまらなかった場合選択されたアイテムスロットが空だったという事よってtextにはnullを代入する
            m_itemname.text = null;
            m_itemsetumei.text = null;
        }
    }

    public int itemkosuu(Mitemdata soubilist)
    {
        return m_itemkazu[soubilist];
    }

    public List<Mitemdata> itemtypelist(m_itemsoubitype soubitype)
    {
        Mitemdata mitemdata = new Mitemdata();
        soubitype = mitemdata.GetItemsoubitype();
        return new List<Mitemdata>();
    }
}
