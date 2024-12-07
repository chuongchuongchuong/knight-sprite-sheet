using UnityEngine;
using UnityEngine.UI;

public class ScriptHealth1 : ScriptBaseHealth
{
    public override void Reset()
    {
        base.Reset();
        maxHealth = 60;
        healthBar = GameObject.Find("HealthBar1").GetComponent<Slider>();
    }
}
