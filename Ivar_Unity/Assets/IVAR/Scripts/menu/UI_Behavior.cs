using UnityEngine;
using UnityEngine.SceneManagement;
//using System.Collections;

public class UI_Behavior : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void LoadGame(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}