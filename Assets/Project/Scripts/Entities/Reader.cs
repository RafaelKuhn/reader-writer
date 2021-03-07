using System.Collections;
using System.Collections.Generic;
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
                int writersWaitingRightNow = mutex.waitingWriters;
                print( $"there were {writersWaitingRightNow} writers waiting" );

                mutex.waitingReaders++;

                mutex.ShouldNotRead();

                while (mutex.activeWriters == 1 || mutex.waitingWriters > 0)
                {
                    yield return null;
                }

                mutex.waitingReaders--;
            }
        }


        mutex.CanWrite = false;
        mutex.CanRead = true;
        
        mutex.activeReaders++;

        // actually reads
        yield return StartCoroutine( FillProgressively( Random.Range( 2f, 4f ) ) );

        // end reading
        mutex.activeReaders--;
        
        if (mutex.activeReaders == 0)
        {
            mutex.CanWrite = true;
        }

        Destroy( gameObject );
    }

}
