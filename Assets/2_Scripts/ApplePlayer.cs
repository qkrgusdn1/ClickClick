using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public Transform tr;
    public Animator ani;
    private void Update()
    {
        float horizopntalInput = Input.GetAxis("Horizontal");
        if (horizopntalInput < 0)
        {
            rb.velocity = new Vector2(horizopntalInput * moveSpeed, rb.velocity.y);
            tr.localScale = new Vector3(-1, 1f, 1);
            ani.Play("Move");
        }
        else if(horizopntalInput > 0)
        {
            rb.velocity = new Vector2(horizopntalInput * moveSpeed, rb.velocity.y);
            tr.localScale = new Vector3(1, 1f, 1);
            ani.Play("Move");
        }
        else
        {
            ani.Play("Idle");
        }
    }
}
