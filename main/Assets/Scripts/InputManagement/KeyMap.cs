using UnityEngine;

[System.Serializable]
public struct KeyMap
{
    public string keyMap_MoveX;
    [HideInInspector] public float input_MoveX;

    public string keyMap_MoveY;
    [HideInInspector] public float input_MoveY;

    public KeyCode keyMap_AttackButton;
    [HideInInspector] public bool input_Attack;

    public KeyCode keyMap_JumpButton;
    [HideInInspector] public bool intput_Jump;


    public void ChangeKeyMapToInput()
    {
        input_MoveX = Input.GetAxis(keyMap_MoveX);
        //moveY = Input.GetAxis(axisMoveY);
        input_Attack = Input.GetKeyDown(keyMap_AttackButton);
        intput_Jump = Input.GetKeyDown(keyMap_JumpButton);
    }
}