using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FightManager : MonoBehaviour {

    public Material Donjon;
    public Material FightGrass;
    public GameObject Ennemy;
    public GameObject Boss1;
    public GameObject sort;

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
            GameObject ennemy = Boss1;
            EnnemyDef = 10;
            EnnemyAttack = 10;
            Instantiate(ennemy, position, Quaternion.identity);
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
        int dommage = player.calculDmg(EnnemyDef);
        print(dommage);
        EnnemyPV -= dommage;
        Vector3 position = new Vector2(-2.5f, -0.2f);
        animator = sort.GetComponent<Animator>();
        Instantiate(sort, position, Quaternion.identity);
        sort.animator.SetTrigger("cast");
        if(EnnemyPV <= 0)
        {
            print("Ennemi mort");
        }
        else
        {
            player.DecreaseHP(EnnemyAttack);
        }
    }

    public void IceSpell()
    {
        print("Libéré délivré !! ");
    }

    public void ThunderSpell()
    {
        print("Thunder, thunder, thunder, thunder");
    }

    public void CureSpell()
    {
        print("Cure"); 
    }

}
