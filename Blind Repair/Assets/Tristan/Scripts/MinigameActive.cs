using UnityEngine;
using UnityEngine.Events;

public class MinigameActive : MonoBehaviour
{
    [SerializeField] private UnityEvent _minigame;
    [SerializeField] private int _whichStation;
    public bool Minigameactive = true;
    private bool PlayerInRange;

    public void Update()
    {
        if (!PlayerInRange || !GameManager.Instance.IsMinigameActive(_whichStation)) return;
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F))
        {
            GameManager.Instance.SetMinigameUnactive(_whichStation);
            _minigame.Invoke();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.IsMinigameActive(_whichStation))
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