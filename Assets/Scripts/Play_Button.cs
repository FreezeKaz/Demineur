using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play_Button : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }
}

