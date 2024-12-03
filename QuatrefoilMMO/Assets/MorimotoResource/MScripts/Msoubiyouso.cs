using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Msoubiyouso : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_Soubiitemname;
    [SerializeField] private GameObject m_SoubiIcon;
    [SerializeField] private GameObject m_Soubisoutyaku;
    [SerializeField] private GameObject m_Soubityu;
    [SerializeField] private GameObject m_Hokasoubityu;

    public TextMeshProUGUI soubiitemname()
    {
        return m_Soubiitemname;
    }

    public GameObject soubiyousoicon()
    {
        return m_SoubiIcon;
    }

    public GameObject soubisoutyaku()
    {
        return m_Soubisoutyaku;
    }

    public GameObject soubityu()
    {
        return m_Soubityu;
    }

    public GameObject hokasoubityu()
    {
        return m_Hokasoubityu;
    }
}
