using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptGameOver : MonoBehaviour
{
    private GameObject gameOver;
    private ScriptHealth1 scriptHealth1;
    private ScriptHealth2 scriptHealth2;
    // Start is called before the first frame update

    private void Awake()
    {
        gameOver = GameObject.Find("GameOver");
        scriptHealth1 = GameObject.Find("Health1").GetComponent<ScriptHealth1>(); // lấy component máu của cả 2 player
        scriptHealth2 = GameObject.Find("Health2").GetComponent<ScriptHealth2>();

        gameOver.GetComponentInChildren<Button>().onClick.AddListener(PlayAgain);// Onclick cái nút PlayAgain
    }
    void Start()
    {
        gameOver.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (scriptHealth1.isDead()) Invoke("DragonWon", 4f);
        if (scriptHealth2.isDead()) Invoke("KnightWon", 4f);
    }

    //xuất hiện bảng thông báo dragon thắng
    public void DragonWon()
    {
        gameOver.GetComponentInChildren<Text>().text = "Dragon Won";
        gameOver.SetActive(true);
    }

    //xuất hiện bảng thông báo knight thắng
    public void KnightWon()
    {
        gameOver.GetComponentInChildren<Text>().text = "Knihgt Won";
        gameOver.SetActive(true);
    }


    void PlayAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Battle");
    }
}
