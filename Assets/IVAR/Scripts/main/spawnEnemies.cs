using UnityEngine;
using System.Collections;

public class spawnEnemies : MonoBehaviour
{
	public GameObject enemy;

	bool active = false;

	void OnTriggerEnter (Collider col)
	{
		if(col.tag == "Player" && !active)
		{
			Instantiate(enemy, transform.position, transform.rotation);

			print("Spawn");

			active = true;
		}
	}
}