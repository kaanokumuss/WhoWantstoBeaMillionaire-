using System;
using UnityEngine.Timeline;

public static class GameEvents
{
    public static Action OnCorrectAnswer;
    public static Action<string, string> USurePanel;
    public static Action<string> Failed;
    public static Action Winner;
    public static Action<string> CorrectAnswer;

}
    