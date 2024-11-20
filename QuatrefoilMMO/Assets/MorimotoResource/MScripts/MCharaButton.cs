using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MCharaButton : MonoBehaviour,
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler
{

    [SerializeField] GameObject ActiveObject;

    // ‰Ÿ‚·  
    public void OnPointerClick(PointerEventData eventData)
    {
        ActiveObject.gameObject.SetActive(true);
    }
    // ‰Ÿ‚³‚ê‚½‚Ü‚Ü
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    // ‰Ÿ‚µ‚½Œã•ú‚µ‚½ 
    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
