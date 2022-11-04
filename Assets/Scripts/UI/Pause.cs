using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public static class Pause
    {      
        public static void GamePause()
        {
            Time.timeScale = 0;
        }
        public static void ResumeGame()
        {
            Time.timeScale = 1;
        }
    }
}
