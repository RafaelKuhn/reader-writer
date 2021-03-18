using UnityEngine;

[DisallowMultipleComponent]
public class GamePauser : MonoBehaviour
{
    public static bool isPaused { get; private set; } = false;

    public void _ResumeButtonClicked()
    {
        ResumeGame();
    }

    public void _PauseButtonClicked()
    {
        PauseGame();
    }

    private void PauseGame()
    {
        isPaused = true;
    }

    private void ResumeGame()
    {
        isPaused = false;
    }
}
