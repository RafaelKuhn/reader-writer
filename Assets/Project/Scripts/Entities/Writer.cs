using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Writer : FillableEntity
{
    private Mutex mutex;
    void Start()
    {
        mutex = Mutex.instance;

        StartCoroutine( Write() );
    }

    void OnDestroy()
    {
        EntitySpawner.instance.DespawnWriter( gameObject );
    }

    private IEnumerator Write()
    {
        // begin write
        if (mutex.activeWriters == 1 || mutex.activeReaders > 0)
        {
            mutex.waitingWriters++;

            while (mutex.activeWriters == 1 || mutex.activeReaders > 0)
            {
                yield return null;
            }
            mutex.waitingWriters--;
        }


        mutex.CanRead = false;
        mutex.CanWrite = false;

        mutex.activeWriters = 1;

        // actually writes / fills bar
        yield return StartCoroutine( FillProgressively( Random.Range( 0.5f, 1.5f ) ) );

        // end writing
        mutex.activeWriters = 0;

        if (mutex.waitingWriters == 0)
        {
            mutex.CanRead = true;
            mutex.CanWrite = true;
        }

        Destroy( gameObject );
    }

}
