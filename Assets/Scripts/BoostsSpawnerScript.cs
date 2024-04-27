using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostsSpawnerScript : MonoBehaviour
{
    public GameObject MultiBallBoost;
    private GameObject currentBoost; // Reference to the current clone
    public GameObject BallSpeedBoost;
    public GameObject BallSizeBoost;
    public GameObject RacketSpeedBoost;


    Vector3 BoostPos;

    public void Spawn_MultiBall()
    {
        BoostPos = SetRandomPos();
        currentBoost = Instantiate(MultiBallBoost, BoostPos, MultiBallBoost.transform.rotation);
    }
    public void Spawn_BallBoost()
    {
        BoostPos = SetRandomPos();
        currentBoost = Instantiate(BallSpeedBoost, BoostPos, BallSpeedBoost.transform.rotation);
    }
    public void Spawn_SizeBoost()
    {
        BoostPos = SetRandomPos();
        currentBoost = Instantiate(BallSizeBoost, BoostPos, BallSizeBoost.transform.rotation);
    }
    public void Spawn_RacketBoost()
    {
        BoostPos = SetRandomPos();
        currentBoost = Instantiate(RacketSpeedBoost, BoostPos, RacketSpeedBoost.transform.rotation);
    }
    private Vector3 SetRandomPos()
    {
        float x = Random.Range(-12, 12);
        float z = Random.Range(-8, 8);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }

    public void Destroy_Spawner()
    {
        // Check if there's a currentBoost before destroying
        if (currentBoost != null)
        {
            Destroy(currentBoost);
        }
    }
}
