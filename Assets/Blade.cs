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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
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
        rb.position = cam.ScreenToWorldPoint(screenPosition);
    }

    void StartCutting() {
        isCutting = true;
        currentBladeTrail =  Instantiate(bladeTrailPrefab, transform);
    }
    void StopCutting() {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 1);
    }
}
