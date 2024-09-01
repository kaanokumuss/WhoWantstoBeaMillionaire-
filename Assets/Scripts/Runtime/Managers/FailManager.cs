using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class FailManager : MonoBehaviour
{
    [SerializeField] private GameObject failPanel; 
    [SerializeField] private GameObject background;
    [SerializeField] private Button quitGame; 
    [SerializeField] private Button newGame; 
    [SerializeField] private TextMeshProUGUI correctAnswer;
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
        correctAnswer.text ="Doğru Cevap : " + correctanswer;
        background.SetActive(false);
        failPanel.SetActive(true); 
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