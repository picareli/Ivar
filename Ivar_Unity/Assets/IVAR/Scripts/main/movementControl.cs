using UnityEngine;
//using System.Collections;

public class movementControl : MonoBehaviour
{
	public float gravity = 9.81f;
	Vector3 movement;
	public float speed = 0.8f;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		Move();
		LookAtMouse();
	}

	void LookAtMouse ()
	{
		Ray cameraRay;                // The ray that is cast from the camera to the mouse position
		RaycastHit cameraRayHit;    // The object that the ray hits

		cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		// If the ray strikes an object...
		if (Physics.Raycast(cameraRay, out cameraRayHit)) 
		{
			// ...and if that object is the ground...
			if(cameraRayHit.transform.tag == "floor")
			{
				// ...make the cube rotate (only on the Y axis) to face the ray hit's position 
				Vector3 targetPosition = new Vector3(cameraRayHit.point.x, transform.position.y, cameraRayHit.point.z);
				transform.LookAt(targetPosition);
			}
		}
	}

	void Move ()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		
		movement = v*Vector3.forward * speed + h * Vector3.right * speed;
		
		CharacterController cc = GetComponent<CharacterController>();

		movement.y -= gravity;
		
		cc.Move(movement * Time.deltaTime);
	}
}