using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace levelUnlock
{
    public class LevelButtonScript : MonoBehaviour
    {
        [SerializeField] private Sprite Lock, UnLock;
        [SerializeField] private Image btnImage; 
        [SerializeField] private Button btn;
        [SerializeField] private Text levelTxt;
        private int levelIndex;
        private void Start()
        {
            btn.onClick.AddListener(() => OnClick());               
        }
        public void SetLevelButton(LevelItem value, int index)
        {
            
            if (value.unlocked)                                     
            {
                levelIndex = index + 1;                             
                btn.interactable = true;
                btnImage.sprite = UnLock;
                levelTxt.text=levelIndex.ToString();
            }
            else
            {
                levelIndex = index + 1;
                btn.interactable = false;                          
                btnImage.sprite = Lock;
                levelTxt.text = "";
            }
        }
        void OnClick()                                              
        {
            LevelManager.Instance.CurrentLevel = levelIndex - 1;  
            SceneManager.LoadScene("Level" + levelIndex);
            LevelUIManager.Instance.levelBtnGridHolder.SetActive(false);
            /*GameController.Instance.numHeart = 3;
            GameController.Instance.heath = 3;
            GameController.Instance.State = GameState.None;
            GameController.Instance.setting.SetActive(false);
            GameController.Instance.pause.SetActive(true);*/
        }
    }
}
