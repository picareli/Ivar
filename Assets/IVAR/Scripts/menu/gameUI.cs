using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameUI : MonoBehaviour
{
    // GameManager Instance
    gameManager GM;

    // Escape Menu GameObject
    public static GameObject escapeMenu;

    public GameObject player;

    //public Text hp;
    public Slider hpField;
    public GameObject gameOver;

    void Awake()
    {
        GM = gameManager.GetInstance();

        escapeMenu = GameObject.Find("ui_menu");
    }

    void Start()
    {
        if (escapeMenu)
            print(escapeMenu);
        else
            print("EM not found");

        EnableMenu(false);
    }

    // Update is called once per frame
    void Update()
    {
        int playerHP = player.GetComponent<hpManager>().health;

        if (player)
            //hp.text = playerHP.ToString();
            hpField.value = playerHP;

        if (playerHP <= 0)
        {
            gameOver.SetActive(true);
        }
    }

    public void tryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void EnableMenu(bool newState)
    {
        escapeMenu.SetActive(newState);
    }

    public void ToggleMenu()
    {
        if(escapeMenu.activeInHierarchy)
        {
            EnableMenu(false);
            GM.Resume();
        }
        else
        {
            EnableMenu(true);
            GM.Pause();
        }
    }
}