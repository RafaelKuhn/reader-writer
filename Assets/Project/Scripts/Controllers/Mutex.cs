using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Mutex : MonoBehaviour
{
    [SerializeField] private TrafficLight canReadLight;
    [SerializeField] private TrafficLight canWriteLight;

    private bool canRead;
    private bool canWrite;

    public bool isStarvationEnabled = true;

    [HideInInspector] public int activeReaders;
    [HideInInspector] public int activeWriters;
    [HideInInspector] public int waitingReaders;
    [HideInInspector] public int waitingWriters;

    [HideInInspector]
    public bool CanReadSemaphor
    {
        get { return canRead; }
        set
        {
            canRead = value;

            if (canRead)
            {
                canReadLight.ToggleGreenLight();
            }

            else
            {
                canReadLight.ToggleRedLight();
            }
        }
    }
    [HideInInspector]
    public bool CanWriteSemaphor
    {
        get { return canWrite; }
        set
        {
            canWrite = value;

            if (canWrite)
            {   
                canWriteLight.ToggleGreenLight();
            }

            else
            {
                canWriteLight.ToggleRedLight();
            }
        }
    }

    public void ShouldNotRead()
    {
        canReadLight.ToggleYellowLight();
    }

    

    public static Mutex instance;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CanReadSemaphor = true;
        CanWriteSemaphor = true;
    }
    
    public void _ToggleStarvation(Toggle toggle)
    {
        isStarvationEnabled = toggle.isOn;
    }

}
