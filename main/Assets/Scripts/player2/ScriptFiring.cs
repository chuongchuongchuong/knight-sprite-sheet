using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFiring : MonoBehaviour
{
    float coolDownTime = 1f;
    float lastShot;

    public GameObject bullet;
    private Transform transform2;

    private void Awake()
    {
        transform2 = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastShot > coolDownTime && /*Input.GetKeyDown(KeyCode.Keypad1)*/Input.GetKeyDown(KeyCode.N))
        {
            GameObject temp = Instantiate(bullet, transform.position, Quaternion.identity);
            lastShot = Time.time;
            Destroy(temp, .7f);// đạn sẽ chỉ di chuyển được khoảng cách trong 0,7s
        }
    }

}
