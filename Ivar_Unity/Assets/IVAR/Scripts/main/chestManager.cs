using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;

public class chestManager : MonoBehaviour
{
    public bool used = false;
    
    public GameObject content, activeWeapon;
    public RectTransform chest;
    public GameObject text;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if(!used)
        {
            text.SetActive(true);

            if (Input.GetMouseButtonDown(1))
            {
                chest.gameObject.SetActive(true);
                
                GetComponent<Animator>().Play("open");
            }
        }
    }

    void OnMouseExit()
    {
        text.SetActive(false);
    }

    public void DisableUI()
    {
        chest.gameObject.SetActive(false);
    }
    
    public void toggleWeapon ()
    {
        activeWeapon.SetActive(false);
        
        content.SetActive(true);
    }
    
    public void setUsed(bool value)
    {
        used = value;
    }
}