using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public Slider timeSlider;
    public float timeDuration = 60f; // Toplam süre
    public float resetDelay = 3f; // Zaman sıfırlanmadan önce bekleme süresi

    private float timeLeft;
    private bool isCounting = true; // Sayacın çalışıp çalışmadığını kontrol etmek için bir bayrak

    void Start()
    {
        // Doğru cevaba basıldığında ResetTime metodunu çağıracak
        GameEvents.OnCorrectAnswer += HandleCorrectAnswer;

        // Başlangıç ayarları
        timeLeft = timeDuration;
        timeSlider.maxValue = timeDuration;
        timeSlider.value = timeDuration;
    }

    void Update()
    {
        if (isCounting && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeSlider.value = timeLeft;
        }
        else if (timeLeft <= 0)
        {
            // Zaman bittiğinde yapılacak işlemler
            timeLeft = 0;
            isCounting = false; // Sayacı durdur
            // İsterseniz zaman bitince yapılacak işlemleri burada tanımlayabilirsiniz
        }
    }

    // Doğru cevap geldiğinde çağrılan metod
    private async void HandleCorrectAnswer()
    {
        isCounting = false; // Sayacı durdur
        await WaitForSecondsAsync(resetDelay); // Belirli bir süre bekle
        ResetTime(); // Zamanı sıfırla
        isCounting = true; // Sayacı yeniden başlat
    }

    // Zamanı sıfırlayan metod
    private void ResetTime()
    {
        timeLeft = timeDuration;
        timeSlider.value = timeDuration;
    }

    // Olaydan abone olmayı kesmek için OnDestroy metodunu ekleyebilirsiniz
    private void OnDestroy()
    {
        GameEvents.OnCorrectAnswer -= HandleCorrectAnswer;
    }

    // Asenkron bekleme metodunu tanımlıyoruz
    private async UniTask WaitForSecondsAsync(float seconds)
    {
        await UniTask.Delay((int)(seconds * 1000)); 
        // UniTask.Delay milisaniye cinsinden çalışır
    }
}
