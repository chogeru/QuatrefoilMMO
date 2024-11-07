using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MColliderCallReceiver : MonoBehaviour
{
    public class TriggerEvent : UnityEvent<Collider> { }
    public TriggerEvent TriggerEnterEvent = new TriggerEvent();
    public TriggerEvent TriggerStayEvent = new TriggerEvent();
    public TriggerEvent TriggerExitEvent = new TriggerEvent();

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnterEvent?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        TriggerStayEvent?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerExitEvent?.Invoke(other);
    }
}
