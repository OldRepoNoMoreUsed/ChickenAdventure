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
}
