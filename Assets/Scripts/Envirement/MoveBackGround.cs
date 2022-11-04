using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour,IMove
{
    private Vector2 startPos;
    [SerializeField]
    float heightBackGround;
    [SerializeField] private float speed;
    public float SpeedOfCamera => speed;

    public void Move()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        if (startPos.y < -heightBackGround + transform.position.y)
        {
            transform.position = startPos;
        }
    }

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Move();
    }
}
