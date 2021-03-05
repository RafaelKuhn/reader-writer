using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Filler : MonoBehaviour
{
    public FillableEntity entity;
    private Slider slider;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void _Fill()
    {
        entity.Fill( slider.value );
    }
}
