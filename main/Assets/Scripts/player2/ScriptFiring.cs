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
        if (Input.GetKeyDown(KeyCode.Z))
            Instantiate(bullet, transform.position, transform.rotation);
    }

}
