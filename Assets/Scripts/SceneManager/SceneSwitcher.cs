using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{    
    public void  OnPlayClick()
    {
        StartCoroutine(LoadGameScene());
    }
    public void OnMainMenuClick()
    {
        StartCoroutine(LoadMainMenu());
    }
    private IEnumerator LoadMainMenu()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("MainMenu");
        while (!async.isDone)
        {
            yield return null;
        }
    }

    private IEnumerator LoadGameScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("GameScene");
        Pause.ResumeGame();
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
