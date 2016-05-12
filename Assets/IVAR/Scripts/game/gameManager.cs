using UnityEngine;

public class gameManager : MonoBehaviour
{
    bool isPaused = false;
    bool levelObjective = false;

    // Use this for initialization
    void Awake()
    {   
        DontDestroyOnLoad(this);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static gameManager getGM()
    {
        return GameObject.Find("GOD").GetComponent<gameManager>();
    }

    public bool getPaused()
    {
        return isPaused;
    }

    public void setPaused(bool value)
    {
        isPaused = value;
    }

    public void pauseGame()
    {
        //disable player
        //disable enemies
    }

    public void setLevelObjective(bool myValue)
    {
        levelObjective = myValue;
    }

    public bool getLevelObjective()
    {
        return levelObjective;
    }
    
    void OnLevelWasLoaded()
    {
        levelObjective = false;
    }
}