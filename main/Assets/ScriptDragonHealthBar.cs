using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptDragonHealthBar : MonoBehaviour
{
    private Slider dragonHealthbar;

    private void Awake()
    {
        dragonHealthbar = GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //dragonHealthbar.value=
    }
}
