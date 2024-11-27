using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UIを使用するので記述
using UnityEngine.UI;

public class MCharasGaugemuki : MonoBehaviour
{
    [SerializeField]
    private Canvas m_canvas;

    private void Update()
    {
        //charagaugeをMainCameraへ向かせる
        m_canvas.transform.rotation = Camera.main.transform.rotation;
    }
}
