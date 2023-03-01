using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_Button : MonoBehaviour
{
    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
