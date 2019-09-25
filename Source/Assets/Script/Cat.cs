using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public float speed = 50f, maxspeed = 3, jumpPow = 220f;
    public Rigidbody2D r2;
    public bool grounded = true,
        faceRight=false;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        r2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Flip();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("onGround", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);
        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.position.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.position.y);
        if (h >0 && !faceRight)
        {
            Flip();
        }
        if(h<0 && faceRight)
        {
            Flip();
        }
    }
    public void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
