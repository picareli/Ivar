using UnityEngine;

public class gameFinished : MonoBehaviour
{
    gameManager god;
    bool continue_ = false;

    public RectTransform gameDone;

    // Use this for initialization
    void Start()
    {
        god = gameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (god.getLevelObjective() && !gameDone.gameObject.activeSelf && !continue_)
        {
            gameDone.gameObject.SetActive(true);
        }*/
    }

    public void setContinue(bool myBool)
    {
        continue_ = myBool;
    }
}