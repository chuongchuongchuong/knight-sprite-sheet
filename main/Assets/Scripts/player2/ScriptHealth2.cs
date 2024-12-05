using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptHealth2 : ScriptBaseHealth
{
    public override void Reset()
    {
        base.Reset();
        maxHealth = 50;
        healthBar = GameObject.Find("HealthBar2").GetComponent<Slider>();
    }
}
