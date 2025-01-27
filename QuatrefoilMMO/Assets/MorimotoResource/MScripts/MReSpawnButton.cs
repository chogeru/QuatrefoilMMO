using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MReSpawnButton : MonoBehaviour,
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    [SerializeField]
    private GameObject m_Player;
    [SerializeField]
    private GameObject m_ReSpawn;
    [SerializeField]
    private MMenutyousei m_MMenutyousei;
    private void Start()
    {
        //m_itemscript = m_itemkanri.GetComponent<Mitemkanri>();
    }

    // 押す  
    public void OnPointerClick(PointerEventData eventData)
    {


        m_Player.transform.position = m_ReSpawn.transform.position;
        //m_itemscript.slotkoushin();
        m_MMenutyousei.Off();
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
