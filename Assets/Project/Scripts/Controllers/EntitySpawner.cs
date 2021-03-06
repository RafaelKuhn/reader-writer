using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntitySpawner : MonoBehaviour
{
    public HorizontalOrVerticalLayoutGroup readers;
    public HorizontalOrVerticalLayoutGroup writers;

    private Queue<Reader> readerQueue = new Queue<Reader>();
    private Queue<Writer> writerQueue = new Queue<Writer>();

    public static EntitySpawner instance;

    void Awake()
    {
        instance = this;
    }
    
    public void _PlayButtonClicked()
    {
        
    }




}
