using UnityEngine;
using UnityEngine.UI;

public class FillableEntity : MonoBehaviour
{
    public Image white;
    public Image green;

    public void Fill(float amount)
    {
        float normalizedAmount = Mathf.Clamp(amount, 0, 1);

        green.fillAmount = normalizedAmount;
        white.fillAmount = 1 - normalizedAmount;
    }

}
