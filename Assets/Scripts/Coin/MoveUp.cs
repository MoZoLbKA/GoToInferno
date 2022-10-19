using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour,IMove
{
    [SerializeField] private float speed;

    public void Move()
    {
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
        transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
    }

    void Update()
    {
        Move();
    }
}
