using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class MitemButton : MonoBehaviour,
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    [SerializeField]
    private GameObject m_ActiveObject;
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


        m_ActiveObject.gameObject.SetActive(true);
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
