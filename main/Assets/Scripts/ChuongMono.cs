using System;
using UnityEngine;

public abstract class ChuongMono<T> : MonoBehaviour where T : ChuongMono<T>
{
    public static T Instance { get; private set; }
    protected virtual void Reset()
    {
        LoadObjects();
        LoadComponent();
    }

    protected virtual void Awake()
    {
        GuaranteeSingleton();
        GetScriptableDataValue();
        return;
        
        void GuaranteeSingleton()
        {
            if (Instance != null && Instance != (T)this)
            {
                Debug.LogWarning("More than one " + GetType().Name + " in scene.");
                return;
            }

            Instance = (T)this;
        }
    }
    
    
    // @formatter:off
    protected virtual void LoadComponent(){}// Chuyên để load Component
    protected virtual void LoadObjects(){}//Load các loại Object: GameObject, Prefabs,...
    protected virtual void GetScriptableDataValue(){}// lấy giá trị biến trong Scriptable Data
    
    // @formatter:on
}