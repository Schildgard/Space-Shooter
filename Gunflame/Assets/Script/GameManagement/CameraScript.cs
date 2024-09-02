using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Transform player;
    private Vector3 smoothCameraFollow;
    [SerializeField] float lerpTime;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    void LateUpdate()
    {
        if (player != null)
        {
            smoothCameraFollow = Vector3.Lerp(smoothCameraFollow, player.position, lerpTime * Time.deltaTime);
        }

        transform.position = new Vector3(smoothCameraFollow.x, smoothCameraFollow.y, transform.position.z);
    }


}
