using UnityEngine;

public class ScriptFiring : MonoBehaviour
{
    private readonly float coolDownTime = 1f;
    private float lastShot;

    [SerializeField] public GameObject bulletPrefabs;
    

    private void Reset()
    {
        bulletPrefabs = Resources.Load<GameObject>("prefabs/fireball_01");
    }
    
    private void Update()
    {
        if (Time.time - lastShot > coolDownTime && /*Input.GetKeyDown(KeyCode.Keypad1)*/Input.GetKeyDown(KeyCode.N))
        {
            var bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            lastShot = Time.time;
            Destroy(bullet, .7f);// đạn sẽ chỉ di chuyển được khoảng cách trong 0,7s
        }
    }

}
