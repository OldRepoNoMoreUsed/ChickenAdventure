using UnityEngine;
using System.Collections;

public class Chest : Items
{

    private Animator animator;
    private AudioSource audio;
    private UI ui;
    public string Text;
    private bool open = false;
    private Arme arme;
    public int IdArme;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        Id = 1;
        if(IdArme == 0)
        {
            arme = new BatonSorcier();
        }
        if(IdArme == 1)
        {
            arme = new BatonMage();
        }
        if(IdArme == 2)
        {
            arme = new BatonNul();
        }
    }

    public void OnUse()
    {
        if (!open)
        {
            animator.SetTrigger("Open");
            audio.Play();
            ui.StartConversation(this);
            ui.SaySomething(Text);
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

    public Arme getArme()
    {
        return arme;
    }
}