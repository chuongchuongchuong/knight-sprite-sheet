using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptHealth2 : MonoBehaviour
{
    private int maxHealth = 70;
    private Slider healthBar;

    private void Awake()
    {
        healthBar = GameObject.Find("HealthBar2").GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

    }

    public void TakeDamage(int damage)
    {
        healthBar.value -= damage;
    }

    public bool isDead()
    {
        if (healthBar.value <= 0) return true;
        else return false;
    }
}
