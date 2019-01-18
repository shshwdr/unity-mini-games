using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject fruitSlicedPrefab;
    Rigidbody2D rb;
    public float startForce = 15f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up*startForce,ForceMode2D.Impulse);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Blade")
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            GameObject go =  Instantiate(fruitSlicedPrefab,transform.position,rotation);
            Destroy(gameObject);
            Destroy(go, 5);
        }
    }
}
