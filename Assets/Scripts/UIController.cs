using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public TextMeshProUGUI score;
    public GameObject gameOver, playButton, settingsButton, pauseButton;
    public GameObject pauseMenu, settingsMenu;

    private void Awake()
    {
        instance = this;
    }
}
