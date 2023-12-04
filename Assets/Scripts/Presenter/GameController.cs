using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private void OnEnable()
    {
        ServiceLocator.Init();
        ServiceLocator.Instance.Register(new EventBus());
    }
    private void OnDisable()
    {
        ServiceLocator.Instance.Unregister(new EventBus());
    }
}
