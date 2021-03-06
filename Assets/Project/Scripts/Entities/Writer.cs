using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Writer : FillableEntity
{
    private Mutex mutex;
    void Start()
    {
        mutex = Mutex.instance;

        Write();
    }

    void OnDestroy()
    {
        EntitySpawner.instance.DespawnWriter( gameObject );
    }

    public void Write()
    {
        StartCoroutine( WriteCor() );
    }


    private IEnumerator WriteCor()
    {
        // begin write
        if (mutex.activeWriters == 1 || mutex.activeReaders > 0)
        {
            mutex.waitingWriters++;

            while (mutex.activeWriters == 1 || mutex.activeReaders > 0)
            {
                yield return null;
            }
        }


        // actually writes / fills bar
        mutex.CanRead = false;
        mutex.CanWrite = false;

        mutex.waitingWriters--;
        mutex.activeWriters = 1;
        yield return StartCoroutine( FillProgressively( Random.Range( 0.5f, 1.5f ) ) );


        // end writing
        mutex.activeWriters = 0;

        if (mutex.waitingReaders > 0)
        {
            mutex.CanRead = true;
        }

        Destroy( gameObject );
    }

}
