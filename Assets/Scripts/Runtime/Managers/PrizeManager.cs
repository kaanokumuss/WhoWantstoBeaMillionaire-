using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PrizeManager : MonoBehaviour
{
    [SerializeField] Image[] prizeUIs;
    [SerializeField] private Sprite RedprizeUI;
    [SerializeField] QuestionManager questionManager;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject background;
    private  void OnEnable()
    {
        GameEvents.OnCorrectAnswer += ShowNextPrize;

    }

    private void OnDisable()
    {
        GameEvents.OnCorrectAnswer -= ShowNextPrize;
    }


    public void ShowNextPrize()
    {
        if (questionManager.currentQuestionIndex < prizeUIs.Length-1)
        {
            panel.SetActive(true);
            background.SetActive(false);

            Debug.Log("Current Color: " + prizeUIs[questionManager.currentQuestionIndex].color);
        
            prizeUIs[questionManager.currentQuestionIndex].sprite = RedprizeUI; 
            WaitAndRevertBackgroundAsync(3).Forget();  

            Debug.Log("Current Color: " + prizeUIs[questionManager.currentQuestionIndex].color);
        }
        else
        {
            // Index dizi boyutunu aşarsa Winner olayını tetikle
            Debug.Log("Winner event triggered");
            GameEvents.Winner?.Invoke();
        }
    }



    private async UniTaskVoid WaitAndRevertBackgroundAsync(float seconds)
    {
        await UniTask.Delay((int)(seconds * 1000)); // Milisaniye cinsinden gecikme süresi
        panel.SetActive(false);
        background.SetActive(true); // Background'u tekrar aktif hale getir
    }
}
