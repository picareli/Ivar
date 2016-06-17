using UnityEngine;
using UnityEngine.SceneManagement;

public class chestManager : MonoBehaviour
{
    // GM Instance
    gameManager GM;

    // UI text insance
    GameObject uiText;

    public bool used = false;

    public GameObject content;	//activeWeapon;
    public RectTransform chest;
    //public GameObject text;

    // Use this for initialization
    void Start()
    {
        GM = gameManager.GetInstance();

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GM.SetCurrentWeapon(GameObject.Find("Mace"));
        }
            uiText = (GameObject)Instantiate(Resources.Load("Prefabs/txt_chest"));
        uiText.transform.SetParent(GameObject.Find("UI_Game").GetComponent<Transform>());
        uiText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        uiText.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 2, 0));
    }

    void OnMouseOver()
    {
        uiText.SetActive(true);

        if (Input.GetMouseButtonDown(1))
        {
            chest.gameObject.SetActive(true);
            GM.Pause();
            //GetComponent<Animator>().Play("open");
        }
    }

    void OnMouseExit()
    {
        uiText.SetActive(false);
    }

    public void DisableUI()
    {
        chest.gameObject.SetActive(false);
        GM.Resume();
    }

    public void toggleWeapon()
    {
        GameObject temp = content;  // Save content as temp

        GM.GetCurrentWeapon().SetActive(false);
        content = GM.GetCurrentWeapon();        // Save current weapon in chest

        GM.SetCurrentWeapon(temp);              // Set current temp as current weapon
        GM.GetCurrentWeapon().SetActive(true);
    }

    public void setUsed(bool value)
    {
        used = value;
    }
}