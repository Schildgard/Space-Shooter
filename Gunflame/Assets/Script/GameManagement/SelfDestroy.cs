using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    //This script lies on Objects like Explosions which are supposed to live for a very short time.
    void Update()
    {
        Destroy(gameObject, 1f);
    }
}
