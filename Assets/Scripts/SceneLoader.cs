using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour //HUOM! Nimi pitää olla sama
{

    public void LoadSceneOnClick(int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }

}