using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
   [SerializeField] GameObject _pauseMenu;
    public void OnClick()
    {
        Pause.GamePause();
        gameObject.SetActive(false);
        _pauseMenu.SetActive(true);
    }

}
