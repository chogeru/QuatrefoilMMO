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
    //Playeriti Playerkanricript;

    //アイテム管理ゲームオブジェクトを指定
    [SerializeField]
    private GameObject m_itemObject;
    private Mitemkanri m_itemscript;

    //外すスロット用プレハブと装備可能スロット用プレハブを指定





}
