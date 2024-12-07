using UnityEngine;

public class ScriptBulletWay : MonoBehaviour
{
    [SerializeField] private int speed = 10;
    [SerializeField] private int damage = 15;

    [SerializeField] private Transform transform2;
    [SerializeField] private ScriptHealth1 scriptHealth1;
   
    public GameObject boom;
    private void Reset()
    {
        transform2 = GameObject.Find("Player2: Dragon").transform;
        scriptHealth1 = GameObject.Find("Health1").GetComponent<ScriptHealth1>();
        boom = Resources.Load<GameObject>("prefabs/explosion_02");
    }
    // Start is called before the first frame update
    private void Start()
    {
        if (transform2.localScale.x > 0) GetComponent<SpriteRenderer>().flipX = true;
    }
    private void Update()
    {
        transform.Translate( speed * transform2.localScale.x * Time.deltaTime*Vector2.left);
    }

    public void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.name == "Player1: knight")
        {
            var temp = Instantiate(boom, transform.position, Quaternion.identity);
            scriptHealth1.TakeDamage(damage);

            Destroy(gameObject);
            Destroy(temp, .7f);

        }

        /*private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject);
        }*/


    }
}
