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

    public void Read()
    {
        StartCoroutine( ReadCor() );
    }

    private IEnumerator ReadCor()
    {
        // begin read
        if (mutex.activeWriters == 1 || mutex.waitingWriters > 0)
        {
            mutex.waitingReaders++;

            print( $"{gameObject.name} is waiting" );

            while (mutex.activeWriters == 1 || mutex.waitingWriters > 0)
            {
                yield return null;
            }
        }

        print( $"{gameObject.name} is reading" );

        // actually reads
        mutex.CanWrite = false;
        mutex.CanRead = true;

        mutex.waitingReaders--;
        mutex.activeReaders++;

        yield return StartCoroutine( FillProgressively( Random.Range( 0.3f, 3f ) ) );

        // end reading
        mutex.activeReaders--;
        if (mutex.waitingWriters > 0 && mutex.activeReaders == 0)
        {
            mutex.CanWrite = true;
        }
        
        if (mutex.waitingWriters == 0 && mutex.waitingReaders == 0)
        {
            mutex.CanWrite = true;
            mutex.CanRead = true;
        }


        Destroy( gameObject );
    }

}
