using UnityEngine;
using System.Collections;

public class Chest : Items {

    private Animator animator;
    private bool open = false; 

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        setId(1); 
	}
	
	public void onUse()
    {
        if (!open)
        {
            animator.SetTrigger("Open");
            print("Tu ouvres un coffre");
        }
    }
}
