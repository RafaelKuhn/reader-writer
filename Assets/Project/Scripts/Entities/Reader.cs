using System.Collections;
using UnityEngine;

public class Reader : FillableEntity
{
    private Mutex mutex;
    void Start()
    {
        mutex = Mutex.instance;

        StartCoroutine( Read() );
    }

    void OnDestroy()
    {
        EntitySpawner.instance.DespawnReader( gameObject );
    }

    private IEnumerator Read()
    {
        // begin read

        if (mutex.isStarvationEnabled)
        {
            if (mutex.activeWriters == 1)
            {
                mutex.waitingReaders++;

                while (mutex.activeWriters == 1)
                {
                    yield return null;
                }

                mutex.waitingReaders--;
            }
        }

        else
        {
            if (mutex.activeWriters == 1 || mutex.waitingWriters > 0)
            {
                mutex.waitingReaders++;

                if (mutex.waitingWriters > 0)
                {
                    mutex.ShouldNotRead();
                }

                while (mutex.activeWriters == 1 || mutex.waitingWriters > 0)
                {
                    yield return null;
                }

                mutex.waitingReaders--;
            }
        }


        mutex.CanWriteSemaphor = false;
        mutex.CanReadSemaphor = true;
        
        mutex.activeReaders++;

        // actually reads
        yield return StartCoroutine( FillProgressively( Random.Range( 2f, 4f ) ) );

        // end reading
        mutex.activeReaders--;
        
        if (mutex.activeReaders == 0)
        {
            mutex.CanWriteSemaphor = true;
        }

        Destroy( gameObject );
    }

}
