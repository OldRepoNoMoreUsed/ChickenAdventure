using UnityEngine;
using System.Collections;

public class Boss : Items{

	// Use this for initialization
	void Start () {
        id = 2;
	}
	
	// Update is called once per frame
	public void onUse () {
        print("Tu touches le boss !");
	}
}
