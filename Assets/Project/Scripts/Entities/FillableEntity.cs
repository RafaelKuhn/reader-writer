using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FillableEntity : MonoBehaviour
{
    public Image white;
    public Image green;

    protected void Fill(float amount)
    {
        float normalizedAmount = Mathf.Clamp(amount, 0, 1);

        green.fillAmount = normalizedAmount;
        white.fillAmount = 1 - normalizedAmount;
    }

    public IEnumerator FillProgressively( float durationInSeconds, float callsPerSecond = 60 )
    {
        float iterations = durationInSeconds * callsPerSecond;
        float waitTimePerIteration = durationInSeconds / iterations;

        iterations = Mathf.Round( iterations );
        for (float i = 0; i <= iterations; i++)
        {
            float unitaryValue = i / iterations;

            Fill( unitaryValue );

            //print( $"dividing -> {i} by {iterations}" );
            //print( $"val -> {unitaryValue}" );

            yield return new WaitForSeconds( waitTimePerIteration );
        }
    }
}
