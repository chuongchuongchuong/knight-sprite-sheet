using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scripttext2 : MonoBehaviour
{
    private Slider healthBar;
    private Text thisText;
    private void Awake()
    {
        healthBar = transform.parent.GetComponentInChildren<Slider>();
        thisText = GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        thisText.text = healthBar.value + " /" + healthBar.maxValue;
    }
}
