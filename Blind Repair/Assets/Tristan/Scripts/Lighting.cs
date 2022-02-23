using UnityEngine;

public class Lighting : MonoBehaviour
{
    public Light PlayerLight;

    //Range variables
    [SerializeField] private bool ActiveLightChange = false;
    [SerializeField] private bool RepeatLightChange = false;
    [SerializeField] private float RangeSpeed = 1.0f;
    [SerializeField] private float MaxRange = 20.0f;
    [SerializeField] private float MinRange = 10.0f;

    private float StartTime;

    void Start()
    {
        StartTime = Time.time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ActiveLightChange = true;
        }

        if (ActiveLightChange)
        {
            if (RepeatLightChange)
            {
                PlayerLight.range = Mathf.PingPong(Time.time * RangeSpeed, MaxRange);
            }
            else
            {
                PlayerLight.range = Time.time * RangeSpeed;
                if (PlayerLight.range >= MaxRange)
                {
                    PlayerLight.range = MinRange;
                    ActiveLightChange = false;
                }
            }
        }
    }
}
