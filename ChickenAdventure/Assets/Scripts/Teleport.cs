using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour 
{

	public string levelname = "Level name";

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Application.LoadLevel (levelname);
			print ("Loadddddd");
		}
	}
}