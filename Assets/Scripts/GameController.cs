using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreTextLeft;
    public Text scoreTextRight;
    public Starter starter;
    public bool started = false;
    public GameObject ball;
    public BallControllerscript ballController;
    public BoostsSpawnerScript BoostSpawner;
    private int scoreLeft;
    private int scoreRight;
    private Vector3 startingPosition;
    public int Multi_Ball_Timer = 0;
    public int Ball_Boost_Timer = 0;
    public int Ball_Size_Timer = 0;
    public int Racket_Boost_Timer = 0;

    public int deleteBallBoost = 0;
    public int deletespawner = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Set the ball reference
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballController = ball.GetComponent<BallControllerscript>();
        startingPosition = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Multi_Ball_Timer++;
        deletespawner++;
        Ball_Boost_Timer++;
        deleteBallBoost++;
        Ball_Size_Timer++;
        Racket_Boost_Timer++;
        if (!started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                started = true;
                ballController.startMove();
            }
        }
        if (Multi_Ball_Timer >= 40000)
        {
            BoostSpawner.Spawn_MultiBall();
            Multi_Ball_Timer = 0;
        }
        if (Ball_Size_Timer >= 24000)
        {
            BoostSpawner.Spawn_SizeBoost();
            Ball_Size_Timer = 0;
        }

        if (Ball_Boost_Timer >= 20000)
        {
            BoostSpawner.Spawn_BallBoost();
            Ball_Boost_Timer = 0;
        }
        if (Racket_Boost_Timer >= 10000)
        {
            BoostSpawner.Spawn_RacketBoost();
            Racket_Boost_Timer = 0;
        }
        if (deleteBallBoost >= 25000)
        {
            BoostSpawner.Destroy_Spawner();
            deleteBallBoost = 0;
        }
    }

    public void ResetGame()
    {
        ballController.stopMove();
        ball.transform.position = startingPosition;
        started = false;
    }

    public void ScoreGoalLeft()
    {
        if (ball.CompareTag("ExtraBall"))
        {
            Debug.Log("Extar Ball");
            scoreRight += 1;
        }
        else
        {
            ResetGame();
            scoreRight += 1;
        }
        UpdateUI();
    }

    public void ScoreGoalRight()
    {
        if (ball.CompareTag("ExtraBall"))
        {
            Debug.Log("Extar Ball");
            scoreLeft += 1;
        }
        else
        {
            ResetGame();
            scoreLeft += 1;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();
    }
}