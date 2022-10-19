
using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarTracker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player;

    private Player health;
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
        health = player.GetComponent<Player>();
        health.OnHealthHandleer += ChangeHitBar;
    }
    private void ChangeHitBar()
    {
        if (health.CurrentHealth >= 0)
            image.fillAmount = (float)health.CurrentHealth / health.MaxHealth;
        else
            image.fillAmount = 0;
    }
    private void OnDisable()
    {
        health.OnHealthHandleer -= ChangeHitBar;
    }
}
