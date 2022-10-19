using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCountOfCoins : MonoBehaviour
{    
    [SerializeField] GameObject player;
    private OnCoinHandler handler;
    private TMP_Text text; 
    void Start()
    {
        handler = player.GetComponent<OnCoinHandler>();
        text = GetComponent<TMP_Text>();
        handler.OnChange += ChangeValue;
    }
    void ChangeValue()
    {
        if (!int.TryParse(text.text, out int value))
        {
            return;
        }
        text.text = (value+1).ToString();
    }
    private void OnDisable()
    {
        handler.OnChange -= ChangeValue;
    }
}
