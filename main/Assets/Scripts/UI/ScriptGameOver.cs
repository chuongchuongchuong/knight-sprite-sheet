using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptGameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private ScriptKnightHealth scriptKnightHealth;
    [SerializeField] private ScriptDragonHealth scriptDragonHealth;
    // Start is called before the first frame update

    private void Reset()
    {
        gameOver = GameObject.Find("GameOver");
        scriptKnightHealth = GameObject.Find("KnightHealth").GetComponent<ScriptKnightHealth>(); // lấy component máu của cả 2 player
        scriptDragonHealth = GameObject.Find("DragonHealth").GetComponent<ScriptDragonHealth>();

        gameOver.GetComponentInChildren<Button>().onClick.AddListener(PlayAgain);// Onclick cái nút PlayAgain
    }
    private void Start()
    {
        gameOver.SetActive(false);// tắt cái UI panel cuối game đi

    }

    // Update is called once per frame
    private void Update()
    {
        if (scriptKnightHealth.IsDead()) Invoke(nameof(DragonWon), 4f);
        if (scriptDragonHealth.IsDead()) Invoke(nameof(KnightWon), 4f);
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
