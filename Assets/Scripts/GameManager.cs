using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    private int numEnemies;
    private bool playerDead;

    public void GameOver()
    {
        playerDead = true;
        var gameOver = GameObject.Find("GameOver").GetComponent<Text>();
        gameOver.enabled = true;
    }

    public void BulletShot()
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();

        var score = int.Parse(textUIComp.text);
        score -= 1;
        if (score < 0) score = 0;
        textUIComp.text = score.ToString();
    }

    public void EnemyKilled()
    {
        // Increase Score when enemy killed
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();

        var score = int.Parse(textUIComp.text);
        score += 10;

        textUIComp.text = score.ToString();

        numEnemies--;

        if (numEnemies <= 0 && !playerDead)
        {
            var gameOver = GameObject.Find("GameOver").GetComponent<Text>();
            gameOver.text = "YOU WIN";
            gameOver.enabled = true;
        }
    }

    private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        numEnemies = GameObject.Find("Enemies").transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Check Win Condition
    }
}
