using System.Collections;
using System.Collections.Generic;
using UniGLTF.Extensions.VRMC_vrm;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    [SerializeField]
    private int mokuhyou;

    [SerializeField]
    private Text m_text;

    [SerializeField]
    private GameObject m_textobject;

    void Update()
    {
        if(0 >= mokuhyou)
        {
            // m_textobject.SetActive(true);
            SceneManager.LoadScene("ResultScene");
        }

        m_text.text = "残り" + mokuhyou.ToString();
    }

    public void Addcnt()
    {
        mokuhyou--; 
    }

}
