using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0f, 7.5f, 0f);


        private void LateUpdate()
        {
            transform.position = target.position + offset;
        }

		void Update ()
		{
			if(Input.GetKeyUp(KeyCode.Escape))
			{
				SceneManager.LoadScene(0);
			}
		}
    }
}