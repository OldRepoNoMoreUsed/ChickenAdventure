using UnityEngine;
using System.Collections;
using System;

public class Player : MovingObject {

    private Animator animator;
    public AudioClip ambiance;

	// Use this for initialization
	protected override void Start () {
        animator = GetComponent<Animator>();
        base.Start();

	}

    protected override void AttemptMove<T>(float xDir, float yDir)
    {
        base.AttemptMove<T>(xDir, yDir);

        RaycastHit2D hit;

        return;

        
    }

    // Update is called once per frame
    void Update () {
        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
        {
            vertical = 0;
        }

        if (horizontal != 0 || vertical != 0)
        {
            //AttemptMove<Wall>(horizontal/5.0f, vertical/5.0f);
            AttemptMove<Chest>(horizontal/5.0f, vertical/5.0f);

            if(horizontal == -1)
            {
                animator.SetTrigger("PlayerWalkLeftTrig");
            }
            else if(horizontal == 1)
            {
                animator.SetTrigger("PlayerWalkRightTrig");
            }
            else if(vertical == 1)
            {
                animator.SetTrigger("PlayerWalkUpTrig");
            }
            else if(vertical == -1)
            {
                animator.SetTrigger("PlayerWalkDownTrig");
            }
        }
        else
        {
            animator.SetTrigger("IDLE");
        }

    }

    protected override void OnCantMove<T>(T component)
    {
        Chest chest = component as Chest;
        chest.onUse();
        /*if(component.GetType() is Chest)
        {

        }*/
    }
}
