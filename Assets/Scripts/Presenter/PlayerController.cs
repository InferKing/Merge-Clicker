using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _maxDistRay = 50f;
    [SerializeField] private LayerMask _layerToUse;
    private EventBus _bus;
    private RaycastHit _hit;
    private void Start()
    {
        _bus = ServiceLocator.Instance.Get<EventBus>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out _hit, _maxDistRay, _layerToUse))
            {
                _bus.Invoke(new UnitPickedSignal(_hit.collider.GetComponent<BaseUnit>()));
            }
        }
    }
}
