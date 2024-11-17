using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDestroy : MonoBehaviour
{
    public Animator anim;
    private ScriptHealth1 scriptHealth1;
    private int damage=10;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        scriptHealth1 = GameObject.Find("Player1: knight").GetComponentInChildren<ScriptHealth1>();
    }
    public void ClearBoom()
    {
        scriptHealth1.TakeDamage(damage);
        Destroy(gameObject);
    }


}
