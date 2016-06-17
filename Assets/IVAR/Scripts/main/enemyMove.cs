using UnityEngine;
using UnityEngine.UI;
//using System.Collections;

public class enemyMove : MonoBehaviour
{
    // GM Instance
    gameManager GM;
    hpManager hpM;

    // HP GameObject and Image instances
    GameObject HP;
    Image myHP;
    public TextMesh enemyHP;

    public Transform target;

    public int MoveSpeed = 4;
    public int MaxDist = 10;
    public float MinDist = 1.5f;

    public float gravity = 9.81f;

    public bool knockedBack = false;

    public string state = "idle";

    public bool _isAttacking = false;

    void Awake()
    {
        HP = (GameObject)Instantiate(Resources.Load("Prefabs/img_enemyhp"));
        HP.transform.SetParent(GameObject.Find("UI_Game").transform);
        HP.GetComponent<UIFollowTarget>().SetTarget(this.gameObject.transform);
        myHP = HP.GetComponent<Image>();
    }

    void Start()
    {
        target = GameObject.Find("Player").transform;

        hpM = GetComponent<hpManager>();
        GM = gameManager.GetInstance();
    }

    void Update()
    {
        if (GM.IsPlaying())
        {
            Animator anim = GetComponentInParent<Animator>();

            if (target)
            {
                //enemyHP.text = this.GetComponent<hpManager>().health.ToString();
                myHP.fillAmount = (hpM.health / (float)hpM.maxHP);

                if (myHP.fillAmount == 0)
                    Destroy(HP);

                Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
                transform.LookAt(targetPos);

                if (Vector3.Distance(transform.position, target.position) >= MinDist && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    Vector3 moveVector = target.position - transform.position;

                    CharacterController cc = GetComponent<CharacterController>();

                    moveVector = moveVector.normalized * MoveSpeed;

                    moveVector.y -= gravity * Time.deltaTime;

                    if (knockedBack)
                    {
                        //GetComponent<Animation>().Play("knock_back");
                    }

                    cc.Move(moveVector * Time.deltaTime);
                }
                else
                {
                    anim.Play("Attack");
                }
            }
        }
    }
}