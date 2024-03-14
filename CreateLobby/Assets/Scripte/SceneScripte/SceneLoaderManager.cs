using Unity.Netcode;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SceneLoaderManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadMainScene());
    }

    IEnumerator LoadMainScene()
    {
        yield return new WaitUntil(()=> NetworkManager.Singleton != null);;
        SceneManager.LoadScene(SceneNameManager.mainMenuLevel);
    }
}
