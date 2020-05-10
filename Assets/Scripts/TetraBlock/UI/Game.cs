using UnityEngine;
using UnityEngine.SceneManagement;

namespace TetraBlock.UI
{
    public class Game : MonoBehaviour
    {
        public void OnBackButtonClick()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}