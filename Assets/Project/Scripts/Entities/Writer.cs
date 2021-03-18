using System.Collections;
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


        mutex.CanReadSemaphor = false;
        mutex.CanWriteSemaphor = false;

        mutex.activeWriters = 1;

        // actually writes / fills bar
        yield return StartCoroutine( FillProgressively( Random.Range( 1f, 2f ) ) );

        // end writing
        mutex.activeWriters = 0;

        if (mutex.waitingWriters == 0)
        {
            mutex.CanReadSemaphor = true;
            mutex.CanWriteSemaphor = true;
        }

        Destroy( gameObject );
    }

}
