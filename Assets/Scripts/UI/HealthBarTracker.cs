
using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarTracker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject playerGameObj;

    private Player _player;
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
        _player = playerGameObj.GetComponent<Player>();
        _player.OnHealthHandleer += ChangeHitBar;
    }
    private void ChangeHitBar()
    {
        if (_player.CurrentHealth >= 0)
            image.fillAmount = (float)_player.CurrentHealth / _player.MaxHealth;
        else
            image.fillAmount = 0;
    }
    private void OnDisable()
    {
        _player.OnHealthHandleer -= ChangeHitBar;
    }
}
