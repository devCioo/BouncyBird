using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public TextMeshProUGUI score, highscoreText;
    public Image highscoreImage;
    public GameObject gameOver, playButton, settingsButton, pauseButton;
    public GameObject pauseMenu, settingsMenu;

    private void Awake()
    {
        instance = this;
    }
}
