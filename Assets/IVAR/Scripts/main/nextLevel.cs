using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    // GM Instance
    gameManager GM;
    // UI Variables
    public RectTransform nextLevelUI;
    bool inTrigger = false;

    public GameObject uiText;

    // Use this for initialization
    void Start()
    {
        GM = gameManager.GetInstance();

        uiText = (GameObject)Instantiate(Resources.Load("Prefabs/txt_nextLevel"));
        uiText.transform.SetParent(GameObject.Find("UI_Game").GetComponent<Transform>());
        uiText.SetActive(false);
    }

    void Update()
    {
        uiText.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(2, 4, 0));
    }

    void OnMouseOver()
    {
        uiText.SetActive(true);

        if (Input.GetMouseButtonDown(1))
        {
            nextLevelUI.gameObject.SetActive(true);

            GM.Pause();
        }
    }

    public void LoadNextLevel(string myLevel)
    {
        GM.Resume();
        SceneManager.LoadScene(myLevel);
    }

    public void ResumeGame()
    {
        GM.Resume();
    }
}