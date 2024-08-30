using System;
using UnityEngine.UI;
using UnityEngine;

public class YouSureManager : MonoBehaviour
{
    [SerializeField] private GameObject uSure; // 'Are you sure?' paneli
    [SerializeField] private Button yes; // 'Yes' butonu
    [SerializeField] private Button no; // 'No' butonu
    [SerializeField] private QuestionManager questionManager; // QuestionManager referansı

    private string selectedOption; // Seçilen opsiyon
    private string correctAnswer; // Doğru cevap

    private void OnEnable()
    {
        GameEvents.USurePanel += ShowUSurePanel; // Paneli gösteren event
        yes.onClick.AddListener(OnYesClicked); // 'Yes' butonuna tıklandığında çağrılan event
        no.onClick.AddListener(OnNoClicked); // 'No' butonuna tıklandığında çağrılan event
    }

    private void OnDisable()
    {
        GameEvents.USurePanel -= ShowUSurePanel;
        yes.onClick.RemoveListener(OnYesClicked);
        no.onClick.RemoveListener(OnNoClicked);
    }

    private void ShowUSurePanel(string selected, string correct)
    {
        selectedOption = selected;
        correctAnswer = correct;
        uSure.SetActive(true); // 'Are you sure?' panelini aktif hale getir
    }

    private void OnYesClicked()
    {
        uSure.SetActive(false); // Paneli kapat

        if (selectedOption == correctAnswer)
        {
            questionManager.CorrectAnswer(); // Doğru cevabı işleme al
        }
        else
        {
            questionManager.WrongAnswer(); // Yanlış cevabı işleme al
        }
    }

    private void OnNoClicked()
    {
        uSure.SetActive(false); // Paneli kapat, işlemi iptal et
    }
}