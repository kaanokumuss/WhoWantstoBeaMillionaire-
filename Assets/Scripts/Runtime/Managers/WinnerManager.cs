
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinnerManager : MonoBehaviour
{
    [SerializeField] private GameObject WinnerPanel; 
    [SerializeField] private GameObject background;
    [SerializeField] private Button quitGame; 
    [SerializeField] private Button newGame; 
    private void OnEnable()
    {
        GameEvents.Winner += ShowWinnerPanel; 
        quitGame.onClick.AddListener(OnQuitGameClicked); 
        newGame.onClick.AddListener(OnNewGameClicked); 
    }

    private void OnDisable()
    {
        GameEvents.Winner -= ShowWinnerPanel;
        quitGame.onClick.RemoveListener(OnQuitGameClicked);
        newGame.onClick.RemoveListener(OnNewGameClicked);
    }

    private void ShowWinnerPanel()
    {
        background.SetActive(false);
        WinnerPanel.SetActive(true); 
    }

    private void OnNewGameClicked()
    {
        WinnerPanel.SetActive(false);
        SceneEvents.OnLoadGameScene?.Invoke();
    }

    private void OnQuitGameClicked()
    {
        Application.Quit();
    }
}
