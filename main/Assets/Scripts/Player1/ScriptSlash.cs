using UnityEngine;
using UnityEngine.Serialization;

public class ScriptSlash : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    [SerializeField] private BoxCollider2D boxCollider;
    [FormerlySerializedAs("scriptHealth2")] [SerializeField] private DragonHealth dragonHealth;
    [SerializeField] private ScriptAnimation1 scriptAnimation1;

    private void Reset()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        dragonHealth = GameObject.Find("Player2: Dragon").GetComponentInChildren<DragonHealth>();
        //scriptAnimation1 = transform.parent.GetComponentInChildren<ScriptAnimation1>();
    }

    private void Start()
    {
        boxCollider.enabled = false;
    }

    private void Slash()
    {
        boxCollider.enabled = true;
    }
    private void UnSlash()
    {
        boxCollider.enabled = false;
    }

    public void Attack()
    {
        Slash(); // bật vùng tấn công lên
        Invoke(nameof(UnSlash), .5f); // tắt vùng tấn công đi

    }
    
    public void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.name == "Player2: Dragon")
        {
            dragonHealth.TakeDamage(damage);
        }
    }

}
