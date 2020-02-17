using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckForRestart : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Minigame");
        }
    }
}
