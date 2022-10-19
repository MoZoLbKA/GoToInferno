using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
        transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
    }
}
