using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFiring : MonoBehaviour
{
    public GameObject bullet;
    private Transform transform2;

    private void Awake()
    {
        transform2 = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform2.localScale.x > 0 && Input.GetKeyDown(KeyCode.Z))
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 180, 0));
        else if (transform2.localScale.x < 0 && Input.GetKeyDown(KeyCode.Z))
            Instantiate(bullet, transform.position, transform.rotation);
        
        //if (Input.GetKeyDown(KeyCode.Z)) Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 180));
    }

}
