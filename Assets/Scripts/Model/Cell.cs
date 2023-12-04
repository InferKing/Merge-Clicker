using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellState
{
    Empty,
    Hover,
    Busy
}
/// <summary>
/// Пока просто тестирую работу, не обращай внимание на эту парашу
/// </summary>
[RequireComponent(typeof(MeshRenderer))]
public class Cell : MonoBehaviour
{
    [SerializeField] private CellState _state;
    [SerializeField] private Material[] _mats;
    private MeshRenderer _meshRenderer;
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnMouseOver()
    {
        if (_state is CellState.Empty)
        {
            _state = CellState.Hover;
            _meshRenderer.material = _mats[1];
        }
    }
    private void OnMouseExit()
    {
        if (_state is CellState.Hover) 
        {
            _state = CellState.Empty;
            _meshRenderer.material = _mats[0];
        }
    }
}
