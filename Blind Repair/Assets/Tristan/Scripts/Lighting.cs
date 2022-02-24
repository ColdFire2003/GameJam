using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    public Light PlayerLight;

    //Range variables
    [SerializeField] private bool _EcoLocation = false;
    [SerializeField] private bool _StopEcoLocation = false;
    [SerializeField] private float _RangeSpeed = 1.5f;
    [SerializeField] private float _MaxRange = 10.0f;
    [SerializeField] private float _MinRange = 5.5f;

    private float _StartTime;

    void Start()
    {
        _StartTime = Time.time;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _EcoLocation = true;
            _StopEcoLocation = false;
        }

        if (_EcoLocation)
        {
            PlayerLight.range = Mathf.PingPong(Time.time * _RangeSpeed, _MaxRange);
        }

        if(PlayerLight.range >= 6)
        {
            _StopEcoLocation = true;
        }

        if (_StopEcoLocation && PlayerLight.range <= 5.5)
        {
                _EcoLocation = false;
                PlayerLight.range = 5.5f;
        }
    }
}
