using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FiftyFiftyManager : MonoBehaviour
{
    [SerializeField] private Button fiftyFiftyButton;
    [SerializeField] private Button[] optionButtons;
    private string correctAnswer;
    private bool jokerUsed = false;

    void Start()
    {
        GameEvents.CorrectAnswer += SetCorrectAnswer;
        fiftyFiftyButton.onClick.AddListener(RemoveTwoWrongAnswers);
    }

    void SetCorrectAnswer(string _correctAnswer)
    {
        correctAnswer = _correctAnswer;
    }
    
    public void RemoveTwoWrongAnswers()
    {
        if (!jokerUsed)
        {
            jokerUsed = true; 
            FindObjectOfType<PauseManager>().SetFiftyFiftyUsed();
            int removedCount = 0;
            foreach (Button button in optionButtons)
            {
                if (removedCount >= 2) break;

                TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
                if (buttonText.text != correctAnswer)
                {
                    button.gameObject.SetActive(false);
                    removedCount++;
                }
            }

            fiftyFiftyButton.interactable = false;
        }
    }


    public void ResetJoker()
    {
        
        foreach (Button button in optionButtons)
        {
            button.gameObject.SetActive(true); 
        }
    }
}
