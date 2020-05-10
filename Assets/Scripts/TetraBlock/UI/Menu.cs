using UnityEngine;
using UnityEngine.SceneManagement;

namespace TetraBlock.UI
{
    public class Menu : MonoBehaviour
    {
        public void OnNewGameClick()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
