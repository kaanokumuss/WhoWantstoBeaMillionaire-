using System;

public static class GameEvents
{
    public static Action OnWin, OnFail;
    public static Action OnCompleted;
    // public static Action<SubmitBlock, string> OnTileAttached;
    // public static Action<SubmitBlock> OnTileRemoved;
    // public static Action<Tile[]> OnTilesSpawned;
    public static Action OnSearchVisibleTiles;
    public static Action OnWordSubmitted;
}
