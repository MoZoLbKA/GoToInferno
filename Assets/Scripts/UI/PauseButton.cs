using Assets.Scripts.Player;
using Assets.Scripts.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
   [SerializeField] GameObject _pauseMenu;
   [SerializeField] GameObject pauseButton;
   [SerializeField] Player player;
    private void OnEnable()
    {
        player.OnDied += ShowDieMenu;
        
    }

    private void ShowDieMenu()
    {
        pauseButton.SetActive(false);
        Pause.GamePause();

    }
    private void OnDisable()
    {
        player.OnDied -= ShowDieMenu;
    }

    public void OnClick()
    {
        Pause.GamePause();
        gameObject.SetActive(false);
        _pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }


}
