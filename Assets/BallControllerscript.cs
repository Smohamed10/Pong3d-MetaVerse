using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerscript : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 15;
    public Rigidbody rb;
    GameObject newBall;
    public GameObject Player1;
    public GameObject Player2;
    public NewBehaviourScript racket1Controller1;
    public NewBehaviourScript racket1Controller2;

    private bool stopped = true;
    public bool im_Extra = false;
    public bool Multi_Ball_Cooldown = true;
    public int Cooldowntimer = 0;
    public int BallSpeedTimer = 0;
    public int BallSizeTimer = 0;
    private float originalSpeed;
    private bool isSpeedBoosted = false;
    private bool isBig = false;
    private bool RacketBoosted = false;
    private int RacketBoostedTimer = 0;

    public int Hit_By;


    // Start is called before the first frame update
    void Start()
    {
        racket1Controller1 = Player1.GetComponent<NewBehaviourScript>();
        racket1Controller2 = Player2.GetComponent<NewBehaviourScript>();
        rb = GetComponent<Rigidbody>();
        gameObject.tag = "Ball"; // Set the tag for the original ball
        SetRandomDir();
        originalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopped)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
        if (!Multi_Ball_Cooldown)
        {
            Cooldowntimer++;
            if (Cooldowntimer >= 20000)
            {
                Destroy(newBall.gameObject);
                Cooldowntimer = 0;
            }
        }

        if (isSpeedBoosted)
        {
            BallSpeedTimer++;
            if (BallSpeedTimer >= 10000)
            {
                speed = originalSpeed;
                BallSpeedTimer = 0;
                isSpeedBoosted = false;
            }
        }
        if (isBig)
        {
            BallSizeTimer++;
            if (BallSizeTimer >= 10000)
            {
                transform.localScale /= 2;
                BallSizeTimer = 0;
                isBig = false;
            }
        }

        if (RacketBoosted)
        {
            RacketBoostedTimer++;
            if (RacketBoostedTimer >= 10000)
            {
                racket1Controller1.speed = 10;
                racket1Controller2.speed = 10;
                RacketBoostedTimer = 0;
                RacketBoosted = false;
            }
        }
    }
    public void startMove()
    {
        stopped = false;
    }
    public void stopMove()
    {
        stopped = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Racket1"))
        {
            Hit_By = 1;
        }
        if (other.CompareTag("Racket2"))
        {
            Hit_By= 2;
        }
        if (other.CompareTag("Wall"))
        {
            direction.z = -direction.z;
        }
        if (other.CompareTag("Racket1")||other.CompareTag("Racket2"))
        {
            direction.x = -direction.x;
            Vector3 NewDir = (transform.position - other.transform.position).normalized;
            direction = NewDir;
        }
        if (other.CompareTag("MultiBoost"))
        {
            newBall = Instantiate(gameObject, transform.position, transform.rotation);
            BallControllerscript newBallController = newBall.GetComponent<BallControllerscript>();
            newBallController.direction = new Vector3(-direction.x, 0, -direction.z);
            newBallController.im_Extra = true;
            newBallController.startMove();
            newBall.tag = "ExtraBall";
            Destroy(other.gameObject);
            Multi_Ball_Cooldown = false;
        }
        if (other.CompareTag("BallBoost"))
        {
            Destroy(other.gameObject);
            speed += 5;
            isSpeedBoosted = true;
        }
        if (other.CompareTag("SizeBoost"))
        {
            Destroy(other.gameObject);
            transform.localScale *= 2;
            isBig = true;
        }
        if (other.CompareTag("RacketBoost"))
        {
            Destroy(other.gameObject);
            if(Hit_By==1)
            {
                racket1Controller1.speed += 10;
            }
            if (Hit_By == 2)
            {
                racket1Controller2.speed += 10;
            }
            RacketBoosted = true;
        }
        direction.y = 0;
    }
    private void SetRandomDir()
    {
        float x = Random.value;
        float z = Random.value;
        direction = new Vector3(x, 0, z);
    }
}
