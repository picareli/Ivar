using UnityEngine;
using System.Collections;

public class lookAtScreen : MonoBehaviour
{
	public Transform target;

	// Use this for initialization
	void Start ()
	{
		target = GameObject.Find ("UI_target").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 targetPos = new Vector3(transform.position.x, target.position.y, target.position.z);
		transform.LookAt(targetPos);
	}
}