using DG.Tweening.Core.Enums;
using UnityEngine;
using UnityEngine.UI;

public class KnightHealth : BaseHealth<KnightHealth>
{
    protected override void LoadComponent()
    {
        healthBar = GameObject.Find("HealthBar1").GetComponent<Slider>();
    }

    protected override void GetScriptableDataValue()
    {
        var takeData = Resources.Load<CharactorData>("Data/Knight");
        maxHealth = takeData.maxHealth;
    }
}