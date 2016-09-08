using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPC : Items
{

    public Sprite Face;
    private Text NPCText;

    private int IndexConv = 0;

    private UI Ui;

    public string Hello;
    public string Choice0;
    public string Answer0;
    public string Choice1;
    public string Answer1;
    public string Choice2;
    public string Answer2;

    public string Goodbye0;
    public string Goodbye1;
    public string Goodbye2;

    public int IdAction;
    public string paramAction;

    private AudioSource audio;
    private AudioSource audioEaster;
    private bool easterEgg = false;

    // Use this for initialization
    void Start()
    {

        Ui = GameObject.Find("Canvas").GetComponent<UI>();

        if (this.GetComponent<AudioSource>() != null)
        {
            audioEaster = GetComponent<AudioSource>();
            audioEaster.Stop();
        }

    }

    public void OnUse()
    {

        Ui.StartConversation(this, Face);
        Ui.SaySomething(Hello);
        Ui.SetAnswers(Choice0, Choice1, Choice2);
    }

    public void Answer(int R)
    {
        print("Answer");
        if (IndexConv > 0)
        {
            IndexConv = 0;
            EndConversation();
        }
        else
        {
            switch (R)
            {
                case 0:
                    if (this.GetComponent<AudioSource>() != null)
                    {
                        easterEgg = true;
                    }
                    Ui.SaySomething(Answer0);
                    break;
                case 1:
                    Ui.SaySomething(Answer1);
                    break;
                case 2:
                    Ui.SaySomething(Answer2);
                    break;
                default:
                    Ui.CloseConversation();
                    break;
            }
            Ui.SetAnswers(Goodbye0, Goodbye1, Goodbye2);
            IndexConv++;
        }

    }

    private void EndConversation()
    {
        Ui.CloseConversation();
        print("End conv");
        print(IdAction);
        switch (IdAction)
        {
            case 1:
                print("TP");
                Application.LoadLevel(paramAction);
                break;
            case 2:
                if (easterEgg)
                {
                    audio = GameObject.Find("Audio").GetComponent<AudioSource>();
                    audio.Stop();
                    audioEaster.Play();
                }
                break;
            default:
                break;
        }
    }
}