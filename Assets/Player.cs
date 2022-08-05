using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(horizontal * speed, vertical * speed, 0f);

        if (vertical > 0.01)
        {
            anim.SetBool("Forward", true);
        }
        else
        {
            anim.SetBool("Forward", false);
        }
    }
}
