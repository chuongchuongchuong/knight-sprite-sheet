using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptGameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private KnightHealth knightHealth;
    [SerializeField] private DragonHealth dragonHealth;
    // Start is called before the first frame update

    private void Reset()
    {
        gameOver = GameObject.Find("GameOver");
        knightHealth = GameObject.Find("KnightHealth").GetComponent<KnightHealth>(); // lấy component máu của cả 2 player
        dragonHealth = GameObject.Find("DragonHealth").GetComponent<DragonHealth>();

        gameOver.GetComponentInChildren<Button>().onClick.AddListener(PlayAgain);// Onclick cái nút PlayAgain
    }
    private void Start()
    {
        gameOver.SetActive(false);// tắt cái UI panel cuối game đi

    }

    // Update is called once per frame
    private void Update()
    {
        if (knightHealth.IsDead()) Invoke(nameof(DragonWon), 4f);
        if (dragonHealth.IsDead()) Invoke(nameof(KnightWon), 4f);
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
