using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Casse-briques");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
