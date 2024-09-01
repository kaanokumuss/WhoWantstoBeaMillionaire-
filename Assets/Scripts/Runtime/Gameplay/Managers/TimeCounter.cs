using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public Slider timeSlider;
    public float timeDuration = 60f;
    public float resetDelay = 3f;
    private string correctAnswer;
    private float timeLeft;
    private bool isCounting = true;

    void Start()
    {
        GameEvents.CorrectAnswer += CallFailedScene;
        GameEvents.OnCorrectAnswer += HandleCorrectAnswer;
        timeLeft = timeDuration;
        timeSlider.maxValue = timeDuration;
        timeSlider.value = timeDuration;

        // Zaman sayacı başladığında ses çalsın
        AudioEvents.PlaySound?.Invoke();
    }

    private void OnDestroy()
    {
        GameEvents.OnCorrectAnswer -= HandleCorrectAnswer;
    }

    void Update()
    {
        if (isCounting && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeSlider.value = timeLeft;
        }
        else if (timeLeft <= 0 && isCounting)
        {
            timeLeft = 0;
            isCounting = false;
            
            // Zaman dolduğunda fail panelini aç
            CallFailedScene(correctAnswer);
            GameEvents.Failed?.Invoke(correctAnswer);
                
        }
    }

    private void CallFailedScene(string _correctAnswer)
    {
        correctAnswer = _correctAnswer;
    }


    private async void HandleCorrectAnswer()
    {
        AudioEvents.StopSound?.Invoke();
        isCounting = false;
        await WaitForSecondsAsync(resetDelay);
        ResetTime();
        isCounting = true;

        // Zaman resetlendiğinde ses yeniden başlasın
        AudioEvents.PlaySound?.Invoke();
    }

    private void ResetTime()
    {
        timeLeft = timeDuration;
        timeSlider.value = timeDuration;
    }

    private async UniTask WaitForSecondsAsync(float seconds)
    {
        await UniTask.Delay((int)(seconds * 1000));
    }
}