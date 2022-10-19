
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DeathEdgeSpawner : MonoBehaviour
{
    [SerializeField] private float minTimeToSpawn;
    [SerializeField] private float maxTimeToSpawn;
    private bool condition = true;
    private Collider2D areaSpawn;
    [SerializeField] GameObject[] deathEdgesPrefabs;

    void Start()
    {
        areaSpawn = GetComponent<Collider2D>();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        float timeToSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);
        yield return new WaitForSeconds(timeToSpawn);
        SetEdge();
        if(condition)
            StartCoroutine(Spawn());
    }
    private void SetEdge()
    {
        int deathEdgeIndex = Random.Range(0,deathEdgesPrefabs.Length);
        if (Random.Range(0, 1000 )% 2 == 0) // leftWall
        {
            Instantiate(deathEdgesPrefabs[deathEdgeIndex], new Vector2(areaSpawn.bounds.min.x,areaSpawn.transform.position.y),
                Quaternion.Inverse(deathEdgesPrefabs[deathEdgeIndex].transform.rotation));
        }
        else
        {
            Instantiate(deathEdgesPrefabs[deathEdgeIndex], new Vector2(areaSpawn.bounds.max.x, areaSpawn.transform.position.y),
                deathEdgesPrefabs[deathEdgeIndex].transform.rotation);
        }
    }
}
