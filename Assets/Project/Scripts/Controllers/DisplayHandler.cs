using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waitingWriters;
    [SerializeField] private TextMeshProUGUI activeReaders;

    [SerializeField] private TextMeshProUGUI waitingReaders;
    [SerializeField] private TextMeshProUGUI activeWriters;

    private Mutex mutex;
    void Start()
    {
        mutex = Mutex.instance;
    }
    void Update()
    {
        UpdateUIState();
    }

    private void UpdateUIState()
    {
        waitingReaders.text = mutex.waitingReaders.ToString();
        waitingWriters.text = mutex.waitingWriters.ToString();

        activeReaders.text = mutex.activeReaders.ToString();
        activeWriters.text = mutex.activeWriters.ToString();
    }
}
