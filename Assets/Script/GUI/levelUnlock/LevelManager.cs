using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace levelUnlock
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance;
        public static LevelManager Instance { get { return instance; } }
        [SerializeField] private LevelData levelData;
        public LevelData LevelData { get => levelData; }
        private int currentLevel; 
        public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public void SetStarLevel()
        {
            
            levelData.levelItemArray[currentLevel + 1].unlocked = true;
            if (currentLevel + 1 > levelData.lastUnlockedLevel)
            {
                levelData.lastUnlockedLevel=currentLevel+1;
            }
        }

    }
    [System.Serializable]
    public class LevelData
    {
        public int lastUnlockedLevel = 0;   
        public LevelItem[] levelItemArray;      
    }

    [System.Serializable]
    public class LevelItem                
    {
        public bool unlocked;
    }
}
