using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    // This function will be called when the Start button is pressed
    public void StartGame()
    {
        // Replace "NextScene" with the name of the scene you want to load
        SceneManager.LoadScene("New Scene");
        
        // Alternatively, you can load by build index if you prefer:
        // SceneManager.LoadScene(1);
    }
}
