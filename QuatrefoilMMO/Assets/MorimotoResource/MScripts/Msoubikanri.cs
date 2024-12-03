using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

using System;

public class Msoubikanri : MonoBehaviour
{
    [SerializeField]
    private Mitemdatabase m_itemDataBase;

    //現在装備の配列
    Mitemdata[] m_Soubi = new Mitemdata[4];

    //現在装備アイコン
    [SerializeField] private GameObject m_icon1;
    [SerializeField] private GameObject m_icon2;
    [SerializeField] private GameObject m_icon3;
    [SerializeField] private GameObject m_icon4;

    //アイコン管理の配列
    Image[] m_Icons = new Image[4];

    //現在装備名前
    [SerializeField] private TextMeshProUGUI m_itemname1;
    [SerializeField] private TextMeshProUGUI m_itemname2;
    [SerializeField] private TextMeshProUGUI m_itemname3;
    [SerializeField] private TextMeshProUGUI m_itemname4;

    //現在装備トグルグループのsoubirenを指定
    [SerializeField]
    private ToggleGroup m_togglegroup1;

    //現在装備トグルグループのcontentを指定
    [SerializeField]
    private ToggleGroup m_togglegroup2;

    //装備可能リスト
    List<Mitemdata> m_SoubikanouList = new List<Mitemdata>();

    //装備上昇ステータス表示
    [SerializeField] private TextMeshProUGUI m_ATKKASAN;
    [SerializeField] private TextMeshProUGUI m_DEFKASAN;
    [SerializeField] private TextMeshProUGUI m_INTKASAN;
    [SerializeField] private TextMeshProUGUI m_RESKASAN;
    [SerializeField] private TextMeshProUGUI m_AGIKASAN;
    [SerializeField] private TextMeshProUGUI m_KYUU;

    //装備タイプ表示
    [SerializeField]
    private TextMeshProUGUI m_soubitypehyouzi;

    //装備説明
    [SerializeField]
    private TextMeshProUGUI m_soubisetumei;

    private Mitemdata.m_itemtype m_Soubitype;

    //どのキャラを操作するか持っているゲームオブジェクトを指定
    [SerializeField]
    private GameObject m_PlayerkanriObject;
    private MPlayerControllerFencer m_Playerkanriscript;

    //アイテム管理ゲームオブジェクトを指定
    [SerializeField]
    private GameObject m_itemObject;
    private Mitemkanri m_itemscript;

    //外すスロット用プレハブと装備可能スロット用プレハブを指定
    [SerializeField] private GameObject m_yousoprefab;
    [SerializeField] private GameObject m_hazusuprefab;
    
    [SerializeField]
    private GameObject m_content;
    Msoubiyouso m_soubiyousoscript;

    //各アイテムの装着数を管理する
    private Dictionary<Mitemdata,int> m_SoubiisoutyakuDictionary=new Dictionary<Mitemdata,int>();

    private int m_soubidankai;

    //最初は非アクティブにして指定　アクティブにすることで
    [SerializeField] private GameObject m_Soubisetumei;
    [SerializeField] private GameObject m_Scroll;

    //最初は非アクティブにして指定　アクティブにすることでメニューや現在装備欄が押せなくなる
    [SerializeField] private GameObject m_menukakushi;
    [SerializeField] private GameObject m_soubirankakushi;

    private Toggle m_kakotggle;

    private void Start()
    {
        for(int i = 0; i < m_itemDataBase.GetItemLists().Count; i++)
        {
            //アイテム装備数を0に
            m_SoubiisoutyakuDictionary.Add(m_itemDataBase.GetItemLists()[i], 0);
        }

        //キャラ装備を取得
        m_Playerkanriscript = m_PlayerkanriObject.GetComponent<MPlayerControllerFencer>();
        //Mplayerdata m_Sousachara = m_Playerkanriscript.Sousacharakoushin();

        m_itemscript = m_itemObject.GetComponent<Mitemkanri>();

        //キャラの装備をなしにする
        //m_Sousachara.Soubi1 = null;
        //m_Sousachara.Soubi2 = null;
        //m_Sousachara.Soubi3 = null;
        //m_Sousachara.Soubi4 = null;
    }

    //現在装備欄の更新
    public void Soubirankoushin()
    {
        //装備変更のどのメソッドの段階にいるのかを数字で指定
        m_soubidankai = 0;

        //現在のキャラを取得
        //Mplayerdata m_Sousachara = m_Playerkanricript.Sousacharakoushin();

        //装備の配列をクリア
        Array.Clear(m_Soubi, 0, m_Soubi.Length);

        //キャラの装備を配列に代入
        //m_Soubi[0] = m_Sousachara.Soubi1;

        if (m_Soubi[0] != null)
        {
            //配列に入れた値がnull以外ならアイテムが装備されている　アイコンをactiveにする　アイコンや名前をMitemdataからとってきて代入
            m_icon1.gameObject.SetActive(true);

            m_itemname1.text = m_Soubi[0].GetItemname();
            m_Icons[0] = m_icon1.GetComponent<Image>();
            m_Icons[0].sprite = m_Soubi[0].GetItemicon();
        }
        else
        {
            //配列に入れた値がnullならアイテムが装備されていない　アイコンを非アクティブに　テキストには空値を代入
            m_icon1.gameObject.SetActive(false);

            m_itemname1.text = "";
            m_Icons[0] = m_icon1.GetComponent<Image>();
            m_Icons[0].sprite = null;
        }

        //m_Soubi[1] = m_Sousachara.Soubi2;

        if (m_Soubi[1] != null)
        {
            //配列に入れた値がnull以外ならアイテムが装備されている　アイコンをactiveにする　アイコンや名前をMitemdataからとってきて代入
            m_icon2.gameObject.SetActive(true);

            m_itemname2.text = m_Soubi[1].GetItemname();
            m_Icons[1] = m_icon1.GetComponent<Image>();
            m_Icons[1].sprite = m_Soubi[1].GetItemicon();
        }
        else
        {
            //配列に入れた値がnullならアイテムが装備されていない　アイコンを非アクティブに　テキストには空値を代入
            m_icon2.gameObject.SetActive(false);

            m_itemname2.text = "";
            m_Icons[1] = m_icon2.GetComponent<Image>();
            m_Icons[1].sprite = null;
        }

        //m_Soubi[2] = m_Sousachara.Soubi3;

        if (m_Soubi[2] != null)
        {
            //配列に入れた値がnull以外ならアイテムが装備されている　アイコンをactiveにする　アイコンや名前をMitemdataからとってきて代入
            m_icon3.gameObject.SetActive(true);

            m_itemname3.text = m_Soubi[2].GetItemname();
            m_Icons[2] = m_icon3.GetComponent<Image>();
            m_Icons[2].sprite = m_Soubi[2].GetItemicon();
        }
        else
        {
            //配列に入れた値がnullならアイテムが装備されていない　アイコンを非アクティブに　テキストには空値を代入
            m_icon3.gameObject.SetActive(false);

            m_itemname3.text = "";
            m_Icons[2] = m_icon3.GetComponent<Image>();
            m_Icons[2].sprite = null;
        }

        //m_Soubi[3] = m_Sousachara.Soubi4;

        if (m_Soubi[3] != null)
        {
            //配列に入れた値がnull以外ならアイテムが装備されている　アイコンをactiveにする　アイコンや名前をMitemdataからとってきて代入
            m_icon4.gameObject.SetActive(true);

            m_itemname4.text = m_Soubi[3].GetItemname();
            m_Icons[3] = m_icon4.GetComponent<Image>();
            m_Icons[3].sprite = m_Soubi[3].GetItemicon();
        }
        else
        {
            //配列に入れた値がnullならアイテムが装備されていない　アイコンを非アクティブに　テキストには空値を代入
            m_icon4.gameObject.SetActive(false);

            m_itemname4.text = "";
            m_Icons[3] = m_icon4.GetComponent<Image>();
            m_Icons[3].sprite = null;
        }
    }

    //現在装備選択処理
    public void Soubiransentakukoushin()
    {
        //装備変更のどのメソッドの段階にいるのかを数字で指定
        m_soubidankai = 1;

        //スクロールビューのゲームオブジェクトをアクティブ化
        m_Scroll.gameObject.SetActive(true);
        //メニュー（アイテムやキャラといった他のボタン）を押されないようにするためのゲームオブジェクトをアクティブ化
        m_menukakushi.gameObject.SetActive(true);

        //スクロールビューのcontentの子ゲームオブジェクトを全て削除してリセットする
        foreach (Transform c in m_content.transform)
        {
            GameObject.Destroy(c.gameObject);
        }

        //選択されているトグル（つまり現在装備スロット）を代入
        Toggle m_tgl = m_togglegroup1.ActiveToggles().FirstOrDefault();

        //このメソッドが呼び出されたのにトグルがnullということは一度選択したトグルを再度選択してキャンセルしたということ
        if (m_tgl == null)
        {
            //1つ前の段階に戻してリターン
            m_Scroll.gameObject.SetActive(false);
            m_menukakushi.gameObject.SetActive(false);
            Soubirankoushin();
            return;
        }

        //選択されているトグルのゲームオブジェクト名を代入　今回は数字の名前のゲームオブジェクトとなっている
        string x = m_tgl.name;

        //Parseにより文字列の数字をint型やfloot型にできる　今回はint型にしてbに代入
        int y = int.Parse(x);

        //操作キャラのdataを取得
        //Mplayerdata m_Sousachara = Platerkanricript.Sousacharakoushin();

        //操作キャラの装備タイプを取得　ゲームオブジェクトの名前によって部位のアイテムタイプをとってくれる
        switch (x)
        {
            case "1":
                //m_Soubitype = m_Sousachara.m_Soubitype1;
                break;
            case "2":
                //m_Soubitype = m_Sousachara.m_Soubitype1;
                break;
            case "3":
                //m_Soubitype = m_Sousachara.m_Soubitype1;
                break;
            case "4":
                //m_Soubitype = m_Sousachara.m_Soubitype1;
                break;
        }

        //装備可能リストのクリア
        m_SoubikanouList.Clear();

        //アイテムのスクリプト（アイテムタイプを送る）を呼んで装備可能リストを取得する
        //m_SoubikanouList = m_itemscript.itemtypelist(Soubitype);

        //ここからスクロールビュー内のコンテンツを作成する
        //選択された現在装備欄のアイテムが存在する場合は「外す」選択用のゲームオブジェクトを制作する（プレハブ使用）
        if (m_Soubi[y - 1] != null)
        {
            //Instantiateを使うことで指定したプレハブ(インスペクター欄でhazusuprefabにプレハブを指定)を使ってゲームオブジェクト作成する
            GameObject m_hazusuchildObject = Instantiate(m_hazusuprefab, transform);
            //作成したゲームオブジェクトをcontentの子ゲームオブジェクトとする
            m_hazusuchildObject.transform.parent = m_content.transform;
            //作成ゲームオブジェクトの名前を-1とする
            m_hazusuchildObject.name = "-1";

            //ここから作成ゲームオブジェクトの位置決めを行う
            //作成したゲームオブジェクトのRectTransformを取得
            RectTransform m_hazusuRectTransform = m_hazusuchildObject.GetComponent<RectTransform>();
            //プレハブはUIでRectTransformとなっており2D情報。よっていつも使っているVector3ではなくVector2へ代入。
            //RectTransformのメンバには「position」と「anchoredPosition」がある。今回はanchoredPositionを使って位置決めを行っているので、anchoredPositionを使う
            Vector2 m_hazusupos = m_hazusuRectTransform.anchoredPosition;

            //作成したい位置を代入
            m_hazusupos.x = 81;
            m_hazusupos.y = 1;

            m_hazusuRectTransform.anchoredPosition = m_hazusupos;

            //作成したゲームオブジェクトのトグルグループとしてcontentのトグルグループをセットする
            m_hazusuchildObject.GetComponent<Toggle>().group = m_content.GetComponent<ToggleGroup>();
        }

        //ここからは装備可能アイテムリストに登録されたアイテム選択用のゲームオブジェクトを作成する
        for(int i=0;i<m_SoubikanouList.Count;i++)
        {
            //プレハブの装備可能アイテムゲームオブジェクトを作成
            GameObject m_childObject = Instantiate(m_yousoprefab, transform);
            m_childObject.transform.parent = m_content.transform;
            //i番の名前にする
            string m_yousomei = (i).ToString();
            m_childObject.name = m_yousomei;

            //プレハブにアタッチしておいたMsoubiyousoスクリプトを取得
            m_soubiyousoscript = m_childObject.GetComponent<Msoubiyouso>();

            //Msoubiyousoスクリプトのメソッドを使って、プレハブで作成したゲームオブジェクトのアイテム名表示textとアイコンを取得しアイテム情報を代入
            TextMeshProUGUI Soubiitemname = m_soubiyousoscript.soubiitemname();
            GameObject Soubiitemicon = m_soubiyousoscript.soubiyousoicon();
            Soubiitemname.text = m_SoubikanouList[i].GetItemname();
            Soubiitemicon.GetComponent<Image>().sprite = m_SoubikanouList[i].GetItemicon();
            Soubiitemicon.GetComponent<Image>().color = new Color(1, 1, 1, 1);

            //ここから作成したゲームオブジェクトの位置調整
            RectTransform m_YousoRectTransform = m_childObject.GetComponent<RectTransform>();
            Vector2 m_pos = m_YousoRectTransform.anchoredPosition;

            //iの数が大きくなるほど作成するゲームオブジェクトのy座標を下にずらす必要がある　今回は-100ずつずらす
            int m_idouryou = i * (-100);

            //外すゲームオブジェクトを作成したどうかでいちが変化する
            if (m_Soubi[y - 1] == null)
            {
                m_pos.x = 81;
                m_pos.y = 1;
            }
            else
            {
                m_pos.x = 81;
                m_pos.y = -49;
            }
            m_pos.y = m_pos.y + m_idouryou;

            m_YousoRectTransform.anchoredPosition = m_pos;

            //作成したゲームオブジェクトのトグルグループとしてcontentのトグルグループをセットする
            m_childObject.GetComponent<Toggle>().group = m_content.GetComponent<ToggleGroup>();

            //作成したゲームオブジェクトのスクリプトから装備中・他のキャラ装備中表示用ゲームオブジェクトを入手
            GameObject m_Soubityu = m_soubiyousoscript.soubityu();
            GameObject m_HokaSoubityu = m_soubiyousoscript.hokasoubityu();

            //アイテムスクリプトから装備可能リストのi番目のアイテムの持っている個数を取得。
            //int m_soubisentakukosuu = itemscript.itemkosuu(SoubikanouList[i]);

            //装備可能リストのi番目のアイテムが増備されている個数を取得
            int e = m_SoubiisoutyakuDictionary[m_SoubikanouList[i]];

            //持っている個数>装備されている個数かどうかで条件分岐
            /*
            if (m_soubisentakukosuu > e)
            {
                //装備可能なのは確定。
                //現在装備欄の選択されたアイテムとi番目のアイテムが同じかどうかで条件分岐

                if (m_Soubi[y - 1] == m_SoubikanouList[i])
                {
                    //同じなら「装備中」ゲームオブジェクトをアクティブにする。「他キャラ装備中」は非アクティブ。
                    m_Soubityu.SetActive(true);
                    m_HokaSoubityu.SetActive(false);
                }
                else
                {
                    //異なるならどちらも非アクティブ。
                    m_Soubityu.SetActive(false);
                    m_HokaSoubityu.SetActive(false);
                }


            }
            else
            {
                //装備するのは無理。
                //現在装備欄の選択されたアイテムとi番目のアイテムが同じかどうかで条件分岐

                if (m_Soubi[y - 1] == m_SoubikanouList[i])
                {
                    //同じなら「装備中」ゲームオブジェクトをアクティブにする。「他キャラ装備中」は非アクティブ。
                    m_Soubityu.SetActive(true);
                    m_HokaSoubityu.SetActive(false);
                }
                else
                {
                    //異なるにもかかわらず装備されている個数を持っている個数が超えられない。つまり他キャラがこのアイテムを装備している。
                    //「装備中」ゲームオブジェクトを非アクティブにする。「他キャラ装備中」はアクティブ。
                    m_Soubityu.SetActive(false);
                    m_HokaSoubityu.SetActive(true);
                }
            }
            */
        }
    }

    //スクロールビュー装備選択処理
    public void Soubiscrollsentaku()
    {
        m_soubidankai = 2;
        //装備の説明ゲームオブジェクトをアクティブにする
        m_Soubisetumei.gameObject.SetActive(true);

        //現在装備選択欄を選択させないために現在装備欄にかぶせる形の透明なゲームオブジェクトをアクティブにする
        m_soubirankakushi.gameObject.SetActive(true);

        //選択されている現在装備トグルを代入
        Toggle m_tgl = m_togglegroup1.ActiveToggles().FirstOrDefault();

        //選択されているトグルのゲームオブジェクト名を代入
        string c = m_tgl.name;

        //Parseにより文字列の数字をint型やfloat型にできる　今回はint型にしてdに代入
        int d = int.Parse(c);

        //選択されているトグル（こっちにはスクロールビューのcontentに配置した子ゲームオブジェクト）を代入
        Toggle m_tgl2 = m_togglegroup2.ActiveToggles().FirstOrDefault(); ;

        //このメソッドが呼び出されたのにm_togl2がnullの場合は選択したトグルを再度選択している　この場合は前の段階に戻してリターン
        if (m_tgl2 == null)
        {
            m_soubirankakushi.gameObject.SetActive(false);
            Soubiransentakukoushin();
            return;
        }

        //選択されているトグルのゲームオブジェクト名を代入
        string x = m_tgl2.name;

        //Parseにより文字列の数字をint型やfloat型にできる　今回はint型にしてyに代入
        int y = int.Parse(x);

        //「外す」ゲームオブジェクト名は-1にしてある。y==-1なら外すゲームオブジェクトが選択されており現在装備欄の選択されているアイテムを外す処理を行う
        if (y == -1)
        {
            m_SoubiisoutyakuDictionary[m_Soubi[d - 1]] -= 1;

            //操作キャラの選択されている現在装備欄に該当するアイテムを外す
            //Mplayerdata m_Sousachara = Playerkanricript.Sousacharakousin();

            switch (d)
            {
                case 1:
                    //m_Sousachara.Soubi1 = null;
                    break;
                case 2:
                    //m_Sousachara.Soubi2 = null;
                    break;
                case 3:
                    //m_Sousachara.Soubi3 = null;
                    break;
                case 4:
                    //m_Sousachara.Soubi4 = null;
                    break;
            }

            //現在装備欄の更新を行う
            Soubirankoushin();

            //contentの子ゲームオブジェクトを全て削除する
            foreach (Transform f in m_content.transform)
            {
                GameObject.Destroy(f.gameObject);
            }

            //現在装備欄で選択されているトグル（つまり現在装備スロット）を代入
            m_tgl = m_togglegroup1.ActiveToggles().FirstOrDefault();
            //選択されているトグルの選択を解除
            m_tgl.isOn = false;

            //ここに来るまでにアクティブにしてきたゲームオブジェクトを非アクティブにして現在装備欄を選択する前の状態に戻す
            m_Soubisetumei.gameObject.SetActive(false);
            m_Scroll.gameObject.SetActive(false);
            m_menukakushi.gameObject.SetActive(false);
            m_soubirankakushi.gameObject.SetActive(false);

            return;
        }

        //ここからは装備可能欄から「外す」以外が選択された場合の処理となる

        //装備可能欄の選択されたアイテムの情報画面制作
        //アイテムの各能力値の前に付ける+の文字を代入
        string m_Plus = "+";

        //作成しておいたアイテムのステータスの前に+をつけ、その文字列を各textに代入して表示する
        //m_ATKKASAN.text = m_Plus + (m_SoubikanouList[y].GetItemATK()).ToString();
        //m_DEFKASAN.text = m_Plus + (m_SoubikanouList[y].GetItemDEF()).ToString();
        //m_INTKASAN.text = m_Plus + (m_SoubikanouList[y].GetItemINT()).ToString();
        //m_RESKASAN.text = m_Plus + (m_SoubikanouList[y].GetItemRES()).ToString();
        //m_AGIKASAN.text = m_Plus + (m_SoubikanouList[y].GetItemAGI()).ToString();

        //ステータス以外の情報も表示
        //m_KYUU.text = (m_SoubikanouList[y].GetSoubiRank()).ToString();
        //m_soubitypehyouzi.text = m_SoubikanouList[y].GetItemtypehyouzi();
        m_soubisetumei.text = m_SoubikanouList[y].GetItemexplanation();

        //装備可能欄のアイテムが選択された後、別のアイテムが再度選択された場合に備えた処理
        //選択してはじめて「装着」の画像(ボタン)が出るのだが前のアイテムの装着ボタンが残っていると困る
        //その対処としてこのメソッドの最後に今選択されている装備可能欄のトグルをkakotoggleに保存している
        //もう一度選択された場合は以下の条件に当てはまることになる
        if (m_kakotggle != null)
        {
            //m_kakotoggleの装備選択欄の装着ボタンを非アクティブにして消す
            m_soubiyousoscript = m_kakotggle.GetComponent<Msoubiyouso>();
            GameObject m_maeSoubisoutyaku = m_soubiyousoscript.soubisoutyaku();
            m_maeSoubisoutyaku.SetActive(false);
        }

        //m_kakotoggleの装備選択欄の装着ボタンを非アクティブにして消す
        m_soubiyousoscript = m_tgl2.GetComponent<Msoubiyouso>();
        GameObject m_Soubisoutyaku = m_soubiyousoscript.soubisoutyaku();

        //装備欄で選択されているアイテムの持っている個数を取得
        //int m_soubisentakukosuu = m_itemscript.itemkosuu(m_SoubikanouList[y]);
        //装備欄で選択されているアイテムの装備されている個数を取得
        int e = m_SoubiisoutyakuDictionary[m_SoubikanouList[y]];

        //持っている個数>装備個数
        m_Soubisoutyaku.SetActive(false);
        /*
        if (m_soubisentakukosuu > e)
        {
            //現在装備欄で選択されているアイテムと装備可能欄で選択されているアイテムが同じではない。
            if (m_Soubi[d - 1] != m_SoubikanouList[y])
            {
                //以上2つの条件を満たした場合にのみ装着ボタンをアクティブにする。
                m_Soubisoutyaku.SetActive(true);
            }
        }
        */
        //装備可能欄で現在選択されているトグルを記憶
        m_kakotggle = m_tgl2;
    }

    //装備装着処理
    public void Soubisousyaku()
    {
        m_soubidankai = 3;

        //選択されているトグルのゲームオブジェクト名を代入
        Toggle m_tgl2 = m_togglegroup2.ActiveToggles().FirstOrDefault();

        //選択されているトグルのゲームオブジェクト名を代入
        string x = m_tgl2.name;

        //Parseにより文字列の数字をint型やfloat型にできる　今回はint型にしてyに代入
        int y = int.Parse(x);

        //装備可能欄に該当する装備可能リストのアイテムの装備数を1増加
        m_SoubiisoutyakuDictionary[m_SoubikanouList[y]] += 1;

        //選択されているトグル（つまり現在装備スロット）を代入
        Toggle m_tgl = m_togglegroup1.ActiveToggles().FirstOrDefault();

        //選択されているトグルのゲームオブジェクト名を代入
        string a = m_tgl.name;

        //Parseにより文字列の数字をint型やfloat型にできる　今回はint型にしてbに代入
        int b = int.Parse(a);

        //現在装備欄にアイテムがある場合
        if (m_Soubi[b - 1] != null)
        {
            //現在装備欄のアイテムの装備数を1減らす
            m_SoubiisoutyakuDictionary[m_Soubi[b - 1]] -= 1;
        }

        //操作キャラを取得。
        //Mplayerdata m_Sousachara = Playerkanricript.Sousacharakoushin();

        //現在装備欄に該当する操作キャラの装備アイテムに装備可能欄で選択していたアイテムを指定

        switch (b)
        {
            case 1:
                //m_Sousachara.Soubi1 = m_SoubikanouList[y];
                break;
            case 2:
                //m_Sousachara.Soubi2 = m_SoubikanouList[y];
                break;
            case 3:
                //m_Sousachara.Soubi3 = m_SoubikanouList[y];
                break;
            case 4:
                //m_Sousachara.Soubi4 = m_SoubikanouList[y];
                break;
        }

        //ここから現在装備欄選択前に戻す処理
        cancel();

    }

    //装備キャンセル処理（現在装備選択前に戻る）
    public void cancel()
    {
        //現在装備欄を更新
        Soubirankoushin();

        //contentの子ゲームオブジェクトを全削除
        foreach(Transform c in m_content.transform)
        {
            GameObject.Destroy(c.gameObject);
        }
        //選択されているトグル（つまり現在装備スロット）を代入
        Toggle m_tgl = m_togglegroup1.ActiveToggles().FirstOrDefault();
        //選択されているトグルの選択を解除
        m_tgl.isOn = false;

        //これまでにアクティブ化したゲームオブジェクトを非アクティブに
        m_Soubisetumei.gameObject.SetActive(false);
        m_Scroll.gameObject.SetActive(false);
        m_menukakushi.gameObject.SetActive(false);
        m_soubirankakushi.gameObject.SetActive(false);
    }

    //装備状態返し
    public int soubizyoutaikaeshi()
    {
        return m_soubidankai;
    }

    //アイテム装備個数返し
    public int soubikosuukaeshi(Mitemdata soubihaaku)
    {
        int m_soubityukosuu = m_SoubiisoutyakuDictionary[soubihaaku];
        return m_soubityukosuu;
    }

}
