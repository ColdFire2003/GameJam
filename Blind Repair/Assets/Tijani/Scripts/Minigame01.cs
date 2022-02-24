using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Minigame01 : MonoBehaviour
{
    [SerializeField] private AudioSource _beepSource;
    [SerializeField] private AudioSource _errorSource;

    [Tooltip("Has to be bigger than 1")] [SerializeField]
    private float _minTime, _maxTime;

    [SerializeField] private float _timeToReact;
    [SerializeField] private UnityEvent _changeScene;
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    private bool _canPress;
    private IEnumerator _playBeep;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playBeep = PlayBeep();
            StartCoroutine(_playBeep);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(_playBeep);
            if (_canPress)
            {
                print("you pressed at the right time bud");
                GameManager.Instance.TaskCompleted();
                _changeScene.Invoke();
            }
            else if (!_canPress)
            {
                print("you missed dumbass");
                // _errorSource.PlayOneShot(_errorSource.clip);
                _currentHealth--;
            }
        }

        if (_currentHealth <= 0)
        {
            GameManager.Instance.TaskFailed();
            _changeScene.Invoke();
        }
    }

    private IEnumerator PlayBeep()
    {
        _canPress = false;
        var randomTime = Random.Range(_minTime, _maxTime);

        yield return new WaitForSeconds(randomTime);

        _beepSource.PlayOneShot(_beepSource.clip);
        StartCoroutine(ReactOnTime());
    }

    private IEnumerator ReactOnTime()
    {
        yield return new WaitForSeconds(_timeToReact);

        _canPress = true;
    }
}