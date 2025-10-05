using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> targets;
    float spawnTime = 1.0f;


    [Header("Game Over")]
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Button restartButton;
    public bool isGameActive;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    int score;

    [Header("Start Scene")]
    public GameObject titleScreen;


    [Header("Lives")]
    public TextMeshProUGUI liveText;
    public int live = 3;

    [Header("Pause Scene")]
    public GameObject pauseScreen;
    public bool ispauseScreen = false;




    float spawnRate = 1.0f;

    private void Update()
    {
        Pause();
       
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnTime);

            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
        }
    }


    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }


    public void GameOver()
    {
        if (live <= 0)
        {
            live = 0;
            liveText.text = "Lives: " + live;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            isGameActive = false;
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;

        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);


        titleScreen.gameObject.SetActive(false);
    }


    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.A) ) 
        {
            if(ispauseScreen == false)
            {
                pauseScreen.gameObject.SetActive(true);
                Time.timeScale = 0;
                ispauseScreen = true;
            }
            else
            {
                pauseScreen.gameObject.SetActive(false);
                Time.timeScale = 1;
                ispauseScreen = false;
            }
               
        }
    }


}
