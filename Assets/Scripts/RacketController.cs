using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public KeyCode Up;
    public KeyCode Down;
    public Rigidbody rb;
    public bool isplayer;
    private Transform ball;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        isplayer = true;
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isplayer == true)
        {
            MoveByPlayer();
        }
        else
        {
            MoveByComputer();
        }
    }
    private void MoveByPlayer()
    {
        bool isup = Input.GetKey(Up);
        bool isdown = Input.GetKey(Down);
        if (isup)
        {
            rb.velocity = Vector3.forward * speed;
        }
        if (isdown)
        {
            rb.velocity = Vector3.back * speed;
        }
        if (!isdown && !isup)
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void MoveByComputer()
    {
        if (ball.position.z>transform.position.z)
        {
            rb.velocity = Vector3.forward * speed;
        }
        if (ball.position.z > transform.position.z)
        {
            rb.velocity = Vector3.back * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
