using UnityEngine;
using System.Collections;

public class BatonNul : Arme {

    public BatonNul() : base()
    {
        this.Dmg = 0;
        this.coutFeu = 50;
        this.coutGlace = 50;
        this.coutFoudre = 50;
        this.coutSoin = 10;
    }
}
