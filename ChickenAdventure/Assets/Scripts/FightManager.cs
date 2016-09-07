using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FightManager : MonoBehaviour {

    public Material Donjon;
    public Material FightGrass;
    public GameObject[] Ennemy;
    public GameObject Boss1;
    public int ID;
    public int IdMob;
    public int Column = 8;
    public int Rows = 8;
    private Player player;

	private UI Ui;

    private Transform boardHolder;
    private List<Vector3> gridPosition = new List<Vector3>();

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
            Instantiate(ennemy, position, Quaternion.identity);
        }
        player.animator.SetTrigger("PlayerWalkLeftTrig");

		Ui = GameObject.Find ("Canvas").GetComponent<UI>();
		Ui.StartFight (this);
    }

	public void CastSpell(int IdSpell){
		print ("Je lance un sort !!");
		print (IdSpell);
	}

}
