using System;
using UnityEngine;

namespace Runtime.Managers
{
    public class LevelSelectionButtonManager : MonoBehaviour
    {
        [SerializeField] LevelSelectionButton prefab;
        [SerializeField] Transform spawnParent;
        LevelSelectionButton[] _buttons;

        void Awake()
        {
            LevelEvents.OnSpawnLevelSelectionButtons += Prepare;
            LevelEvents.OnLevelDataNeeded?.Invoke();
        }

        void OnDestroy()
        {
            LevelEvents.OnSpawnLevelSelectionButtons -= Prepare;
        }

        void Prepare(LevelScoresData[] data)
        {
            _buttons = new LevelSelectionButton[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                _buttons[i] = Instantiate(prefab, spawnParent);
                _buttons[i].Prepare(data[i]);
            }
        }
    }
}