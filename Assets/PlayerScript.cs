using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public GameObject bullet;

    private float moveSpeed = 2.0f;
    private float stageMax = 9.0f;
    private float stageMin = 0.0f;
    private float bulletTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //�ړ�(Update�ɏ����ׂ������ǂȂ����ړ��ł��Ȃ��Ȃ邩�炢�ꎞ�I�ɂ���)
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

        //�e����(�����FixedUpdate�ł����Ă�)
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 position = transform.position;
            position.y += 0.8f;
            position.z += 1.0f;

            if (bulletTimer == 0)
            {
                Instantiate(bullet, position, Quaternion.identity);
                bulletTimer = 1;
            }
        }
        //�����Ă��Ȃ��Ԃ��J�E���g�A�b�v����悤�ɂ���
        if (bulletTimer != 0)
        {
            bulletTimer++;
            if (bulletTimer > 20)
            {
                bulletTimer = 0;
            }
        }
    }
}
