using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Animations;

public class FailManager : MonoBehaviour
{
    [SerializeField] private GameObject failPanel; 
    [SerializeField] private GameObject background;
    [SerializeField] private Button quitGame; 
    [SerializeField] private Button newGame; 
    [SerializeField] private TextMeshProUGUI correctAnswer;
    [SerializeField] private AudioSource failSound;
    [SerializeField] private MusicManager musicManager;
    private void OnEnable()
    {
        GameEvents.Failed += ShowFailPanel; 
        quitGame.onClick.AddListener(OnQuitGameClicked); 
        newGame.onClick.AddListener(OnNewGameClicked); 
    }

    private void OnDisable()
    {
        GameEvents.Failed -= ShowFailPanel;
        quitGame.onClick.RemoveListener(OnQuitGameClicked);
        newGame.onClick.RemoveListener(OnNewGameClicked);
    }

    private void ShowFailPanel(string correctanswer)
    {
        AudioEvents.StopSound?.Invoke();
        correctAnswer.text ="Doğru Cevap : " + correctanswer;
        background.SetActive(false);
        failPanel.SetActive(true);
        failSound.Play();

        musicManager.backgroundMusic.Stop();
    }

    private void OnNewGameClicked()
    {
        failPanel.SetActive(false);
        SceneEvents.OnLoadGameScene?.Invoke();
    }

    private void OnQuitGameClicked()
    {
        Application.Quit();
    }
}