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

    public List<GameObject> spawnedReaderObjects = new List<GameObject>();
    public List<GameObject> spawnedwriterObjects = new List<GameObject>();

    void Awake()
    {
        instance = this;
    }
    
    public void _SpawnReader()
    {
        if (spawnedReaderObjects.Count >= 7) { return; }

        var obj = Instantiate( readerPrefab, readers.transform );
        spawnedReaderObjects.Add( obj );
    }

    public void _SpawnWriter()
    {
        if (spawnedwriterObjects.Count >= 7) { return; }

        var obj = Instantiate( writerPrefab, writers.transform );
        spawnedwriterObjects.Add( obj );
    }

    public void DespawnReader(GameObject obj)
    {
        spawnedReaderObjects.Remove( obj );
    }

    public void DespawnWriter( GameObject obj )
    {
        spawnedwriterObjects.Remove( obj );
    }

}
