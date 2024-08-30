using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public Slider timeSlider;
    public float timeDuration = 60f; // Toplam süre

    private float timeLeft;

    void Start()
    {
        timeLeft = timeDuration;
        timeSlider.maxValue = timeDuration;
        timeSlider.value = timeDuration;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeSlider.value = timeLeft;
        }
        else
        {
            // Zaman bittiğinde yapılacak işlemler
            timeLeft = 0;
        }
    }
}