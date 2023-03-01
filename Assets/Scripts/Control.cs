using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField]
    public GameObject particles;
    public Vector2 mousePosition;
   private void Start()
    {
        particles.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            particles.SetActive(false);
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            particles.SetActive(true);
            particles.transform.position = new Vector2(mousePosition.x, mousePosition.y);
        }

        //if (Input.GetMouseButtonUp(0))
        //{
        //    particles.SetActive(false);
        //}
    }
}
