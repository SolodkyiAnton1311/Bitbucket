using UnityEngine;
using UnityEngine.SceneManagement;
namespace SceneManagers
{
    public class MainMenuSceneManager : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}