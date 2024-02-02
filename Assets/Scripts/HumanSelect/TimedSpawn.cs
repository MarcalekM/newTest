using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> spawnee;
    public float spawnTime;
    public float spawnDelay;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    void SpawnObject()
    {
        int index = Random.Range(0, spawnee.Count);
        var selectedSpawnee = spawnee[index];

        GameObject spawnedObject = Instantiate(selectedSpawnee, transform.position, transform.rotation);
        Move moveScript = spawnedObject.GetComponent<Move>();  // Hozzáférés a Move scripthez

        if (moveScript != null)
        {
            moveScript.enabled = true;  // Engedélyezzük a mozgatást
        }
    }
}
