using UnityEngine;
using UnityEngine.UI;

public class DragonHealth : BaseHealth<DragonHealth>
{
    protected override void LoadComponent()
    {
        healthBar = GameObject.Find("HealthBar2").GetComponent<Slider>();
    }

    protected override void GetScriptableDataValue()
    {
        var takeData = Resources.Load<CharactorData>("Data/Dragon");
        maxHealth = takeData.maxHealth;
    }
}