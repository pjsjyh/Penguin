using UnityEngine;
using UnityEngine.SceneManagement;
using LoginM;
public class gameoverManager : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        // 씬 이름으로 로드
        SceneManager.LoadScene(sceneName);
        if (sceneName == "LobbyScene")
        {
            LoginManager.Instance.startsong.Play();
        }
    }
}
