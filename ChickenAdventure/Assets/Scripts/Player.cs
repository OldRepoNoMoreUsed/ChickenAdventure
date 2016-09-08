using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Player : MovingObject {

    public  Animator animator;
	private Text textHP;
	private Text textMP;
    private Text lvl;

    public int hp = 100;
    public int mp = 100;
	public int xp = 0;
	public int niveau = 1; 
    public int baseAttack = 50;
    public Arme armeEquipe;
    public AudioClip ambiance;
    public Arme[] inventaire = new Arme[10];
    public int FightID { get; set; }
    public int FightIdMob { get; set; }
    public bool inFight = false;

    public string levelname = "Level name";
    public float x = 0;
    public float y = 0;

    public Vector2 oldPos;
    private float xact;
    private float yact;
    public String oldLevel;
    public bool win { get; set; }

    // Use this for initialization
    protected override void Start () {
        animator = GetComponent<Animator>();
        base.Start();
        armeEquipe = new BatonSorcier();

		InitGame ();
	}

    public int calculDmg(int def) {
        return (baseAttack + armeEquipe.Dmg-def)*niveau;
    }

    public bool DecreaseHP(int attack)
    {
        hp -= attack;

        if(hp <= 0)
        {
            return true;
        }
        return false;
    }

    public void IncreaseHP()
    {
        if(hp < 100)
        {
            hp += calculDmg(0) * 2;
        }

        if(hp > 100)
        {
            hp = 100;
        }
    }

	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}

    protected override void AttemptMove<T>(float xDir, float yDir)
    {
        base.AttemptMove<T>(xDir, yDir);
        return;
    }

    // Update is called once per frame
    void Update () {

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "FightScene")
        {
            oldLevel = scene.name;
            xact = this.transform.position.x;
            yact = this.transform.position.y;
            oldPos = new Vector2(xact, yact);
        }

        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
        {
            vertical = 0;
        }

        if(inFight)
        {
            animator.SetTrigger("PlayerWalkLeftTrig");
        }

        if ((horizontal != 0 || vertical != 0) && !inFight)
        {
            AttemptMove<Items>(horizontal/5.0f, vertical/5.0f);

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

	void InitGame()
	{
		textHP = GameObject.Find ("textHP").GetComponent<Text> ();
		textMP = GameObject.Find ("textMP").GetComponent<Text> ();
        lvl = GameObject.Find("Lvl").GetComponent<Text>();


        ChangeUI();
	}

    public void ChangeUI()
    {
        textHP.text = "Vie : " + hp;
        textMP.text = "Mana : " + mp;
        lvl.text = "Niveau : " + niveau;
    }

    protected override void OnCantMove<T>(T component)
    {
        Items item = component as Items;

        int d = item.Id;
        switch (d)
        {
            case 1:
                Arme a; 
                Chest chest = component as Chest;
                a = chest.getArme();
                armeEquipe = a;
                chest.OnUse();
                break;
			case 2:
				FightID = 1;
				FightIdMob = 0;
				NPC npc2 = component as NPC;
				npc2.OnUse ();
                break;
            case 3:
                hp = 100;
                mp = 100;
                ChangeUI();
                print(hp);
                NPC manatower = component as NPC;
                manatower.OnUse();
                break;
			case 4:
                print("truc");
				FightID = 1;
				FightIdMob = 0;
				NPC npc = component as NPC;
				npc.OnUse ();
				break;
            default:
                break;

        }        
    }

    bool RandomFight()
    {
        bool Value;

        int randomValue = Random.Range(0, 500); 

        if(randomValue < 1 )
        {
            return true;
        }

        return false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Fight")
        {
            if (RandomFight())
            {
                Application.LoadLevel(levelname);
                FightID = 2;
                FightIdMob = 1;
            }
        }     
    }

    public void Dance()
    {
        int i = 0;
        while(i < 10000)
        {
            animator.SetTrigger("PlayerWalkLeftTrig");
            animator.SetTrigger("PlayerWalkDownTrig");
            animator.SetTrigger("PlayerWalkRightTrig");
            animator.SetTrigger("PlayerWalkUpTrig");
            i++; 
        }
    }

    public void gainXp()
    {
        xp++;
        if(xp == niveau)
        {
            niveau++;
            xp = 0;
        }
    }
}
