using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MUI : MonoBehaviour
{
    [SerializeField]
    private Mcharadata m_charadata;
    [SerializeField]
    private TextMeshProUGUI m_NAME;
    [SerializeField]
    private TextMeshProUGUI m_LV;

    private void Update()
    {
        string m_charaname = m_charadata.NAME;
        int m_lv = m_charadata.LV;

        m_NAME.text = m_charaname;
        string m_lvtext = ($"LV{m_lv}");
        m_LV.text = m_lvtext;
    }
}
