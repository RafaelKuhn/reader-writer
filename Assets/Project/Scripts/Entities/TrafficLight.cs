using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    [SerializeField] private SpriteRenderer redLight;
    [SerializeField] private SpriteRenderer yellowLight;
    [SerializeField] private SpriteRenderer greenLight;

    private bool isAllowed;
    public bool IsAllowed
    {
        get { return isAllowed; }
        set
        {
            isAllowed = value;

            yellowLight.gameObject.SetActive( false );

            if (isAllowed)
            {
                greenLight.gameObject.SetActive( true );
                redLight.gameObject.SetActive( false );
            }

            else
            {
                greenLight.gameObject.SetActive( false );
                redLight.gameObject.SetActive( true );
            }
        }
    }

    public void ResetToYellow()
    {
        yellowLight.gameObject.SetActive( true );
        redLight.gameObject.SetActive( false );
        greenLight.gameObject.SetActive( false );
    }

    void Start()
    {
        ResetToYellow();
    }

}
