using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public Button musicToggleButton;
    public Color musicOnColor = Color.green;
    public Color musicOffColor = Color.red;

    private bool isMusicOn = true;
    private Image buttonImage;

    void Start()
    {
        buttonImage = musicToggleButton.GetComponent<Image>();
        UpdateButtonColor();
        musicToggleButton.onClick.AddListener(ToggleMusic);
    }

    void ToggleMusic()
    {
        isMusicOn = !isMusicOn;

        if (isMusicOn)
        {
            backgroundMusic.Play();
        }
        else
        {
            backgroundMusic.Stop();
        }

        UpdateButtonColor();
    }

    void UpdateButtonColor()
    {
        if (buttonImage != null)
        {
            buttonImage.color = isMusicOn ? musicOnColor : musicOffColor;
        }
    }
}
