using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public TextMeshProUGUI score;
    public GameObject gameOver, playButton;

    private void Awake()
    {
        instance = this;
    }
}
