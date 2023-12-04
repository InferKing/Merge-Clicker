using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Model: MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private List<Cell> _cells = new();
    public void Awake() 
    { 
        
    }
}
