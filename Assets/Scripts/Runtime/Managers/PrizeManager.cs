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
        // Prize Panelini ve Background'u kontrol etme
        panel.SetActive(true);
        background.SetActive(false); // Background'u kapat
        Debug.Log("Current Color: " + prizeUIs[questionManager.currentQuestionIndex].color);

        if (questionManager.currentQuestionIndex < prizeUIs.Length)
        {
            // UI elemanının rengini değiştir
            prizeUIs[questionManager.currentQuestionIndex].color = prizeColor; 
            WaitAndRevertBackgroundAsync(3).Forget();  // Arka planı geri yüklemek için UniTask başlat
            Debug.Log("Current Color: " + prizeUIs[questionManager.currentQuestionIndex].color);
        }
        else
        {
            Debug.Log("All prizes have been revealed.");
        }
    }

    private async UniTaskVoid WaitAndRevertBackgroundAsync(float seconds)
    {
        await UniTask.Delay((int)(seconds * 1000)); // Milisaniye cinsinden gecikme süresi
        panel.SetActive(false);
        background.SetActive(true); // Background'u tekrar aktif hale getir
    }
}
