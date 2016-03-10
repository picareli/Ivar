using UnityEngine;
//using System.Collections;

public class weaponManager : MonoBehaviour
{
    public int damage = 50;
    public int attackType = 0;
    
    // Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButtonDown(0) && attackType == 0)
            attackType = 1;
        if(Input.GetMouseButtonDown(1) && attackType == 0)
            attackType = 2;
	}
}