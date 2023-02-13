using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    private void OnEnable()
    {
       // MyEvent.OnMyEvent += HandleEvent();
    }

    private void OnDisable()
    {
      //  MyEvent.OnMyEvent -= HandleEvent();
    }

    void HandleEvent()
    {

    }


}
