using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCoinHandler : MonoBehaviour
{
    const int coinLayerMask = 7;
    public delegate void OnCoinChange();
    public event OnCoinChange OnChange;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.layer == 8)
            Debug.Log(11);
        if (collision.gameObject.layer == coinLayerMask)
        {
            collision.isTrigger = false;
            Destroy(collision.gameObject);
            OnChange?.Invoke();
        }
    }  
}
