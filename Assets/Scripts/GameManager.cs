using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    private int numEnemies;
    

    public void GameOver()
    {
        var gameOver = GameObject.Find("GameOver").GetComponent<Text>();
        gameOver.enabled = true;
    }

    public void KillEnemy()
    {

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
