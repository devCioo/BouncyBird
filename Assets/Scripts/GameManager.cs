using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int _score;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Pause();
    }

    public void Play()
    {
        _score = 0;
        UIController.instance.score.gameObject.SetActive(true);
        UIController.instance.score.text = _score.ToString();

        UIController.instance.gameOver.SetActive(false);
        UIController.instance.playButton.SetActive(false);

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
        PlayerController.instance.enabled = false;
    }

    public void GameOver()
    {
        UIController.instance.gameOver.SetActive(true);
        UIController.instance.playButton.SetActive(true);

        Time.timeScale = 0f;
    }

    public void IncreaseScore()
    {
        _score++;
        UIController.instance.score.text = _score.ToString();
    }
}
