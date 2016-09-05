using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour {

    private int id;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    public void onUse() { }

    public int getId() { return id; }
    public void setId(int i) { id = i; }
}
