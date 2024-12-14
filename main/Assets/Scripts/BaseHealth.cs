using UnityEngine;
using UnityEngine.UI;

public abstract class BaseHealth<T> : ChuongMono<T> where T : BaseHealth<T>
{
    protected int maxHealth;

    [SerializeField] protected Slider healthBar;
    [SerializeField] protected GameObject loseHealthPopup;
    [SerializeField] protected GameObject healHealthPopup;

    protected override void LoadObjects()
    {
        loseHealthPopup = Resources.Load<GameObject>("prefabs/LoseHealthPopup");
        healHealthPopup = Resources.Load<GameObject>("prefabs/HealHealthPopup");
    }

    protected virtual void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    public void TakeDamage(int damage) // nhận sát thương
    {
        healthBar.value -= damage;
        var popup = Instantiate(loseHealthPopup, transform.position, Quaternion.identity,
            GameObject.Find("CanvasPopup").transform);
        popup.GetComponent<Text>().text = damage.ToString();
    }
    
    public void HealHealth(int healDamage) // Hồi máu
    {
        healthBar.value += healDamage;
        var popup = Instantiate(healHealthPopup, transform.position, Quaternion.identity,
            GameObject.Find("CanvasPopup").transform);
        popup.GetComponent<Text>().text = healDamage.ToString();
    }

    public bool IsDead() => (healthBar.value <= 0); // máu ít hơn 0 thì chết
}