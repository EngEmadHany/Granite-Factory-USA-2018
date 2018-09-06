using UnityEngine;
using UnityEngine.SceneManagement;

public class openScene : MonoBehaviour {
    

    public void load(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
