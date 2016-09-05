using UnityEngine;
using System.Collections;

public class Wall : Items {

	// Use this for initialization
	void Start () {
        Id = 3;
	}
	
	// Update is called once per frame
	void OnUse () {
        print("Tu heurtes un mur");
	}
}
