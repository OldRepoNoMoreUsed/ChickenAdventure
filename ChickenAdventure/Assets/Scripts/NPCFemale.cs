using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCFemale : Items {

	public Sprite Face;
	private Text NPCText;

	private UI Ui;

	// Use this for initialization
	void Start () {

		Id = 4;
	}

	public void OnUse () {
		print ("usususus");

		Ui = GameObject.Find ("Canvas").GetComponent<UI>();
		Ui.StartConversation (this, Face);
		Ui.SaySomething ("Salut, je m'appelle Ivonne");
		Ui.SetAnswers ("Fais moi un Sandwich !!", "Taguleueeleu", "Combien la passe ?");

		/*
		NPCText = GameObject.Find ("NPCText").GetComponent<Text> ();
		NPCText.enabled = true;
		NPCText.text = "Je suis une connasse";
		*/
	}

	public void Answer(int R){
		switch (R) {
			case 0:
				Ui.SaySomething ("Oui, je suis une femme, je suis là pour ça");
				break;
			case 1:
				Ui.SaySomething ("Mais toi ferme ta gueule enkulasse de pute");
				break;
			case 2:
				Ui.SaySomething ("Va te faire ta mère plutot");
				break;
			default:
				Ui.CloseConversation ();
				break;
		}
        Ui.SetAnswers("...", "...", "Adieu");
	}
}