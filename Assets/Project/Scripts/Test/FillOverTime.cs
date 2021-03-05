using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillOverTime : MonoBehaviour
{
    public List<FillableEntity> entities;

    public bool isPaused = false;

    void OnEnable()
    {
        entities.ForEach( ent =>
        {
            float f = Random.Range(0.3f,3f);
            //print( $"random -> {f}" );
            StartCoroutine( Fill( ent, f ) );
        } );
    }

    

    public IEnumerator Fill(FillableEntity entity, float durationInSeconds, float callsPerSecond = 60)
    {
        float iterations = durationInSeconds * callsPerSecond;
        float waitTimePerIteration = durationInSeconds / iterations;

        iterations = Mathf.Round( iterations );
        for (float i = 0; i <= iterations; i++)
        {
            float unitaryValue = i / iterations;
            
            entity.Fill( unitaryValue );

            //print( $"dividing -> {i} by {iterations}" );
            //print( $"val -> {unitaryValue}" );

            while (isPaused)
            {
                yield return null;
            }

            yield return new WaitForSeconds( waitTimePerIteration );
        }
    }
}
