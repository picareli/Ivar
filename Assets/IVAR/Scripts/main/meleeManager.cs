using UnityEngine;
//using System.Collections;

public class meleeManager : MonoBehaviour
{
    weaponManager wm;
    
    void Start ()
    {
        wm = GetComponent<weaponManager>();
    }
    
	void Update ()
	{
        Animation anim = GetComponent<Animation>();
        
		if(this.tag == "weapon")
		{
			if(wm.attackType == 1)
            {
                GetComponent<Animator>().Play("attack_1");
                
                wm.attackType = 0;
            }
                

			if(wm.attackType == 2)
            {
                GetComponent<Animator>().Play("attack_2");
                wm.attackType = 0;
            }
		}
	}
	
	void playAttackAnim (string myAnim)
	{
		GetComponent<Animation>().Play(myAnim);
	}

	/*void managePlayingAnim()
	{
		Animation anim = GetComponent<Animation>();

		if(anim.IsPlaying("sword_attack"))
		{
			attackType = 1;
		}
		else if(anim.IsPlaying("sword_attack_2"))
		{
			attackType = 2;
		}
		else
		{
			attackType = 0;
		}
	}*/
}