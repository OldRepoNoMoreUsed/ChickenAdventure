using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPC : Items {

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

    // Use this for initialization
    void Start () {

		Id = 4;
        Ui = GameObject.Find ("Canvas").GetComponent<UI>();
	}

	public void OnUse () {

		Ui.StartConversation (this, Face);
		Ui.SaySomething (Hello);
		Ui.SetAnswers (Choice0, Choice1, Choice2);
	}

	public void Answer(int R){
        if (IndexConv > 0)
        {
            IndexConv = 0;
			EndConversation ();
        }
        else
        {
            switch (R)
            {
                case 0:
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

	private void EndConversation(){
		Ui.CloseConversation();
		switch (IdAction) {
			case 1:
				Application.LoadLevel (paramAction);
				break;
			default:
				break;
		}
	}
}