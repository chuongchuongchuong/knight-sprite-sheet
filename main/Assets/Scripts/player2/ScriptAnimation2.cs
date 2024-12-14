using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimation2 : MonoBehaviour
{
    public int state;
    //0:Idle, 1:Run

    private Animator anim;
    private ScriptDragonMovement scriptDragonMovement;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        scriptDragonMovement = GetComponentInParent<ScriptDragonMovement>();
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
                if (scriptDragonMovement.moveX != 0) state = 1;// đang đứng yên thành walk
                if (Input.GetKeyDown(KeyCode.N))
                {
                    anim.SetTrigger("Breathefire");
                    state = 2;
                    Invoke("ToIdle", .8f);
                }

                break;
            case 1:
                if (scriptDragonMovement.moveX == 0) state = 0;// đang chạy thành đứng yên
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
