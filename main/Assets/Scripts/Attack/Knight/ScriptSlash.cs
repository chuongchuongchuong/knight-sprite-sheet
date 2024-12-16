using UnityEngine;
using UnityEngine.Serialization;

public class ScriptSlash : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    [SerializeField] private BoxCollider2D boxCollider;

    private void Reset()
    {
        boxCollider = GetComponent<BoxCollider2D>();
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
            DragonHealth.Instance.TakeDamage(damage);
        }
    }

}
