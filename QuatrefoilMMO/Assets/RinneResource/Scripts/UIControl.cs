using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    [SerializeField,Header("表示するUI")]
    private GameObject m_image;
    //パラメータ
    private EnemyParameters m_ep;
    //経過時間
    private float m_elapsedtime;
    [SerializeField,Header("UIの表示時間")]
    private float m_cooltime = 2.0f;
    void Start()
    {
        m_ep = GetComponentInParent<EnemyParameters>();
    }

    
    void Update()
    {
        
        if (!m_ep.m_parameters.IsFlag)
        {
            //表示されているなら非表示に変更
            if(m_image.activeSelf)
            {
                m_image.SetActive(false);
            }
            m_elapsedtime = 0;
        }
        else
        {
            if (m_image.activeSelf && m_elapsedtime > m_cooltime)
            {
                m_image.SetActive(false);
            }

            if (!m_image.activeSelf && m_elapsedtime < m_cooltime)
            {
                m_image.SetActive(true);
            }

            m_elapsedtime += Time.deltaTime;
        }
    }
}
