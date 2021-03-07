using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauser : MonoBehaviour
{
    private EntitySpawner spawner;

    void Start()
    {
        spawner = EntitySpawner.instance;
    }

    public void _ResumeButtonClicked()
    {
        ResumeGame();
    }

    public void _PauseButtonClicked()
    {
        PauseGame();
    }


    List<GameObject> allEntities;
    private void PauseGame()
    {
        allEntities = new List<GameObject>();
        
        allEntities.AddRange( spawner.spawnedReaderObjects );
        allEntities.AddRange( spawner.spawnedwriterObjects );

        allEntities.ForEach( reader => reader.GetComponent<FillableEntity>().Pause() );
    }

    private void ResumeGame()
    {
        allEntities.ForEach( reader => reader.GetComponent<FillableEntity>().Resume() );
        
        allEntities.Clear();
    }



}
