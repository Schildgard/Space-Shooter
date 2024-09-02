using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    //This Script sets the maximum life, and handles its behaviour when it takes damage or dies

    [SerializeField] private float health;
    [SerializeField] private GameObject destroyAnimation;

    public void TakeDamage(float _damage)
    {
        health -= _damage;
        GetComponent<HUD>().ChangeLife(health);


        if (gameObject.tag == "Player")
        {
            PlayerBlink PlayerAnim = GetComponentInChildren<PlayerBlink>();
            PlayerAnim.Source.Play();
            StartCoroutine(PlayerAnim.c_blink());
        }

        if (health <= 0)
        {
            health = 0;
            Instantiate(destroyAnimation, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (gameObject.tag == "Player")
            {
                GameManager.instance.sceneloader.EndGame();
            }
        }
    }
}
