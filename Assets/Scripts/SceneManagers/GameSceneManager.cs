using UnityEngine;
using UnityEngine.SceneManagement;
namespace SceneManagers
{
    public class GameSceneManager : MonoBehaviour
    {
        public void BackToMainMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
