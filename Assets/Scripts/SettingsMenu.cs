using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider, heightRangeSlider, pipesSpeedSlider;
    [SerializeField] private Image volumeImage;
    [SerializeField] private Sprite[] volumeSprites;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetInt("volume", 1);
            AudioListener.volume = PlayerPrefs.GetInt("volume") / 5;
            ChangeVolumeImage();
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetInt("volume") / 5;
            ChangeVolumeImage();
        }

        if (!PlayerPrefs.HasKey("heightRange"))
        {
            PlayerPrefs.SetFloat("heightRange", 0.6f);
            PipeSpawner.instance.heightRange = PlayerPrefs.GetFloat("heightRange");
        }
        else
        {
            PipeSpawner.instance.heightRange = PlayerPrefs.GetFloat("heightRange");
        }

        if (!PlayerPrefs.HasKey("pipesSpeed"))
        {
            PlayerPrefs.SetFloat("pipesSpeed", 0.65f);
            PipeSpawner.instance.pipesSpeed = PlayerPrefs.GetFloat("pipesSpeed");
        }
        else
        {
            PipeSpawner.instance.pipesSpeed = PlayerPrefs.GetFloat("pipesSpeed");
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value / 5;
        PlayerPrefs.SetInt("volume", (int)volumeSlider.value);
        ChangeVolumeImage();
    }

    public void ChangeHeightRange()
    {
        PipeSpawner.instance.heightRange = heightRangeSlider.value;
        PlayerPrefs.SetFloat("heightRange", heightRangeSlider.value);
    }

    public void ChangePipesSpeed()
    {
        PipeSpawner.instance.pipesSpeed = pipesSpeedSlider.value;
        PlayerPrefs.SetFloat("pipesSpeed", pipesSpeedSlider.value);
    }

    public void ChangeVolumeImage()
    {
        int volume = PlayerPrefs.GetInt("volume");

        switch (volume)
        {
            case 0:
                volumeImage.sprite = volumeSprites[0];
                break;
            case 1:
            case 2:
            case 3:
                volumeImage.sprite = volumeSprites[1];
                break;
            case 4:
            case 5:
            case 6:
                volumeImage.sprite = volumeSprites[2];
                break;
            case 7:
            case 8:
            case 9:
                volumeImage.sprite = volumeSprites[3];
                break;
            default:
                Debug.Log("No sprite to replace!");
                break;
        }
    }
}
