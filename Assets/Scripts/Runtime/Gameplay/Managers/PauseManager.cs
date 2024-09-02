using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Button pauseButton;       
    public Button resumeButton;      
    public GameObject pauseMenuUI;   // "OYUN DURDURULDU" yaz�s�n� i�eren UI paneli
    public AudioSource[] allAudioSources;  // T�m ses kaynaklar�
    public Button[] allOptionButtons;  // Oyun i�indeki butonlar
    public TimeCounter timeCounter;    // Zamanlay�c�
    public QuestionManager questionManager;

    private bool isPaused = false;

    void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);

        pauseMenuUI.SetActive(false); // Oyunun ba�lang�c�nda "OYUN DURDURULDU" yaz�s�n� gizli tut
        resumeButton.gameObject.SetActive(false); // Ba�lang��ta Resume butonunu gizle
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Oyunu durdurur
        pauseMenuUI.SetActive(true); // "OYUN DURDURULDU" yaz�s�n� g�ster

        // Pause butonunu gizle, Resume butonunu g�ster
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);

        // T�m sesleri kapat
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Pause();
        }

        foreach (Button btn in questionManager.optionsButtons)
        {
            btn.interactable = false;
        }

        // TimeCounter'� durdur
        timeCounter.enabled = false;
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Oyunu devam ettirir
        pauseMenuUI.SetActive(false); // "OYUN DURDURULDU" yaz�s�n� gizle

        // Resume butonunu gizle, Pause butonunu g�ster
        resumeButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);

        // T�m sesleri a�
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }

        foreach (Button btn in questionManager.optionsButtons)
        {
            btn.interactable = true;
        }

        // TimeCounter'� tekrar etkinle�tir
        timeCounter.enabled = true;
    }
}
