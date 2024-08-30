using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PrizeManager : MonoBehaviour
{
    [SerializeField] Image[] prizeUIs; 
    [SerializeField] Color prizeColor = Color.red; // Belirli bir rengi atanacak
    [SerializeField] QuestionManager questionManager;
    [SerializeField] private GameObject Panel;

    private  void OnEnable()
    {
        GameEvents.OnCorrectAnswer += ShowNextPrize;

    }

    private void OnDisable()
    {
        GameEvents.OnCorrectAnswer -= ShowNextPrize;
    }


    public void  ShowNextPrize()
    {
        Panel.SetActive(true);
        Debug.Log("Current Color: " + prizeUIs[questionManager.currentQuestionIndex].color);

        if (questionManager.currentQuestionIndex < prizeUIs.Length)
        {
            // UI elemanının rengini değiştir
            prizeUIs[questionManager.currentQuestionIndex].color = prizeColor; // Doğru renk değişimi
            WaitForSecondsAsync(3);
            Debug.Log("Current Color: " + prizeUIs[questionManager.currentQuestionIndex].color);

        }
        else
        {
            Debug.Log("All prizes have been revealed.");
        }
    }

    private async UniTask WaitForSecondsAsync(float seconds)
    {
        await UniTask.Delay((int)(seconds * 1000)); 
        // UniTask.Delay milisaniye cinsinden çalışır
            Panel.SetActive(false);
    }
}
