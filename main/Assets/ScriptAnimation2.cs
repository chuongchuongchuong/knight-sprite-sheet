using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimation2 : MonoBehaviour
{
    public int state;

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

                break;
            case 1:
                if (ScriptMovement2.moveInput.x == 0) state = 0;// đang chạy thành đứng yên

                break;
        }


        anim.SetInteger("state", state);
    }
}
