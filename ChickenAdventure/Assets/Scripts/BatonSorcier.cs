using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BatonSorcier : Arme {

	public BatonSorcier () : base()
    {
        this.Dmg = 5;
        this.coutFeu = 10;
        this.coutGlace = 8;
        this.coutFoudre = 5;
        this.coutSoin = 10;
	}
}
