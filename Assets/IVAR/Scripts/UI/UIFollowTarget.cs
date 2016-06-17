using UnityEngine;

public class UIFollowTarget : MonoBehaviour
{
    private Transform target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target && target.GetComponent<hpManager>().boss)
            transform.position = Camera.main.WorldToScreenPoint(target.position + new Vector3(0, 4.0f, 0));
        else if (target)
            transform.position = Camera.main.WorldToScreenPoint(target.position + new Vector3(0, 2.5f, 0));
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}