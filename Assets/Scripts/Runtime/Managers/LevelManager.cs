using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LevelSelectionSO levelSelectionSo;
    [SerializeField] TextAsset[] levelFiles;
    LevelData[] _levelData; 
    LevelSaveData _levelSaveData;

    void Awake()
    {
        ReadLevels();
        Load();

        LevelEvents.OnLevelSelected += LevelSelected;
        LevelEvents.OnLevelWin += Save_Callback;
        LevelEvents.OnLevelDataNeeded += LevelDataNeeded_Callback;
        GameEvents.OnCompleted += OnCompleteCallback;
    }

    void OnDestroy()
    {
        LevelEvents.OnLevelSelected -= LevelSelected;
        LevelEvents.OnLevelWin -= Save_Callback;
        LevelEvents.OnLevelDataNeeded -= LevelDataNeeded_Callback;
        GameEvents.OnCompleted -= OnCompleteCallback;
    }
    
    void LevelSelected(int index)
    {
        levelSelectionSo.levelIndex = index;
        levelSelectionSo.levelData = _levelData[index];
        levelSelectionSo.score = _levelSaveData.Data[index].highScore;
        SceneEvents.OnLoadGameScene?.Invoke();
    }

    void ReadLevels()
    {
        _levelData = new LevelData[levelFiles.Length];

        for (int i = 0; i < levelFiles.Length; i++)
        {
            _levelData[i] = JsonUtility.FromJson<LevelData>(levelFiles[i].text);
        }
    }

    void Load()
    {
        if (DataHandler.HasData(DataKeys.LevelScoreDataKey))
        {
            _levelSaveData = DataHandler.Load<LevelSaveData>(DataKeys.LevelScoreDataKey);
        }
        else 
        {
            _levelSaveData = new LevelSaveData
            {
                Data = new LevelScoresData[_levelData.Length]
            };

            for (int i = 0; i < _levelData.Length; i++)
            {
                _levelSaveData.Data[i] = new LevelScoresData
                {
                    index = i,
                    title = _levelData[i].title,
                    highScore = 0,
                    isUnlocked = i == 0 // İlk seviye açılmış olmalı
                };
            }

            DataHandler.Save(_levelSaveData, DataKeys.LevelScoreDataKey);
        }
    }
    
    void Save_Callback(CompleteData completeData)
    {
        if (completeData.Index + 1 < _levelSaveData.Data.Length)
        {
            _levelSaveData.Data[completeData.Index + 1].isUnlocked = true;
        }
        _levelSaveData.Data[completeData.Index].highScore = completeData.Score;
        DataHandler.Save(_levelSaveData, DataKeys.LevelScoreDataKey);
    }

    void LevelDataNeeded_Callback()
    {
        LevelEvents.OnSpawnLevelSelectionButtons?.Invoke(_levelSaveData.Data);
    }
    
    private void OnCompleteCallback()
    {
        if (levelSelectionSo.score < ScoreManager.Instance.Score)
        {
            Win();
        }
        else
        {
            Fail();
        }
    }

    private void Fail()
    {
        LoadMetaScene();
    }

    private void Win()
    {
        GameEvents.OnWin?.Invoke();
        Save_Callback(GetCompleteData());
        LoadMetaScene();
    }

    private CompleteData GetCompleteData()
    {
        return new CompleteData(levelSelectionSo.levelIndex, ScoreManager.Instance.Score);
    }

    private async void LoadMetaScene()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(3f));
        
        SceneEvents.OnLoadMetaScene?.Invoke();
    }
}
