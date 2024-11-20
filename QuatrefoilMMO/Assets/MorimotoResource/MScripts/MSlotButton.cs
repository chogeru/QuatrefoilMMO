using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MSlotButton : MonoBehaviour,
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    [SerializeField]
    private GameObject m_itemkanri;

    private Mitemkanri m_itemscript;

    private void Start()
    {
        m_itemscript = m_itemkanri.GetComponent<Mitemkanri>();
    }

    // 押す  
    public void OnPointerClick(PointerEventData eventData)
    {

        m_itemscript.slotkoushin();

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
