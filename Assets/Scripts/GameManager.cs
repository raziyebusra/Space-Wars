using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI playerNameText;

    public GameObject titleScreen;
    public int score = 0;

    public GameObject gameOverMenu;
    public bool isGameActive;
    public AudioSource backgrounSound;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {

        score = 0;
        Time.timeScale = 0f;
        titleScreen.SetActive(true);


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGameActive)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (playerController.isGameOver)
        {
            StartCoroutine(GameOver());
        }
    }

    public void Updatescore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }
    public void Reducescore()
    {
        score -= 1;
        scoreText.text = "Score: " + score;
    }
    public void StartGame()
    {
        isGameActive = true;
        Time.timeScale = 1f;
        score = 0;
        titleScreen.gameObject.SetActive(false);
        backgrounSound.Play();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isGameActive = true;
        backgrounSound.UnPause();
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        isGameActive = false;
        backgrounSound.Pause();
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        gameOverMenu.SetActive(true);
        isGameActive = false;
        Time.timeScale = 0f;
        backgrounSound.Stop();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

