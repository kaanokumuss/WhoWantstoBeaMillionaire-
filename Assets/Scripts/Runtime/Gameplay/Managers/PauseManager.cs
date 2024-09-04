using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Button pauseButton;       
    public Button resumeButton;
    public Button fiftyFiftyButton;  
    public Button twoXButton;
    public GameObject pauseMenuUI;   // "OYUN DURDURULDU" yazýsýný içeren UI paneli
    public AudioSource[] allAudioSources;  // Tüm ses kaynaklarý
    public Button[] allOptionButtons;  // Oyun içindeki butonlar
    public TimeCounter timeCounter;    // Zamanlayýcý
    public QuestionManager questionManager;


    private bool isFiftyFiftyUsed = false;
    private bool isTwoXUsed = false;
    private bool isPaused = false;

    void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);

        pauseMenuUI.SetActive(false); // Oyunun baþlangýcýnda "OYUN DURDURULDU" yazýsýný gizli tut
        resumeButton.gameObject.SetActive(false); // Baþlangýçta Resume butonunu gizle
    }
    public void SetFiftyFiftyUsed()
    {
        isFiftyFiftyUsed = false;
    }
    public void SetTwoXUsed()
    {
        isTwoXUsed = false;
    }

    void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(true);

            foreach (AudioSource audioSource in allAudioSources)
            {
                audioSource.Pause();
            }

            foreach (Button btn in questionManager.optionsButtons)
            {
                btn.interactable = false;
            }

            // Joker butonlarýný duraklat
            if (!isFiftyFiftyUsed)
            {
                fiftyFiftyButton.interactable = false;
            }
            if (!isTwoXUsed)
            {
                twoXButton.interactable = false;
            }
            
            timeCounter.enabled = false;

            
        }
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Oyunu devam ettirir
        pauseMenuUI.SetActive(false); // "OYUN DURDURULDU" yazýsýný gizle

        // Resume butonunu gizle, Pause butonunu göster
        resumeButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);

        // Tüm sesleri aç
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }

        foreach (Button btn in questionManager.optionsButtons)
        {
            btn.interactable = true;
        }

        if (!isFiftyFiftyUsed)
        {
            fiftyFiftyButton.interactable = true;
        }
        if (!isTwoXUsed)
        {
            twoXButton.interactable = true;
        }

        // TimeCounter'ý tekrar etkinleþtir
        timeCounter.enabled = true;

        
    }
}
