using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{
    private float Move;
    public float speed;
    private float Jump;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }   

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        Jump = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(Move * speed, rb.velocity.y);
        rb.velocity = new Vector2(Jump * speed, rb.velocity.x);

    }
}
