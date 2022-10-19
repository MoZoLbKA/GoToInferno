using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    private Collider2D spawnArea;
    
    [SerializeField] private float timeOfSpawn;
     
    void Start()
    {
        spawnArea = GetComponent<Collider2D>();
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeOfSpawn);
        Instantiate(coinPrefab, new Vector2(Random.Range(spawnArea.bounds.min.x + 0.5f, spawnArea.bounds.max.x - 0.5f),
            transform.position.y),transform.rotation);
        yield return StartCoroutine(Spawn());
    }

}
