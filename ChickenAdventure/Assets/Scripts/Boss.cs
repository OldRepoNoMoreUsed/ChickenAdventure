using UnityEngine;
using System.Collections;

public class Boss : Items{

	// Use this for initialization
	void Start () {
        Id = 2;
	}
	
	// Update is called once per frame
	public void OnUse () {
        print("Tu touches le boss !");
	}
}
