using UnityEngine;
using System.Collections;

public class Boss : Items{

	// Use this for initialization
	void Start () {
        Id = 2;
	}

	public void OnUse () {
        print("Tu touches le boss !");
	}
}
