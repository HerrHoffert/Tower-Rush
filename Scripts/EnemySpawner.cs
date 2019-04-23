using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab = null;
    [SerializeField] Transform enemyParentTransform = null;
    [SerializeField] Text spawnedEnemies = null;
    [SerializeField] AudioClip spawnedEnemySFX = null;

    int score;

    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());

        spawnedEnemies.text = score.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // forever
        {
            AddScore();

            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);

            var newEnemy = Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation);
            newEnemy.transform.parent = enemyParentTransform;

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        score++;
        spawnedEnemies.text = score.ToString();
    }
}