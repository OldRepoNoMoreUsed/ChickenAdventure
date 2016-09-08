using UnityEngine;
using System.Collections;

public class Chest : Items
{

    private Animator animator;
    private AudioSource audio;
    private UI ui;
    public string text;
    private bool open = false;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        Id = 1;
    }

    public void OnUse()
    {
        if (!open)
        {

            animator.SetTrigger("Open");
            audio.Play();
            ui.StartConversation(this);
            ui.SaySomething(text);
			ui.SetAnswers("Seulement ça !!","OK", "Merci beaucoup");

            print("Blabla");
            open = true;
        }
        else
        {
            print("Coffre déja ouvert");
        }
    }

    public void answer(int btn)
    {
        print("close");
        ui.CloseConversation();
    }
}