using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour
{
    private Vector2 startPos;
    [SerializeField]
    float heightBackGround;
    [SerializeField] private float speed;
    public float SpeedOfCamera => speed;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        if (startPos.y <-heightBackGround + transform.position.y)
        {
            transform.position = startPos;
        }
    }
}
