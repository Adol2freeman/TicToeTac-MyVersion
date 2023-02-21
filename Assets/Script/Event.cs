using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event : MonoBehaviour
{
    public UnityEvent Exchange;

    public void NowExchange()
    {
        Exchange.Invoke();
    }
}
