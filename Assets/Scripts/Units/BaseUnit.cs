using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitState 
{ 
    Idle,
    Move,
    Attack,
    Dead
}
public interface IHealth
{
    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }
    void UpdateHealth(float health);
}
public interface IObserverUnit
{
    void UpdateTarget(BaseUnit target);
}
public interface IObservable
{
    void AddObserver(IObserverUnit observer);
    void RemoveObserver(IObserverUnit observer);
    void NotifyAllObservers();
}
public abstract class BaseUnit : MonoBehaviour, IHealth, IObserverUnit
{
    [SerializeField] private Animator _animator;
    protected BaseUnit targetUnit;
    protected UnitState state;
    protected float speed;
    public float MaxHealth { get; set; } = 0;
    public float CurrentHealth { get; set; } = 0;
    public void UpdateTarget(BaseUnit targetUnit)
    {
        this.targetUnit = targetUnit;
    }
    public void UpdateHealth(float health)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - health, 0, MaxHealth);
        if (CurrentHealth < float.Epsilon)
        {
            state = UnitState.Dead;
            UpdateAnimator();
        }
    }
    private void UpdateAnimator()
    {
        _animator.SetBool(state.ToString(), state is UnitState.Idle);
        _animator.SetBool(state.ToString(), state is UnitState.Move);
        _animator.SetBool(state.ToString(), state is UnitState.Attack);
        _animator.SetBool(state.ToString(), state is UnitState.Dead);
    }
}
