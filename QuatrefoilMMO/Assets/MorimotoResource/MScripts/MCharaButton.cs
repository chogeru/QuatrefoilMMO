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

    // ����  
    public void OnPointerClick(PointerEventData eventData)
    {
        ActiveObject.gameObject.SetActive(true);
    }
    // �����ꂽ�܂�
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    // ������������� 
    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
