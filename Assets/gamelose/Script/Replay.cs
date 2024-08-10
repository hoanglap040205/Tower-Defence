using UnityEngine;
using UnityEngine.SceneManagement;
public class Replay : MonoBehaviour
{
    public void ReplayGame()
    {
        // Tải lại scene hiện tại để chơi lại từ đầu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}