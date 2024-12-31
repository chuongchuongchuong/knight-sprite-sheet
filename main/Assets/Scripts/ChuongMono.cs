using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public abstract class ChuongMono : MonoBehaviour
{
    protected virtual void Reset()
    {
        LoadObjects();
        LoadComponent();
    }

    protected virtual void Awake()
    {
        GuaranteeSingleton();
        GetScriptableDataValue();
    }
    
    
    // @formatter:off
    protected virtual void GuaranteeSingleton(){}//Dành cho ChuongMonoSingleton override vào
    protected virtual void LoadComponent(){}// Chuyên để load Component
    protected virtual void LoadObjects(){}//Load các loại Object: GameObject, Prefabs,...
    protected virtual void GetScriptableDataValue(){}// lấy giá trị biến trong Scriptable Data
    // @formatter:on
}