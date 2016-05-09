using UnityEngine;
//using System.Collections;

public class arrowManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        /*if (this.name != "arrow")
            this.name = "arrow";*/
            
        Destroy(this.gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Player")
            Destroy(this.gameObject);
    }
}