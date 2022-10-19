using Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Orientation
{
    Right,
    Left,
}
public class MovementPlayer : MonoBehaviour,IBeginDragHandler,IDragHandler

{
    public const int LAYER_WALL = 3;
    [SerializeField] private Transform wallChecker;
    private Player player;
    [SerializeField] private GameObject playerGameObj;
    
    private Orientation orientation = Orientation.Right;

    public IMove MoveStrategy { private get; set; }
    public Orientation Orientation => orientation;
    private Rigidbody2D rb;
    private Animator anim;  
    public void Flip()
    {
        if (orientation == Orientation.Left)
        {
            orientation = Orientation.Right;
            playerGameObj.transform.Rotate(0, 180, 0);
        }
        else
        {
            orientation = Orientation.Left;
            playerGameObj.transform.Rotate(0, 180, 0);
        }
    }
    private void Start()
    {       
        rb = playerGameObj.GetComponent<Rigidbody2D>();
        player = playerGameObj.GetComponent<Player>();
        anim = playerGameObj.GetComponent<Animator>();
        MoveStrategy = new FreeMoveInDash(anim, player, rb, playerGameObj.GetComponent<ParticleSystem>(),this);    
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {           
            if (eventData.delta.x > 0)
            {
                orientation = Orientation.Right;            
            }
            else
            {
                orientation = Orientation.Left;
            }            
            MoveStrategy.Move();
                   
           

        }
    }
    public void OnDrag(PointerEventData eventData)
    {
    }
}
