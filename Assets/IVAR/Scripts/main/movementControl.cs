using UnityEngine;
//using System.Collections;

public class movementControl : MonoBehaviour
{
    // GameManager instance
    gameManager GM;

    Animator anim;
    public float gravity = 9.81f;
    public Vector3 movement;
    public float speed = 0.8f;
    public string state = "idle";

    public bool _isAttacking = false;

    // Use this for initialization
    void Start()
    {
        GM = gameManager.GetInstance();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.IsPlaying())
        {
            Move();
            LookAtMouse();

            /*if (anim.GetCurrentAnimatorStateInfo(0).IsName("standing_melee_attack_360_low") || anim.GetCurrentAnimatorStateInfo(0).IsName("standing_melee_attack_horizontal"))
                state = "attacking";*/
        }
    }

    void LookAtMouse()
    {
        Ray cameraRay;                // The ray that is cast from the camera to the mouse position
        RaycastHit cameraRayHit;    // The object that the ray hits

        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // If the ray strikes an object...
        if (Physics.Raycast(cameraRay, out cameraRayHit))
        {
            // ...and if that object is the ground...
            if (cameraRayHit.transform.tag == "floor")
            {
                // ...make the cube rotate (only on the Y axis) to face the ray hit's position 
                Vector3 targetPosition = new Vector3(cameraRayHit.point.x, transform.position.y, cameraRayHit.point.z);
                transform.LookAt(targetPosition);
            }
        }
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        movement = (v * Vector3.forward + h * Vector3.right) * speed;

        CharacterController cc = GetComponent<CharacterController>();

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }


        if (movement.x != 0 || movement.z != 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);

            state = "moving";
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);

            state = "idle";
        }

        movement.y -= gravity;

        cc.Move(movement * Time.deltaTime);

    }
}