using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPrefabWeapon : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public Transform firepoint;
    private Transform player1;


    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.localScale.x == 1 && Input.GetKeyDown(KeyCode.Z))
            Instantiate(bulletPrefabs, firepoint.position, firepoint.rotation);
        if (player1.localScale.x == -1 && Input.GetKeyDown(KeyCode.Z))
            Instantiate(bulletPrefabs, firepoint.position, Quaternion.Euler(0, 0, 180));
    }

}
