using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int _score;
    private bool wasGamePaused = false;
    public bool isGamePaused = true;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 0f;
        PlayerController.instance.enabled = false;
    }

    public void Play()
    {
        _score = 0;
        isGamePaused = false;
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
    }

    public void IncreaseScore()
    {
        _score++;
        UIController.instance.score.text = _score.ToString();
    }
}
