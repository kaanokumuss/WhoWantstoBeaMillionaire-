using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] QuestionDataSO questionData; 
    [SerializeField] TextMeshProUGUI questionText; 
    [SerializeField] QuestionShaker questionShaker;
    [SerializeField] Button[] optionsButtons;

    private List<int> shuffledIndices;
    private int currentQuestionIndex = 0;

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
                
                questionText.text = currentQuestion.question;

                for (int i = 0; i < optionsButtons.Length; i++)
                {
                    optionsButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.options[i];
                    optionsButtons[i].onClick.RemoveAllListeners();

                    if (currentQuestion.options[i] == currentQuestion.correctAnswer)
                    {
                        optionsButtons[i].onClick.AddListener(() => CorrectAnswer());
                    }
                    else
                    {
                        optionsButtons[i].onClick.AddListener(() => WrongAnswer());
                    }
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

    void CorrectAnswer()
    {
        // PrizeManager prizeManager = FindObjectOfType<PrizeManager>();
        // prizeManager.ShowNextPrize();
        
        
        //bag e koyup hangi indexli soru oldugunu gonderebiliriz.
        SceneEvents.OnLoadPrizeScene?.Invoke();
        GameEvents.OnCorrectAnswer?.Invoke();
        Debug.Log("Correct Answer!");
        // NextQuestion();
    }

    void WrongAnswer()
    {
        //GameOver
        Debug.Log("Wrong Answer!");
    }

    public void NextQuestion()
    {
        if (currentQuestionIndex < shuffledIndices.Count - 1)
        {
            currentQuestionIndex++;
            DisplayQuestion();
        }
        else
        {
            Debug.Log("No more questions.");
        }
    }
}