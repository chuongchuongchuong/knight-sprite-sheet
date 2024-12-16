using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagement : ChuongMono<InputManagement>
{
    public KeyMap knightKeyMap;
    public KeyMap dragonKeyMap;


    protected override void GetScriptableDataValue()
    {
        var takeData = Resources.Load<CharactorData>("Data/Knight");
        knightKeyMap = takeData.keyMap;
        takeData = Resources.Load<CharactorData>("Data/Dragon");
        dragonKeyMap = takeData.keyMap;
    }

    private void Update()
    {
        knightKeyMap.ChangeKeyMapToInput();
        dragonKeyMap.ChangeKeyMapToInput();
    }
    
}