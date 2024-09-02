using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningCube : EnemyScript
{
    //Script for the Cubes in the Beginning of Level 1 which spawn enemies until they are destroyed

    [SerializeField] private List<GameObject> enemyType;
    [SerializeField] private float cooldown;
    [SerializeField] private float timer;

    [SerializeField] private Transform spawnposition;

    public void Update()
    {
        SpawnEnemyOfPortal(enemyType[0]);
    }

    void SpawnEnemyOfPortal(GameObject _enemy) 
    {
        if (timer <= 0) 
        {
            Instantiate(_enemy, spawnposition.position, Quaternion.identity);
            timer = cooldown;
        }
        timer -= Time.deltaTime;
    }


}
