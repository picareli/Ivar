using UnityEngine;
//using System.Collections;

public class enemyMove : MonoBehaviour
{
	public TextMesh enemyHP;

	public Transform target;
	
	public int MoveSpeed = 4;
	public int MaxDist = 10;
	public float MinDist = 1.5f;
    
    public float gravity = 9.81f;
    
    public bool knockedBack = false;
    public int force = 100;
    
    public string state = "idle";
    
	void Start ()
	{
		target = GameObject.Find("Player").transform;
	}
    
	void Update ()
	{
        Animator anim = GetComponentInParent<Animator>();
        
		if(target)
		{
			enemyHP.text = this.GetComponent<hpManager>().health.ToString();

			Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
			transform.LookAt(targetPos);
			
			if(Vector3.Distance(transform.position,target.position) >= MinDist && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
			{                
                Vector3 moveVector = target.position - transform.position;
                
                CharacterController cc = GetComponent<CharacterController>();
                
                moveVector = moveVector.normalized * MoveSpeed;
                
                moveVector.y -= gravity * Time.deltaTime;
                
                if(knockedBack)
                {
                    
                    //GetComponent<Animation>().Play("knock_back");
                }
                
                cc.Move(moveVector * Time.deltaTime);
                
                state = "moving";
			}
            else
            {
                anim.Play("Attack");
                
                state = "attacking";
            }
		}
	}
}