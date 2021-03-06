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

            print( $"{gameObject.name} is waiting" );

            while (mutex.activeWriters == 1 || mutex.activeReaders > 0)
            {
                yield return null;
            }
        }

        print( $"{gameObject.name} is writing" );

        // actually writes / fills bar
        mutex.CanRead = false;
        mutex.CanWrite = false;

        mutex.waitingWriters--;
        mutex.activeWriters = 1;
        yield return StartCoroutine( FillProgressively( Random.Range( 0.3f, 3f ) ) );


        // end writing
        mutex.activeWriters = 0;

        if (mutex.waitingReaders > 0)
        {
            mutex.CanRead = true;
        }

        Destroy( gameObject );
    }

}
