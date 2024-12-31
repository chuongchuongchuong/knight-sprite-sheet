using System;
using UnityEngine;

public abstract class ChuongMonoSingleton<T> : ChuongMono where T : ChuongMonoSingleton<T>
{
    public static T Instance { get; private set; }

    protected override void GuaranteeSingleton()
    {
        if (Instance != null && Instance != (T)this)
        {
            Debug.LogWarning("More than one " + GetType().Name + " in scene.");
            return;
        }

        Instance = (T)this;
    }
}