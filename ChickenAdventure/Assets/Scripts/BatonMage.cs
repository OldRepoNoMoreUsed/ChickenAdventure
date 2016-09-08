using UnityEngine;
using System.Collections;

public class BatonMage : Arme {

    public BatonMage() : base()
    {
        this.Dmg = 55;
        this.coutFeu = 1;
        this.coutGlace = 2;
        this.coutFoudre = 5;
        this.coutSoin = 10;
    }
}
