using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFiring : MonoBehaviour
{
    int coolDownTime = 2;
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
        if (Time.time - lastShot > coolDownTime)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Instantiate(bullet, transform.position, transform.rotation);
                lastShot = Time.time;
            }
        }
    }

}
