using DG.Tweening.Core.Enums;
using UnityEngine;
using UnityEngine.UI;

public class ScriptKnightHealth : ScriptBaseHealth
{
    public override void Reset()
    {
        base.Reset();
        charactorData=Resources.Load<CharactorData>("HealthOfKnight");
        healthBar = GameObject.Find("HealthBar1").GetComponent<Slider>();
    }
}
