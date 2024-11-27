using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MPlayrsStats : MonoBehaviour
{
    [SerializeField]
    private Mplayerdata m_playerdata;

    [SerializeField] private TextMeshProUGUI m_PlayerMAXHP;
    [SerializeField] private TextMeshProUGUI m_PlayerMAXMP;
    [SerializeField] private TextMeshProUGUI m_PlayerATK;
    [SerializeField] private TextMeshProUGUI m_PlayerDEF;
    [SerializeField] private TextMeshProUGUI m_PlayerINT;
    [SerializeField] private TextMeshProUGUI m_PlayerRES;
    [SerializeField] private TextMeshProUGUI m_PlayerAGI;

    private void Update()
    {
        //最大のHP処理
        m_playerdata.PlayerMAXHP = (m_playerdata.GrowMAXHP * (m_playerdata.LV - 1)) + m_playerdata.FirstMAXHP;

        //最大のMP処理
        m_playerdata.PlayerMAXMP = (m_playerdata.GrowMAXMP * (m_playerdata.LV - 1)) + m_playerdata.FirstMAXMP;

        //ATK処理
        m_playerdata.PlayerATK = (m_playerdata.GrowATK * (m_playerdata.LV - 1)) + m_playerdata.FirstATK;

        //DEF処理
        m_playerdata.PlayerDEF = (m_playerdata.GrowDEF * (m_playerdata.LV - 1)) + m_playerdata.FirstDEF;

        //INT処理
        m_playerdata.PlayerINT = (m_playerdata.GrowINT * (m_playerdata.LV - 1)) + m_playerdata.FirstINT;

        //RES処理
        m_playerdata.PlayerRES = (m_playerdata.GrowRES * (m_playerdata.LV - 1)) + m_playerdata.FirstRES;

        //AGI処理
        m_playerdata.PlayerAGI = (m_playerdata.GrowAGI * (m_playerdata.LV - 1)) + m_playerdata.FirstAGI;

        string m_playerMAXHP = ($"HP {m_playerdata.PlayerMAXHP}");
        string m_playerMAXMP = ($"MP {m_playerdata.PlayerMAXMP}");
        string m_playerATK = ($"MP {m_playerdata.PlayerATK}");
        string m_playerDEF = ($"MP {m_playerdata.PlayerDEF}");
        string m_playerINT = ($"MP {m_playerdata.PlayerINT}");
        string m_playerRES = ($"MP {m_playerdata.PlayerRES}");
        string m_playerAGI = ($"MP {m_playerdata.PlayerAGI}");

        m_PlayerMAXHP.text = m_playerMAXHP;
        m_PlayerMAXMP.text = m_playerMAXMP;
        m_PlayerATK.text = m_playerATK;
        m_PlayerDEF.text = m_playerDEF;
        m_PlayerINT.text = m_playerINT;
        m_PlayerRES.text = m_playerRES;
        m_PlayerAGI.text = m_playerAGI;
    }
}
