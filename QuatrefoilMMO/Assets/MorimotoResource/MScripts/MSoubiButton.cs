using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MSoubiButton : MonoBehaviour,
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler
{

    [SerializeField] GameObject ActiveObject;

    // 押す  
    public void OnPointerClick(PointerEventData eventData)
    {
        ActiveObject.gameObject.SetActive(true);
    }
    // 押されたまま
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    // 押した後放した 
    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
