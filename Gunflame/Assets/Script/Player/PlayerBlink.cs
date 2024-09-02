using System.Collections;
using UnityEngine;

public class PlayerBlink : MonoBehaviour
{
    [SerializeField] private Renderer mesh;
    public AudioSource Source;
    private void Awake()
    {
        Source = GetComponent<AudioSource>();
    }

    public IEnumerator c_blink()
    {
        mesh.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        mesh.material.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        mesh.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        mesh.material.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        mesh.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        mesh.material.color = Color.white;

    }

}
