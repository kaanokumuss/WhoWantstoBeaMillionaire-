using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TwoXManager : MonoBehaviour
{
    [SerializeField] private Button twoXButton;
    [SerializeField] private YouSureManager _youSureManager;
    private string correctAnswer;
    private bool jokerUsed = false;

    void Start()
    {
        twoXButton.onClick.AddListener(UsageTwoX);
        
    }
    private void UsageTwoX()
    {
        if (!jokerUsed) 
        {
            FindObjectOfType<PauseManager>().SetTwoXUsed();
            jokerUsed = true;
            twoXButton.interactable = false; 
            GameEvents.TwoXJokerUsed?.Invoke();
        }
    }
    




   
    
}
