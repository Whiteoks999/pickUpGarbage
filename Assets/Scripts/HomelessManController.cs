using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//для вывода текста

[RequireComponent(typeof(CharacterController))]

public class HomelessManController : MonoBehaviour
{
    public GameObject homelessMan;
    public Animator animator;
    public float Force=5;
    public float jumpSpeed = 10f;
    public CharacterController characterController;
    public MeshCollider coll;
    public float smootheTime;
    float smoothVelosity;
    public Transform firstCamera;
    public float gravity = 30.0f;

    public bool flag = true;


    public float currentSpeed;

    //это для мусора
    public int countGarbage = 0; //кол-во собранного мусора
    public int maxcountGarbage = 0; //кол-во необходимого мусора !изменяется в зависимости от уровня
    public List<GameObject> garbages=new List<GameObject>();
   // public GameObject garbage;
    public GameObject garbageCan;

    //для вывода кол-ва мусора
    public Text textcountGarbage; //вывод тек кол-ва мусора

    public GameObject vinImage;

    //а это для прыжка
    Vector3 moveDirection = Vector3.zero;


    public GameObject gameOver;

    [HideInInspector]
    public bool canMove = true;

    bool flag_g = false;
    public float directionY_;

    public GameObject mysorThis;

    public bool isBonusFound=false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded && gameOver.active==false && vinImage.active==false)
        {

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            // direction*=Force;

            moveDirection = direction;


            // direction.y -= gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && canMove)
            {
                animator.SetBool("isTake", false);
                animator.SetBool("isJump", true);
                animator.SetBool("isRun", false);
                moveDirection.y = jumpSpeed; 
               // directionY_ = jumpSpeed; //TESTS
            }
           // directionY_-= gravity * Time.deltaTime;
           // moveDirection.y = directionY_;
            if (direction.magnitude >= 0.1f)
            {
                animator.SetBool("isRun", true);
                animator.SetBool("isTake", false);
                //ySpeed -= gravity * Time.deltaTime;
                //direction.y = ySpeed;
                float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + firstCamera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationAngle, ref smoothVelosity, smootheTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 move = Quaternion.Euler(0f, rotationAngle, 0f) * Vector3.forward;
                characterController.Move(move.normalized * Force * Time.deltaTime);

                

                //characterController.Move(move.normalized * Force * Time.deltaTime);


            }

            if (direction.magnitude < 0.1f)
            {
                animator.SetBool("isTake", false);
                animator.SetBool("isRun", false);

            }
        }
        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);

        //для вывода кол-ва мусора

        //countGarbage/2 почему-то равно 2, поэтому приходится делить на 2

        if (Input.GetKey(KeyCode.E) && isBonusFound && !mysorThis.Equals(null)) {
            animator.SetBool("isTake", true);

            Destroy(mysorThis);
            garbages.Remove(mysorThis);
            countGarbage = countGarbage + 1;
            Debug.Log(countGarbage);
            //Math.Ceiling(Convert.ToDecimal(countGarbage)/ Convert.ToDecimal(2.0)) + " / " + maxcountGarbage;
            textcountGarbage.text = maxcountGarbage - garbages.Count + " / " + maxcountGarbage;
        }
    }

    public void TakeBonus(GameObject bonus) {
        for (int i = 0; i < garbages.Count; i++)
        {

            if (bonus == garbages[i])
            {
                this.mysorThis=bonus;
                
            }
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (hit.gameObject == garbageCan&& (maxcountGarbage - garbages.Count) >= maxcountGarbage)
        {
            //countGarbage = 0;
            vinImage.gameObject.SetActive(true);
            Time.timeScale = 0f;
            
        }

    }



}


