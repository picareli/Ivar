using UnityEngine;

public class gameManager : MonoBehaviour
{
    private static gameManager _instance;

    public enum GameState { PLAYING, PAUSED };

    private GameState _currentState;

    private GameObject _currentWeapon;

    public static gameManager GetInstance()
    {
        if (_instance == null)
        {
            Instantiate(Resources.Load("Prefabs/GOD"));
        }

        return _instance;
    }

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (_instance != null)
            Destroy(_instance.gameObject);

        _instance = this;

        _currentState = GameState.PLAYING;
    }

    void Start ()
    {
        _currentWeapon = GameObject.Find("HandMadeAxe");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPlaying())
            {
                Pause();
                gameUI.EnableMenu(true);
            }
            else
            {
                Resume();
                gameUI.EnableMenu(false);
            }
        }
    }

    public void Resume()
    {
        _currentState = GameState.PLAYING;
    }

    public void Pause()
    {
        _currentState = GameState.PAUSED;
    }

    public bool IsPlaying()
    {
        if (_currentState == GameState.PLAYING)
            return true;
        else
            return false;
    }

    public GameObject GetCurrentWeapon()
    {
        return _currentWeapon;
    }

    public void SetCurrentWeapon(GameObject newWeapon)
    {
        _currentWeapon = newWeapon;
    }
}