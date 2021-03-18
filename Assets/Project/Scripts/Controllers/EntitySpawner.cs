using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class EntitySpawner : MonoBehaviour
{
    public GameObject readerPrefab;
    public GameObject writerPrefab;

    public HorizontalOrVerticalLayoutGroup readers;
    public HorizontalOrVerticalLayoutGroup writers;

    public static EntitySpawner instance;

    public List<GameObject> spawnedObjects = new List<GameObject>();

    private int readersAmount;
    private int writersAmount;


    void Awake()
    {
        instance = this;
    }
    
    public void _SpawnReader()
    {
        if (readersAmount >= 7) { return; }

        var obj = Instantiate( readerPrefab, readers.transform );
        spawnedObjects.Add( obj );

        readersAmount++;
    }

    public void _SpawnWriter()
    {
        if (writersAmount >= 7) { return; }

        var obj = Instantiate( writerPrefab, writers.transform );
        spawnedObjects.Add( obj );

        writersAmount++;
    }

    public void DespawnReader(GameObject obj)
    {
        spawnedObjects.Remove( obj );

        readersAmount--;
    }

    public void DespawnWriter( GameObject obj )
    {
        spawnedObjects.Remove( obj );

        writersAmount--;
    }

}
