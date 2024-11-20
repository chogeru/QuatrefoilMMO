using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMenutyousei : MonoBehaviour
{
    [SerializeField]
    private GameObject m_menuObj;
    //Menuが開かれているか
    bool m_isMunuOn = false;

    private void Update()
    {
        if (m_isMunuOn == false)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                m_menuObj.gameObject.SetActive(true);
                m_isMunuOn = true;
            }
        }
        else
        {
            if (Input.GetButtonDown("Cancel"))
            {
                m_menuObj.gameObject.SetActive(false);
                m_isMunuOn = false;
            }
        }
    }

}
