using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int _score, _highscore;
    private bool wasGamePaused = false, highscoreBeaten = false;
    public bool isGamePaused = true;

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        Time.timeScale = 0f;
        PlayerController.instance.enabled = false;
        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
        }
        _highscore = PlayerPrefs.GetInt("highscore");
        UIController.instance.highscoreText.text = _highscore.ToString();
    }

    public void Play()
    {
        _score = 0;
        isGamePaused = false;
        highscoreBeaten = false;
        _highscore = PlayerPrefs.GetInt("highscore");
        UIController.instance.score.gameObject.SetActive(true);
        UIController.instance.score.text = _score.ToString();

        UIController.instance.gameOver.SetActive(false);
        UIController.instance.playButton.SetActive(false);
        UIController.instance.settingsButton.SetActive(false);
        UIController.instance.pauseMenu.SetActive(false);
        UIController.instance.pauseButton.SetActive(true);

        Time.timeScale = 1f;
        PlayerController.instance.enabled = false;
        PlayerController.instance.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        foreach (Pipes pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        UIController.instance.pauseMenu.SetActive(true);
        isGamePaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        UIController.instance.pauseMenu.SetActive(false);
        isGamePaused = false;
    }

    public void Restart()
    {
        Play();
    }

    public void OpenSettings(bool openPauseMenu)
    {
        UIController.instance.pauseMenu.SetActive(false);
        UIController.instance.settingsButton.SetActive(false);
        UIController.instance.settingsMenu.SetActive(true);
        if (openPauseMenu)
        {
            wasGamePaused = true;
        }
        else
        {
            wasGamePaused = false;
        }
    }

    public void CloseSettings()
    {
        UIController.instance.settingsMenu.SetActive(false);
        if (wasGamePaused)
        {
            UIController.instance.pauseMenu.SetActive(true);
        }
        else
        {
            UIController.instance.settingsButton.SetActive(true);
        }
    }

    public void GameOver()
    {
        AudioManager.instance.PlaySFX(0);
        Time.timeScale = 0f;
        isGamePaused = true;

        UIController.instance.gameOver.SetActive(true);
        UIController.instance.playButton.SetActive(true);
        UIController.instance.pauseButton.SetActive(false);
        UIController.instance.settingsButton.SetActive(true);
        if (highscoreBeaten)
        {
            PlayerPrefs.SetInt("highscore", _score);
            UIController.instance.highscoreText.text = PlayerPrefs.GetInt("highscore").ToString();
        }
    }

    public void IncreaseScore()
    {
        _score++;
        UIController.instance.score.text = _score.ToString();
        if (!highscoreBeaten && _score > _highscore)
        {
            StartCoroutine(BlinkHighscore());
            highscoreBeaten = true;
            UIController.instance.highscoreText.text = _score.ToString();
        }
        if (highscoreBeaten)
        {
            UIController.instance.highscoreText.text = _score.ToString();
        }
    }

    private IEnumerator BlinkHighscore()
    {
        float i;
        for (i = 0f; i < 1f; i += 0.1f)
        {
            if (UIController.instance.highscoreImage.color == Color.white)
            {
                UIController.instance.highscoreImage.color = Color.green;
            }
            else
            {
                UIController.instance.highscoreImage.color = Color.white;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
