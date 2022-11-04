using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WallPlayerTrigger : MonoBehaviour
{
    public const int PLAYER_LAYER = 6;

    [SerializeField] ParticleSystem particle;
    [SerializeField] MovementPlayer movement;
    public static bool inDash { get; private set; }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == MovementPlayer.LAYER_WALL)
        {
            inDash = false;
            movement.Flip();
            particle.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == MovementPlayer.LAYER_WALL)
        {
            inDash = true;
            particle.Stop();
        }
    }
}
