using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;

    float horizontal;
    float vertical;
    Animator anim;
    Rigidbody2D rb2d;
    FloatingJoystick joystick;

    [HideInInspector]
    public bool isMove;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        GameObject.FindGameObjectWithTag("joystick").TryGetComponent(out joystick);
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") + joystick.Horizontal;
        vertical = Input.GetAxisRaw("Vertical") + joystick.Vertical;

        FlipUpdate(horizontal);
        float move = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        isMove = move > 0;

        anim.SetFloat("move", move);
        anim.SetFloat("moveX", Mathf.Abs(horizontal));
        anim.SetFloat("moveY", vertical);
    }

    void FlipUpdate(float horizontal)
    {
        Vector3 scale = transform.localScale;
        if (horizontal < 0) scale.x = -1;
        if (horizontal > 0) scale.x = 1;
        transform.localScale = scale;
    }

    void FixedUpdate()
    {
        Vector2 moveDir = new Vector2(horizontal, vertical).normalized;
        Vector2 position = rb2d.position;
        position += moveDir * speed * Time.fixedDeltaTime;
        rb2d.MovePosition(position);
        //rb2d.velocity = moveDir * speed;
    }
}
