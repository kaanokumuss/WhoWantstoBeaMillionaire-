using System;
using UnityEngine;
using UnityEngine.UI; // Eğer UI bileşenlerini kullanıyorsan

public class PrizeManager : MonoBehaviour
{
    [SerializeField] Image[] prizeUIs; // UI elemanlarını tutan dizi (Image, TextMeshProUGUI vs.)
    [SerializeField] Color prizeColor = Color.red; // Belirli bir rengi atanacak

    private int currentPrizeIndex = 1;

    private void OnEnable()
    {
        Debug.Log("Current Color: " + prizeUIs[currentPrizeIndex].color);

        GameEvents.OnCorrectAnswer += ShowNextPrize;
    }

    private void OnDisable()
    {
        Debug.Log("Current Color: " + prizeUIs[currentPrizeIndex].color);

        GameEvents.OnCorrectAnswer -= ShowNextPrize;
    }

    public void ShowNextPrize()
    {
        Debug.Log("Current Color: " + prizeUIs[currentPrizeIndex].color);

        if (currentPrizeIndex < prizeUIs.Length)
        {
            // UI elemanının rengini değiştir
            prizeUIs[currentPrizeIndex].color = prizeColor; // Doğru renk değişimi
            currentPrizeIndex++;
            Debug.Log("Current Color: " + prizeUIs[currentPrizeIndex].color);

        }
        else
        {
            Debug.Log("All prizes have been revealed.");
        }
    }
}