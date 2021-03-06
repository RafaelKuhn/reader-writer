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

    private List<GameObject> spawnedReaders = new List<GameObject>();
    private List<GameObject> spawnedwriters = new List<GameObject>();

    void Awake()
    {
        instance = this;
    }
    
    public void _PlayButtonClicked()
    {
        
    }

    public void _PauseButtonClicked()
    {

    }

    public void _SpawnReader()
    {
        if (spawnedReaders.Count >= 7) { return; }

        var obj = Instantiate( readerPrefab, readers.transform );
        spawnedReaders.Add( obj );
    }

    public void _SpawnWriter()
    {
        if (spawnedwriters.Count >= 7) { return; }

        var obj = Instantiate( writerPrefab, writers.transform );
        spawnedwriters.Add( obj );
    }

    public void DespawnReader(GameObject obj)
    {
        spawnedReaders.Remove( obj );
    }

    public void DespawnWriter( GameObject obj )
    {
        spawnedwriters.Remove( obj );
    }

}
