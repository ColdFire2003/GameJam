using UnityEngine;
using UnityEngine.Events;

public class MinigameActive : MonoBehaviour
{
    [SerializeField] private UnityEvent _minigame;
    public bool Minigameactive = true;
    private bool PlayerInRange;

    public void Update()
    {
        if (!PlayerInRange && !Minigameactive) return;
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F))
        {
            Minigameactive = false;
            _minigame.Invoke();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Minigameactive)
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
    }
}
