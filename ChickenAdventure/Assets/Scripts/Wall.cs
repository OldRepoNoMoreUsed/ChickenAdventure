using UnityEngine;
using System.Collections;

public class Wall : Items {

	// Use this for initialization
	void Start () {
        id = 3;
	}
	
	// Update is called once per frame
	void onUse () {
        print("Tu heurtes un mur");
	}
}
