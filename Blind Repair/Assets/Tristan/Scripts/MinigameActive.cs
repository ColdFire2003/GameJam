using UnityEngine;
using UnityEngine.Events;

public class MinigameActive : MonoBehaviour
{
    [SerializeField] private UnityEvent Minigame;
    [SerializeField] private bool Minigameactivate;

    public void OnTriggerStay(Collider other)
    {
        if (Minigameactivate)
        {
            //Debug.Log("enter collision");
            if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) || other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
            {
                // always gets it 2 times
                Debug.Log("interact" + " " + other.name);
                Minigame.Invoke();
            }
        }
    }
}
