using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MPUI : MonoBehaviour
{
    [SerializeField]
    private Mplayerdata m_playerdata;
    [SerializeField]
    private TextMeshProUGUI m_NAME;
    [SerializeField]
    private TextMeshProUGUI m_LV;

    private void Update()
    {
        string m_charaname = m_playerdata.NAME;
        int m_lv = m_playerdata.LV;

        m_NAME.text = m_charaname;
        string m_lvtext = ($"LV{m_lv}");
        m_LV.text = m_lvtext;
    }
}
