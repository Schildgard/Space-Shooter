using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // This Scripts sets basic methods which Enemies need for their behaviour to work such as calcule the direction to Player.
    [SerializeField] private float ramDmg;

    public void OnDestroy()
    {
        GameManager.instance.HUDHandler.AddKillScore();
    }

    public virtual void OnTriggerEnter(Collider collision)
    {
        //Deal Player Damage on Collision
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthSystem>().TakeDamage(ramDmg);
        }
        //Destroy if out of Area borders
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }

    public float SqrMagnitude(Vector2 _vector)
    {
        float sqrMagnitude = (_vector.x * _vector.x) + (_vector.y * _vector.y);
        return sqrMagnitude;
    }

    public Vector3 GetNormalizedDistance(Vector3 _player, Vector3 _enemy)
    {
        Vector3 Distance = _player - _enemy;
        return Vector3.Normalize(Distance);
    }

    public float CompareDistance(Vector2 _player, Vector2 _enemy)
    {
        Vector2 Distance = _player - _enemy;
        return SqrMagnitude(Distance);
    }
}
