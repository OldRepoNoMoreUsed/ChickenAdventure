using UnityEngine;
using System.Collections;

public class Chest : Items {

    private Animator animator;
    private AudioSource audio;
    private bool open = false; 

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        Id = 1; 
	}
	
	public void OnUse()
    {
        if (!open)
        {
            animator.SetTrigger("Open");
            audio.Play();
            print("Tu ouvres un coffre");
            open = true;
        }
        else
        {
            print("Coffre déja ouvert");
        }
    }
}
