using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FillableEntity : MonoBehaviour
{
    [SerializeField] private Image white;
    [SerializeField] private Image green;

    private bool isPaused;

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

            while (isPaused)
            {
                yield return null;
            }

            yield return new WaitForSeconds( waitTimePerIteration );
        }
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume()
    {
        isPaused = false;
    }

}
