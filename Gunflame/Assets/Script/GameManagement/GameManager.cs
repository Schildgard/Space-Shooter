using UnityEngine;

public class GameManager : MonoBehaviour
{
    //In Retroperspective the GameManager in his current implementation does not make a lot of scense and should be removed or rebuild.
    public static GameManager instance;
    public HUDHandler HUDHandler;
    public SceneLoader sceneloader;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
    }
}
