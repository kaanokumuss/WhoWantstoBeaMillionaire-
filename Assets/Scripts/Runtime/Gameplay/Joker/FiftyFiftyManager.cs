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
            jokerUsed = true; // Joker kullanıldı

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

            fiftyFiftyButton.interactable = false; // Joker butonunu devre dışı bırak
        }
        else
        {
            Debug.LogWarning("Joker zaten kullanıldı.");
        }
    }

    // Bu metot yeni bir soru geldiğinde butonları sıfırlamak için kullanılabilir
    public void ResetJoker()
    {
        // Joker kullanıldıktan sonra bir daha aktif olmasını istemediğimiz için, fiftyFiftyButton.interactable = false bırakıyoruz.
        foreach (Button button in optionButtons)
        {
            button.gameObject.SetActive(true); // Yanıt butonlarını tekrar aktif hale getir
        }
    }
}
