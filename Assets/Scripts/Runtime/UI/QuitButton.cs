using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    public Button quitButton;

    void OnEnable()
    {
        ClickMeAnimation();
        quitButton.onClick.AddListener(OnClick);
    }

    void OnDisable()
    {
        quitButton.onClick.RemoveListener(OnClick);
        DOTween.Kill(transform);
    }
    void ClickMeAnimation()
    {
        DOTween.Sequence()
            .Append(transform.DOPunchScale(Vector3.one * .15f, .5f).SetEase(Ease.InOutExpo))
            .AppendInterval(.3f)
            .SetLoops(-1, LoopType.Restart)
            .OnKill(() =>
            {
                transform.localScale = Vector3.one;
            })
            .SetId(transform);
    }

    void OnClick()
    {
        Application.Quit();
    }
}
