using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptBaseHealth : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected Slider healthBar;
    [SerializeField] protected GameObject healthPopup;

    public virtual void Reset()
    {
        healthPopup = Resources.Load<GameObject>("prefabs/LoseHealthPopup");
    }
    void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    public void TakeDamage(int damage) // nhận sát thương
    {
        healthBar.value -= damage;
        GameObject popup = Instantiate(healthPopup, transform.position, Quaternion.identity, GameObject.Find("CanvasPopup").transform);
        popup.GetComponent<Text>().text = damage.ToString();

    }

    public bool isDead() => healthBar.value <= 0; // máu ít hơn 0 thì chết
}
