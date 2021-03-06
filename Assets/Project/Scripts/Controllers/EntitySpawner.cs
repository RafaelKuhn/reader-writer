using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntitySpawner : MonoBehaviour
{
    public GameObject readerPrefab;
    public GameObject writerPrefab;

    public HorizontalOrVerticalLayoutGroup readers;
    public HorizontalOrVerticalLayoutGroup writers;

    public static EntitySpawner instance;

    void Awake()
    {
        instance = this;
    }
    
    public void _PlayButtonClicked()
    {
        
    }

    public void _SpawnReader()
    {
        Instantiate( readerPrefab, readers.transform );
    }

    public void _SpawnWriter()
    {
        Instantiate( writerPrefab, writers.transform );
    }


}
