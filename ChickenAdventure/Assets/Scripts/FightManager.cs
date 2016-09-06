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

    private Transform boardHolder;
    private List<Vector3> gridPosition = new List<Vector3>();

	// Use this for initialization
	void Start () {
        Vector3 position = new Vector2(-2.5f, 0);

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

        if (IdMob == 0)
        {
            GameObject ennemy = Boss1;
            Instantiate(ennemy, position, Quaternion.identity);
        }
    }

    void InitialiseList()
    {
        gridPosition.Clear(); 

        for(int x = 1; x < Column-1;x++)
        {
            for(int y = 1; y < Rows-1; y++)
            {
                gridPosition.Add(new Vector3(x, y, 0f));
            }
        }
    }
	
    public void SetScene(int idFight, int idmob)
    {
        switch (idFight)
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

        Vector3 position = new Vector3(-1, 1, 1);
        boardHolder = new GameObject("Board").transform;

        if(idmob == 0)
        {
            GameObject ennemy = Ennemy[0];
            Instantiate(ennemy, position, Quaternion.identity);
        }
    }
}
