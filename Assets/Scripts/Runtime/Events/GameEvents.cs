using System;
using UnityEngine.Timeline;

public static class GameEvents
{
    // public static Action<SubmitBlock, string> OnTileAttached;
    // public static Action<SubmitBlock> OnTileRemoved;
    // public static Action<Tile[]> OnTilesSpawned;
    public static Action OnCorrectAnswer;
    public static Action<string, string> USurePanel;
    public static Action<string> Failed;
    public static Action Winner;
}
