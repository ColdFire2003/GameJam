using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;

    public static GameManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    #endregion Singleton

    [SerializeField] private UnityEvent _loseEvent;
    [SerializeField] private UnityEvent _winEvent;
    [SerializeField] private GameObject[] _repairStations;
    [SerializeField] private string _mainScene;

    [SerializeField] private List<bool> _taskTriedFix;

    [SerializeField] private int _tasksFailed;
    [SerializeField] private int _tasksCompleted;

    private void Start()
    {
        for (int i = 0; i < _repairStations.Length; i++)
        {
            _taskTriedFix.Add(true);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == _mainScene)
        {
            print(_repairStations.Length);

            if (_tasksCompleted > _repairStations.Length / 2)
            {
                _winEvent.Invoke();

                print("u won ez");
            }

            if (_tasksFailed > _repairStations.Length / 2)
            {
                _loseEvent.Invoke();
                print("u lost lol");
            }
        }
    }

    public void SetMinigameUnactive(int stationNumber) => _taskTriedFix[stationNumber - 1] = false;

    public bool IsMinigameActive(int stationNumber) => _taskTriedFix[stationNumber - 1];

    public void TaskFailed()
    {
        _tasksFailed++;
    }
    public void TaskCompleted()
    {
        _tasksCompleted++;
    }
}