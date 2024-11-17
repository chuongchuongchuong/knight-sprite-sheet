using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScriptHealth1 : MonoBehaviour
{
    private int maxHealth = 50;
    private Slider healthBar;

    private void Awake()
    {
        healthBar = GameObject.Find("HealthBar1").GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

    }

    public void TakeDamage(float damage)
    {
        healthBar.value -= damage;
    }

    public bool isDead()
    {
        if (healthBar.value <= 0) return true;
        else return false;
    }
}
