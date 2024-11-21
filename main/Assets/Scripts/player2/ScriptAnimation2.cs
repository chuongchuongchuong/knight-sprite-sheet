using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimation2 : MonoBehaviour
{
    public int state;
    //0:Idle, 1:Run

    private Animator anim;
    private ScriptMovement2 ScriptMovement2;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        ScriptMovement2 = GetComponentInParent<ScriptMovement2>();
    }
    // Start is called before the first frame update
    void Start()
    {





    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 0:
                if (ScriptMovement2.moveInput.x != 0) state = 1;// đang đứng yên thành walk
                if (Input.GetKeyDown(KeyCode.N))
                {
                    anim.SetTrigger("Breathefire");
                    state = 2;
                    Invoke("ToIdle", .8f);
                }

                break;
            case 1:
                if (ScriptMovement2.moveInput.x == 0) state = 0;// đang chạy thành đứng yên
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
