using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruit;
    public Transform[] spawnPoints;
    public float minDelay = 0.1f;
    public float maxDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }
    IEnumerator SpawnFruits()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            int spawnPositionIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPosition = spawnPoints[spawnPositionIndex];
            GameObject go = Instantiate(fruit, spawnPosition.position, spawnPosition.rotation);
            Destroy(go, 5);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
