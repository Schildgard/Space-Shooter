using UnityEngine;

public class TunnelTransperancy : MonoBehaviour
{
    //This Script makes the wall of the tunnel transparent so the player can still see where he goes.
    //Layer 3 = Player
    [SerializeField] private GameObject TransparentWall;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
                TransparentWall.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            TransparentWall.SetActive(true);
        }
    }
}
