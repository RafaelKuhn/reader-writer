using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutex : MonoBehaviour
{
    [SerializeField] private TrafficLight canReadLight;
    [SerializeField] private TrafficLight canWriteLight;

    private bool canRead;
    private bool canWrite;

    [HideInInspector]
    public bool CanRead
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
    [HideInInspector] public bool CanWrite
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

    [HideInInspector] public int activeReaders;
    [HideInInspector] public int activeWriters;

    [HideInInspector] public int waitingReaders;
    [HideInInspector] public int waitingWriters;

    public static Mutex instance;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CanRead = true;
        CanWrite = true;
    }

}
