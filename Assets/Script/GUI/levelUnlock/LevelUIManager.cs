using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace levelUnlock
{
    public class LevelUIManager : MonoBehaviour
    {
        private static LevelUIManager instance;                            
        public static LevelUIManager Instance { get => instance; }
        [SerializeField] private LevelButtonScript levelBtnPrefab;              
        public GameObject levelBtnGridHolder;
        public Transform levelGridHolderPrefab;
        public void Awake()
        {
            if(instance==null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        void Start()
        {
            InitializeUI();
        }

        public void InitializeUI()                                           
        {
            LevelItem[] levelItemsArray = LevelManager.Instance.LevelData.levelItemArray;  

            for (int i = 0; i < levelItemsArray.Length; i++)                        
            {
                LevelButtonScript levelButton = Instantiate(levelBtnPrefab, levelGridHolderPrefab);                                                                        
                levelButton.SetLevelButton(levelItemsArray[i], i);
            }
        }
    }
}
