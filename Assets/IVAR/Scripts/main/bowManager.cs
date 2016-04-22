using UnityEngine;
//using System.Collections;

public class bowManager : MonoBehaviour
{
    public bool loaded = true;
   
    GameObject spawn;
    public GameObject arrowP;
    
    public bool _knockBack = false;
    public int force = 100;
    
    weaponManager wm;
    
	// Use this for initialization
	void Start ()
    {
        wm = GetComponent<weaponManager>();
        
        spawn = GameObject.Find("bow/spawn");
	}
	
	// Update is called once per frame
	void Update ()
    {   
        if(wm.attackType > 0)
        {
            wm.attackType = 0;
            
            GameObject arrow;
            
            arrow = Instantiate(arrowP, spawn.transform.position, spawn.transform.rotation) as GameObject;
            
            arrow.GetComponent<Rigidbody>().AddForce(transform.forward * force);
        }
        
        if(wm.attackType == 2)
        {   
            _knockBack = true;
        }
	}
}