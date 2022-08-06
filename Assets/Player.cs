using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] float speed;
    [SerializeField] float magnitude;
    bool shaking = false;
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
        rb.velocity = new Vector3(horizontal * speed * Time.deltaTime,
            vertical * speed * Time.deltaTime, 0f);

        anim.SetBool("Forward", vertical > 0.01);
        anim.SetBool("Left", horizontal < -0.01);
        anim.SetBool("Right", horizontal > 0.01);
        anim.SetBool("Back", vertical < -0.01);
        if (!shaking) StartCoroutine(Shaking(magnitude));
    }
    //aaaa
    private IEnumerator Shaking(float magnitude = 0.25f)
    {
        shaking = true;
        float t = 0f, x, y;
        while (t < 0.35f)
        {
            x = Random.Range(-1f, 1f) * magnitude;
            y = Random.Range(-1f, 1f) * magnitude;

            rb.transform.localPosition += new Vector3(x, y, rb.transform.position.z);

            t += Time.deltaTime;
            yield return null;
        }

        shaking = false;
    }
}
