using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reader : FillableEntity
{
    private Mutex mutex;
    void Start()
    {
        mutex = Mutex.instance;

        Read();
    }

    void OnDestroy()
    {
        EntitySpawner.instance.DespawnReader( gameObject );
    }

    public void Read()
    {
        StartCoroutine( ReadCor() );
    }

    private IEnumerator ReadCor()
    {
        // begin read

        if (mutex.activeWriters == 1) // || mutex.waitingWriters > 0
        {
            mutex.waitingReaders++;

            while (mutex.activeWriters == 1) // || mutex.waitingWriters > 0
            {
                yield return null;
            }
            
            mutex.waitingReaders--;
        }

        // actually reads
        mutex.CanWrite = false;
        mutex.CanRead = true;
        
        mutex.activeReaders++;

        yield return StartCoroutine( FillProgressively( Random.Range( 1f, 3f ) ) );

        // end reading
        mutex.activeReaders--;
        
        if (mutex.activeReaders == 0)
        {
            mutex.CanWrite = true;
        }

        Destroy( gameObject );
    }

}
