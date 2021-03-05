using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TrafficLightSwitcher : MonoBehaviour
{
    public TrafficLight traffic;

    public void _Click()
    {
        traffic.IsAllowed = !traffic.IsAllowed;
    }
}
