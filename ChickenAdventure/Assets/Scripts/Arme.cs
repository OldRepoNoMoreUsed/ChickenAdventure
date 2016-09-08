using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Arme{

    private int dmg;

    public int Dmg
    {
        get
        {
            return dmg;
        }
        set
        {
            dmg = value;
        }
    }

    public int coutFeu { get; set; }
    public int coutGlace { get; set; }
    public int coutFoudre { get; set; }
    public int coutSoin { get; set; }

}
