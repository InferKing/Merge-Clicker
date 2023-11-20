using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    private readonly Dictionary<string, IService> _services = new();
    public static ServiceLocator Instance { get; private set; }
    public static void Init()
    {
        Instance = new ServiceLocator();
    }
    /// <summary>
    /// ��������� ������� ������� ����
    /// </summary>
    /// <typeparam name="T">��� �������</typeparam>
    /// <returns>���������� ������ ������� ����</returns>
    /// <exception cref="System.InvalidOperationException"></exception>
    public T Get<T>() where T : IService
    {
        string key = typeof(T).Name;
        if (!_services.ContainsKey(key))
        {
            Debug.LogError($"{key} not registered with {GetType().Name}");
            throw new System.InvalidOperationException();
        }
        return (T)_services[key];
    }
    /// <summary>
    /// ������������ ������ � ������ ��������
    /// </summary>
    /// <typeparam name="T">��� ������� (�������)</typeparam>
    /// <param name="service">������</param>
    public void Register<T>(T service) where T : IService
    {
        string key = typeof(T).Name;
        if (_services.ContainsKey(key))
        {
            Debug.LogError($"Attempted to register service of type {key}" +
                $"which is already registered with the {GetType().Name}.");
            throw new System.InvalidOperationException();
        }
        _services.Add(key, service);
    }
    /// <summary>
    /// ������� ������ �� ������ ��������
    /// </summary>
    /// <typeparam name="T">��� ������� (�������)</typeparam>
    /// <param name="service">������</param>
    public void Unregister<T>(T service) where T : IService
    {
        string key = typeof(T).Name;
        if (!_services.ContainsKey(key))
        {
            Debug.LogError($"Attempted to unregister service of type {key}" +
                $"which is not registered with the {GetType().Name}.");
            throw new System.InvalidOperationException();
        }
        _services.Remove(key);
    }
}
