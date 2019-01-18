using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject fruitSlicedPrefab;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Blade")
        {
            Instantiate(fruitSlicedPrefab,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
