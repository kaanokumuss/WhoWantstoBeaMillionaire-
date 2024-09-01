using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddQuestionPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject backgroundButtons;
    [SerializeField] private Button closeButton;
    [SerializeField] private GameObject addQuestionPanel;    
    void OnEnable()
     {
        closeButton.onClick.AddListener(OnClick);
    }

    void OnDisable()
    {
        closeButton.onClick.RemoveListener(OnClick);
    }
    
    void OnClick()
    {
        addQuestionPanel.SetActive(false);
        backgroundButtons.SetActive(true);
    }
}
