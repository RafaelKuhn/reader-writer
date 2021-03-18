using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class FillableEntity : MonoBehaviour
{
    [SerializeField] private Image white;
    [SerializeField] private Image green;

    protected IEnumerator FillProgressively( float durationInSeconds, float callsPerSecond = 60 )
    {
        float iterations = durationInSeconds * callsPerSecond;
        float waitTimePerIteration = durationInSeconds / iterations;

        iterations = Mathf.Round( iterations );
        for (float i = 0; i <= iterations; i++)
        {
            while (GamePauser.isPaused)
            {
                yield return null;
            }

            float unitaryValue = i / iterations;

            Fill( unitaryValue );

            yield return new WaitForSeconds( waitTimePerIteration );
        }
    }

    private void Fill( float amount )
    {
        float normalizedAmount = Mathf.Clamp(amount, 0, 1);

        green.fillAmount = normalizedAmount;
        white.fillAmount = 1 - normalizedAmount;
    }
}
