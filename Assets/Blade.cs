using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    bool isCutting;
    //it is nice to have rigidbody on anything that would move
    //so Unity can apply some optimization
    Rigidbody2D rb;
    Camera cam;
    public GameObject bladeTrailPrefab;
    GameObject currentBladeTrail;
    CircleCollider2D circleCollider;
    Vector2 previousPosition;
    public float minCuttingVelocity = 0.01f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)||(Input.touchCount>0&&Input.GetTouch(0).phase == TouchPhase.Began))
        {
            StartCutting();
        }else if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            StopCutting();
        }
        if(isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {

        Vector3 screenPosition;
        if (Input.GetMouseButton(0))
        {
            screenPosition = Input.mousePosition;
        }
        else
        {
            screenPosition = Input.GetTouch(0).position;
        }
        Vector2 newPosition = cam.ScreenToWorldPoint(screenPosition);
        
        rb.position = newPosition;
        
        if (currentBladeTrail == null)
        {
            previousPosition = newPosition;
            Transform newTrans = transform;
            newTrans.position = newPosition;
            currentBladeTrail = Instantiate(bladeTrailPrefab, newTrans);
        }

        float velocity = (newPosition - previousPosition).magnitude / Time.deltaTime;
        if(velocity> minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }
        previousPosition = newPosition;
    }

    void StartCutting() {
        isCutting = true;
        circleCollider.enabled = false;

    }
    void StopCutting() {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 1);
        currentBladeTrail = null;
        circleCollider.enabled = false;
    }
}
