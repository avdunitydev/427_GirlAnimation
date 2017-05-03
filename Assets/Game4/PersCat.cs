using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersCat : MonoBehaviour
{
    public float speed = 1;
    public Transform sensGround;
    public LayerMask layerGround;
    public Transform bullet, bulletRed;
    SpriteRenderer sprRen;
    Rigidbody2D pers;
    Animator anim;
    float move;
    bool isRight = true;
    bool isGround = false;

    void Start()
    {
        sprRen = GetComponent<SpriteRenderer>();
        pers = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(sensGround.position, 0.2f, layerGround);
        anim.SetBool("ground", isGround);
        anim.SetFloat("ySpeed", pers.velocity.y);
        //if (!isGround)
        //    return;

        move = Input.GetAxis("Horizontal");
        anim.SetFloat("xSpeed", Mathf.Abs(move));
        pers.velocity = new Vector2(move * speed, pers.velocity.y);
        if (move > 0 && !isRight)
        {
            sprRen.flipX = false;
            isRight = true;
        } else if (move < 0 && isRight)
        {
            sprRen.flipX = true;
            isRight = false;
        }
    }

    void Update()
    {
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("ground", false);
            pers.AddForce(new Vector2(0, 300));
        }


        /*if (Input.GetKeyDown(KeyCode.Return) && Physics2D.OverlapCircle(transform.position, 0.3f, layerGround).tag == "Star1")
        {
            print("*");
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }*/
        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider2D coll = Physics2D.OverlapCircle(transform.position, 0.3f, layerGround);
            if (coll && coll.tag == "Star1")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);

            }
            
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject bull;
            if (Input.GetKey(KeyCode.RightShift))
            {
                bull = PoolManager.GetObject(bulletRed.name, transform.position, Quaternion.identity);

            } else
            {
                bull = PoolManager.GetObject(bullet.name, transform.position, Quaternion.identity);                
            }
            if (isRight)
            {
                bull.GetComponent<PoolObject>().AddForseObject(new Vector2(500, 0));

            } else
            {
                bull.GetComponent<PoolObject>().AddForseObject(new Vector2(-500, 0));
            }
        }

    }
}
