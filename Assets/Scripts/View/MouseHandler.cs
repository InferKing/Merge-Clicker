using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    private EventBus _bus;
    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
        _bus.Subscribe<UnitPickedSignal>(OnUnitPicked);
    }
    private void OnUnitPicked(UnitPickedSignal signal)
    {
    
    }
    private void OnDestroy()
    {
        
    }
}
