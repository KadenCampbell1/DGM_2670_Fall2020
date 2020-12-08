using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class LevelLoaderData : ScriptableObject
{
    public void OnLevelLoad(string level)
    {
        SceneManager.LoadScene(level,LoadSceneMode.Additive);
    }
}