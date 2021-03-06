using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    [SerializeField] private SpriteRenderer redLight;
    [SerializeField] private SpriteRenderer yellowLight;
    [SerializeField] private SpriteRenderer greenLight;

    public void ToggleRedLight()
    {
        yellowLight.gameObject.SetActive( false );
        redLight.gameObject.SetActive( true );

        greenLight.gameObject.SetActive( false );
    }

    public void ToggleGreenLight()
    {
        yellowLight.gameObject.SetActive( false );
        redLight.gameObject.SetActive( false );

        greenLight.gameObject.SetActive( true );
    }

    public void ToggleYellowLight()
    {
        redLight.gameObject.SetActive( false );
        greenLight.gameObject.SetActive( false );

        yellowLight.gameObject.SetActive( true );
    }

    void Start()
    {
        ToggleRedLight();
    }

}
