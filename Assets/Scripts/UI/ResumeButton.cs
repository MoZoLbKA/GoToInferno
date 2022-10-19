using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
   [SerializeField] GameObject _pauseButton;
   [SerializeField] GameObject _playMenu;  
   [SerializeField] GameObject _resumeMenu;
    public void OnClick()
    {
        Pause.ResumeGame();
        _resumeMenu.SetActive(false);
        _playMenu.SetActive(true);
        _pauseButton.SetActive(true);        
    }

   
}
