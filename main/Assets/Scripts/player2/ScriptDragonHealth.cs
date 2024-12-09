using UnityEngine;
using UnityEngine.UI;

public class ScriptDragonHealth : ScriptBaseHealth
{
    public override void Reset()
    {
        base.Reset();
        charactorData=Resources.Load<CharactorData>("HealthOfDragon");
        healthBar = GameObject.Find("HealthBar2").GetComponent<Slider>();
    }
}
