using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FightManager : MonoBehaviour {

    public Material Donjon;
    public Material FightGrass;
    public GameObject Ennemy;
    public GameObject Boss1;
    public GameObject SortFeu;
    public GameObject SortGlace;
    public GameObject SortFoudre;
    public GameObject SortSoin;
    public GameObject DarkSpell;

    public int ID;
    public int IdMob;
    public int Column = 8;
    public int Rows = 8;
    private Player player;

	private UI Ui;

    private Transform boardHolder;
    private List<Vector3> gridPosition = new List<Vector3>();

    private int EnnemyPV = 100;
    private int EnnemyDef;
    private int EnnemyAttack;


	// Use this for initialization
	void Start () {
        Vector3 position = new Vector2(-2.5f, -0.2f);

        player = GameObject.Find("Player").GetComponent<Player>();
        player.transform.position = new Vector2(2.5f, -0.5f);
        player.inFight = true;

		print (player.FightID);

        switch (player.FightID)
        {
			case 1:
                RenderSettings.skybox = Donjon;
                break;
            case 2:
                RenderSettings.skybox = FightGrass;
                break;
            default:
                break;
        }

        if (player.FightIdMob == 0)
        {
            EnnemyDef = 10;
            EnnemyAttack = 10;
            Instantiate(Boss1, position, Quaternion.identity);
        }
        else if(player.FightIdMob == 1)
        {
            EnnemyDef = 2;
            EnnemyAttack = 2;
            EnnemyPV = 10;
            Instantiate(Ennemy, position, Quaternion.identity);
        }

        player.animator.SetTrigger("PlayerWalkLeftTrig");

		Ui = GameObject.Find ("Canvas").GetComponent<UI>();
		Ui.StartFight (this);
    }

	public void CastSpell(int IdSpell){
    
        switch(IdSpell)
        {
            case 0:
                FireSpell();
                break;
            case 1:
                IceSpell();
                break;
            case 2:
                ThunderSpell();
                break;
            case 3:
                CureSpell();
                break;
            default:
                break; 

        }
	}

    public void FireSpell()
    {
        if(player.mp >= player.armeEquipe.coutFeu)
        {
            int dommage = player.calculDmg(EnnemyDef);
            print(dommage);
            EnnemyPV -= dommage;
            Vector3 position = new Vector2(-2.5f, -0.2f);
            var obj = Instantiate(SortFeu, position, Quaternion.identity);
            Destroy(obj, 1);
            player.mp -= player.armeEquipe.coutFeu;
            player.ChangeUI();
        }

        StartCoroutine(x());
    }

    public void IceSpell()
    {
        if(player.mp >= player.armeEquipe.coutGlace)
        {
            int dommage = player.calculDmg(EnnemyDef);
            print(dommage);
            EnnemyPV -= dommage;
            Vector3 position = new Vector2(-2.5f, -0.5f);
            var obj = Instantiate(SortGlace, position, Quaternion.identity);
            Destroy(obj, 1);
            player.mp -= player.armeEquipe.coutGlace;
            player.ChangeUI();
        }
       
        StartCoroutine(x());
    }

    public void ThunderSpell()
    {
        if(player.mp >= player.armeEquipe.coutFoudre)
        {
            int dommage = player.calculDmg(EnnemyDef);
            print(dommage);
            EnnemyPV -= dommage;
            Vector3 position = new Vector2(-2.5f, -0.2f);
            var obj = Instantiate(SortFoudre, position, Quaternion.identity);
            Destroy(obj, 1);
            player.mp -= player.armeEquipe.coutFoudre;
            player.ChangeUI();
        }


        StartCoroutine(x());
    }

    public void CureSpell()
    {
        if(player.mp >= player.armeEquipe.coutSoin)
        {
            int dommage = player.calculDmg(EnnemyDef);
            print(dommage);
            EnnemyPV -= dommage;
            Vector3 position = new Vector2(2.5f, -0.1f);
            var obj = Instantiate(SortSoin, position, Quaternion.identity);
            Destroy(obj, 1);
            player.mp = player.mp - player.armeEquipe.coutSoin;
            player.IncreaseHP();
            player.ChangeUI();
        }

        StartCoroutine(x());
        

    }

    IEnumerator x()
    {
        Ui.Icespell.enabled = false;
        Ui.Firespell.enabled = false;
        Ui.Thunderspell.enabled = false;
        Ui.Curespell.enabled = false;
        yield return new WaitForSeconds(1);
        ennemyAttack();
        Ui.Icespell.enabled = true;
        Ui.Firespell.enabled = true;
        Ui.Thunderspell.enabled = true;
        Ui.Curespell.enabled = true;
    }

    private void ennemyAttack()
    {

        if (EnnemyPV <= 0)
        {
            Ui.CanvasFight.enabled = false;
            if (player.FightIdMob == 0)
            {
                player.inFight = false;
                Application.LoadLevel("endScene");
                player.transform.position = new Vector2(0, 0);
                player.Dance();
            }
            else if(player.FightIdMob > 0)
            {
                player.inFight = false;
                Application.LoadLevel(player.oldLevel);
                player.transform.position = new Vector2(player.oldPos.x, player.oldPos.y);
                player.gainXp();
            }


        }

        else if (player.FightIdMob == 0)
        {
            Vector3 position = new Vector2(2.5f, 0f);
            var obj = Instantiate(DarkSpell, position, Quaternion.identity);
            Destroy(obj, 1);
        }
        else if (player.FightIdMob == 1)
        {
            Animator anim;
            anim = Ennemy.GetComponent<Animator>();
            anim.SetTrigger("GoblinAttackTrig");

        }
        if (player.DecreaseHP(EnnemyAttack))
        {
            Ui.CanvasFight.enabled = false;
            player.hp = 100;
            player.mp = 100;
            player.inFight = false;
            Application.LoadLevel("INN");
            player.transform.position = new Vector2(-7f, -1f);
        }
        player.ChangeUI();
    }

}
