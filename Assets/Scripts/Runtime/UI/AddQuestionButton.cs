using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddQuestionButton: MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] private GameObject addQuestionPanel;
    [SerializeField] private GameObject backgroundButtons;
    void OnEnable()
    {
        button.onClick.AddListener(OnClick);
    }

    void OnDisable()
    {
        button.onClick.RemoveListener(OnClick);
    }
    
    void OnClick()
    {
        backgroundButtons.SetActive(false);
        addQuestionPanel.SetActive(true);
    }    
}
