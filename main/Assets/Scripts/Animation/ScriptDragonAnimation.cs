using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDragonAnimation : ChuongMono<ScriptDragonAnimation>
{
    public int state;
    //0:Idle, 1:Run

    [SerializeField] private Animator anim;

    protected override void LoadComponent()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        switch (state)
        {
            case 0:
                if (ScriptDragonMovement.Instance.moveX != 0) state = 1;// đang đứng yên thành walk
                if (Input.GetKeyDown(KeyCode.N))
                {
                    anim.SetTrigger("Breathefire");
                    state = 2;
                    Invoke("ToIdle", .8f);
                }

                break;
            case 1:
                if (ScriptDragonMovement.Instance.moveX == 0) state = 0;// đang chạy thành đứng yên
                if (Input.GetKeyDown(KeyCode.N))
                {
                    anim.SetTrigger("Breathefire");
                    state = 2;
                    Invoke("ToIdle", .8f);
                }

                break;
        }


        anim.SetInteger("state", state);
    }

    void ToIdle()
    {
        state = 0;
    }
}
