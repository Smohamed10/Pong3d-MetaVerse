using UnityEngine;
using UnityEngine.Events;

public class GoalController : MonoBehaviour
{

    public UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ball")) {
            Debug.Log("Goaaaal");
            onTriggerEnter.Invoke();
            
        }
        if (other.CompareTag("ExtraBall"))
        {
            Debug.Log("Extra Goaaaal");
            onTriggerEnter.Invoke();
        }
    }
}
