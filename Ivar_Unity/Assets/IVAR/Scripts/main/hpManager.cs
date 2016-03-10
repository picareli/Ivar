using UnityEngine;
using UnityEngine.UI;
//using System.Collections;

public class hpManager : MonoBehaviour
{
    public int maxHP = 100;
	public int health = 100;

    public int consumable = 50;
    
    public Text gameOver;
    
    void Start()
    {
        gameOver = GameObject.Find("gameOver").GetComponent<Text>();
    }
    
	void OnTriggerEnter(Collider col)
	{
		if(this.tag == "Player" && col.tag == "enemy")
		{
			getDmg(col);
		}
		else if(this.tag == "enemy" && col.tag == "weapon")
		{
			getDmg(col);

			int type = col.GetComponent<weaponManager>().attackType;

			if(type == 2)
			{
				GetComponent<enemyMove>().knockedBack = true;
			}
		}
        else if(this.tag == "enemy" && col.tag == "arrow")
        {
            weaponManager wm = GameObject.Find("bow").GetComponent<weaponManager>();
            
            health -= wm.damage;
            
            if(wm.attackType == 2)
            {
                GetComponent<enemyMove>().knockedBack = true;
            }
        }
        
        if(this.tag == "Player" && col.tag == "consumable")
        {
            if(health != 100)
               Destroy(col.gameObject);
               
            int newHP = health + consumable;
            
            if((newHP + health) > maxHP)
            {
                health = 100;
            }
            else
            {
                health = newHP;
            }
        }
	}

	public void getDmg(Collider col)
	{
		health -= col.GetComponent<weaponManager>().damage;
		
		print(col.tag + " attacked " + this.tag);
	}

	void Update ()
	{
		if(health <= 0)
		{
			this.gameObject.SetActive(false);
            
            if(this.name == "boss")
            {
                gameOver.text = "LEVEL COMPLETE!";
            }
		}
	}
}