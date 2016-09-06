using UnityEngine;
using System.Collections;

public class FightManager : MonoBehaviour {

    public Material Donjon;
    public Material FightGrass;
    public GameObject[] Ennemy;
    public int ID;
    public int IdMob;
    public 

	// Use this for initialization
	void Start () {
        Vector3 position = new Vector3(1, 1, 1);

        switch (ID)
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

        /*if (IdMob == 0)
        {
            GameObject ennemy = Ennemy[0];
            Instantiate(ennemy, position, Quaternion.identity);
        }*/
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetScene(int idFight, int idmob)
    {
        Vector3 position = new Vector3(1, 1, 1);

        switch(idFight)
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

        if(idmob == 0)
        {
            GameObject ennemy = Ennemy[0];
            Instantiate(ennemy, position, Quaternion.identity);
        }
    }
}
