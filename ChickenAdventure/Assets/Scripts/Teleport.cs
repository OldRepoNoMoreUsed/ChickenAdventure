using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour 
{

	public string levelname = "Level name";
	public float x = 0;
	public float y = 0;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Application.LoadLevel (levelname);
			other.transform.position = new Vector3(x, y);
			print (x);
			print (y);
		}
	}
}