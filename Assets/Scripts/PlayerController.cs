using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody;
    Vector3 deltaPos = new Vector3();
    Vector3 currentSpeed = new Vector3();
    float jumpForce = 5f;
    int vidas = 3;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            deltaPos = new Vector3();
            currentSpeed = new Vector3();

            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            animator.SetTrigger("isFlying");

        }

        animator.SetTrigger("isFalling");
        // Yf = Y0 + V0y * T + (aT)
        deltaPos.y = currentSpeed.y * Time.deltaTime + Physics.gravity.y * Mathf.Pow(Time.deltaTime, 2) / 2;
        transform.Translate(deltaPos);
        currentSpeed += Physics.gravity * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bottom") || collision.gameObject.CompareTag("Pipe"))
        {
            if(vidas > 0)
            {
                vidas -= 1;
                Debug.Log("Vidas: " + vidas);
            } else
            {
                Debug.Log("Usted perdió!");
            }
        }
    }
}
