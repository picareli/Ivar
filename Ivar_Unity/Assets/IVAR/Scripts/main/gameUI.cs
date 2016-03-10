using UnityEngine;
//using System.Collections;
using UnityEngine.UI;

public class gameUI : MonoBehaviour
{
	public GameObject player;

	//public Text hp;
    public Slider hpField;
	public Text gameOver;

	//public bool gameEnded = false;
	
	// Update is called once per frame
	void Update ()
	{
		int playerHP = player.GetComponent<hpManager>().health;

		if(player)
			//hp.text = playerHP.ToString();
            hpField.value = playerHP;

		if(playerHP <= 0)
		{
			gameOver.text = "Game Over\nYou are Dead";
		}
	}
}