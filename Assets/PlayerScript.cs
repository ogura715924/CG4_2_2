using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;

    private float moveSpeed = 2.0f;
    private float stageMax = 9.0f;
    private float stageMin = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < stageMax)
            {
                rb.velocity = new Vector3(moveSpeed, 0, 0);
            }
                animator.SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > stageMin)
            {
                rb.velocity = new Vector3(-moveSpeed, 0, 0);
            }
                animator.SetBool("Run", true);
        }
        else
        {
            rb.velocity=new Vector3(0,0,0);
            animator.SetBool("Run", false);
        }
    }
}
