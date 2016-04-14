using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Behavior : MonoBehaviour
{
    public GameObject escapeMenu;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escapeMenu.SetActive(!escapeMenu.active);            
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGame(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}