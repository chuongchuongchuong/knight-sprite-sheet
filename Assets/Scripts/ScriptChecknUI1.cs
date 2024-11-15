using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptChecknUI1 : MonoBehaviour
{
    public bool blockMove = false; // biến để khóa không cho di chuyển
    public bool checkWin = false;

    private ScriptAnimation1 scriptAnimation;
    public Slider healthBar1;
    //private Animator anim;

    private void Awake()
    {
        scriptAnimation = GetComponent<ScriptAnimation1>();
        healthBar1 = GameObject.Find("HealthBar1").GetComponent<Slider>();
        //anim = GetComponent<Animator>();
    }

    public bool IsDead() // nếu hết màu thì chết
    {
        if (healthBar1.value == 0) return true;
        else return false;
    }    
}
