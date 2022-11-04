using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorSwitcher : MonoBehaviour
{
    private float timer = 0f;
    private float timeToNeedRunSleepyAnimation = 15f;
    private Animator playerAnimator;
    [SerializeField] private AnimationClip foolAnimation;
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.touchCount!=0)
        {
            timer = 0;
        }
        if (timer >= timeToNeedRunSleepyAnimation)
        {
            playerAnimator.SetTrigger("Zzz");
            timer = 0;
        }
    }
    public void SetFoolTrigger()
    {             
        playerAnimator.SetTrigger("Fool");        
    }
}
