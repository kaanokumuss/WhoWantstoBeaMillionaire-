using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] QuestionDataSO questionData;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionShaker questionShaker;
    public Button[] optionsButtons;
    [SerializeField] private FiftyFiftyManager _fiftyManager;
    [SerializeField] private Button twoXButton;
    private List<int> shuffledIndices;
    public int currentQuestionIndex = 0;

    void Start()
    {
        if (questionShaker != null && questionData != null)
        {
            shuffledIndices = questionShaker.ShuffleQuestions(questionData.questions.Count);
            DisplayQuestion();
        }
    }

    void DisplayQuestion()
    {
        if (questionData != null && questionText != null && optionsButtons.Length == 4)
        {
            if (shuffledIndices != null && shuffledIndices.Count > 0)
            {
                int questionIndex = shuffledIndices[currentQuestionIndex];
                QuestionDataSO.Question currentQuestion = questionData.questions[questionIndex];
                GameEvents.CorrectAnswer?.Invoke(currentQuestion.correctAnswer);
                questionText.text = currentQuestion.question;

                for (int i = 0; i < optionsButtons.Length; i++)
                {
                    optionsButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.options[i];
                    optionsButtons[i].onClick.RemoveAllListeners();
                    
                    string selectedOption = currentQuestion.options[i];
                    optionsButtons[i].onClick.AddListener(() =>
                    {
                        GameEvents.USurePanel?.Invoke(selectedOption, currentQuestion.correctAnswer); 
                        
                    });
                }
            }
            else
            {
                Debug.LogError("No questions available in QuestionDataSO.");
            }
        }
        else
        {
            Debug.LogError("QuestionDataSO, TextMeshProUGUI, or Buttons are not assigned correctly.");
        }
    }


    public void CorrectAnswer()
    {
        GameEvents.OnCorrectAnswer?.Invoke();
        Debug.Log("Correct Answer!");

        NextQuestion();
    }
    

    public void NextQuestion()
    {
        if (currentQuestionIndex < shuffledIndices.Count - 1)
        {
            currentQuestionIndex++;
            _fiftyManager.ResetJoker();
            DisplayQuestion();
        }
        else
        {
            Debug.Log("No more questions.");
        }
    }
}