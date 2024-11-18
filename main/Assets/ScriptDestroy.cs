using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDestroy : MonoBehaviour
{
    public Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void ClearBoom()
    {
        Destroy(gameObject);
    }


}
