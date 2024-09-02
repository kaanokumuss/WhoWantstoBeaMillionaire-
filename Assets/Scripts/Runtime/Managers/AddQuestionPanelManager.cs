using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class AddQuestionPanelManager : MonoBehaviour
{
    
    [SerializeField] private TMP_InputField questionInputField; // InputField -> TMP_InputField
    [SerializeField] private TMP_InputField[] optionInputFields; // InputField[] -> TMP_InputField[]
    [SerializeField] private TMP_InputField correctAnswerInputField; // InputField -> TMP_InputField
    [SerializeField] private QuestionDataSO questionDataSO;
    [SerializeField] private GameObject backgroundButtons;
    [SerializeField] private GameObject addQuestionPanel;    
    [SerializeField] private Button addButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button removeLastQuestionButton; // Yeni buton

    void OnEnable()
     {
         addButton.onClick.AddListener(OnAddQuestion);
        closeButton.onClick.AddListener(OnClick);
        removeLastQuestionButton.onClick.AddListener(RemoveLastQuestion); // Buton için listener ekle

    }

    void OnDisable()
    {
        addButton.onClick.RemoveListener(OnAddQuestion);
        closeButton.onClick.RemoveListener(OnClick);
    }
    
    void OnClick()
    {
        addQuestionPanel.SetActive(false);
        backgroundButtons.SetActive(true);
    }
    void OnAddQuestion()
    {
        string questionText = questionInputField.text;
        List<string> options = new List<string>();
        foreach (var inputField in optionInputFields)
        {
            options.Add(inputField.text);
        }
        string correctAnswer = correctAnswerInputField.text;

        // Yeni bir soru oluştur
        var newQuestion = new QuestionDataSO.Question
        {
            question = questionText,
            options = options,
            correctAnswer = correctAnswer
        };

        // QuestionDataSO'ya ekle
        questionDataSO.questions.Add(newQuestion);

        // JSON'a yaz
        QuestionsWriter.SaveQuestionToJson(questionDataSO);

        // InputField'ları temizleyebilirsiniz (isteğe bağlı)
        questionInputField.text = "";
        foreach (var inputField in optionInputFields)
        {
            inputField.text = "";
        }
        correctAnswerInputField.text = "";
    }
    void RemoveLastQuestion()
    {
        if (questionDataSO.questions.Count > 0)
        {
            // Son soruyu listeden kaldır
            questionDataSO.questions.RemoveAt(questionDataSO.questions.Count - 1);

            // Güncellenmiş listeyi JSON'a kaydet
            QuestionsWriter.SaveQuestionToJson(questionDataSO);

            Debug.Log("Son soru başarıyla silindi.");
        }
        else
        {
            Debug.LogWarning("Silinecek soru yok.");
        }
    }
}
