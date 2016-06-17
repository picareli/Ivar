using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Behavior : MonoBehaviour
{
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