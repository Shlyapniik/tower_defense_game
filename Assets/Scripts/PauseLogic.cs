using UnityEngine;

public class PauseLogic : MonoBehaviour
{
    public void PauseFunction()
    {
        if (Time.timeScale > 0f)
        {
            Time.timeScale = 0f;
        }
        else if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }
}
