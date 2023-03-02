using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField]
    public GameObject particles;
    public GameObject particles2;
    public GameObject particles3;
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
            particles2.SetActive(false);
            particles3.SetActive(false);

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            particles.SetActive(true); 
            particles2.SetActive(true);
            particles3.SetActive(true);

            particles.transform.position = new Vector2(mousePosition.x, mousePosition.y);
            particles2.transform.position = new Vector2(mousePosition.x, mousePosition.y);
            particles3.transform.position = new Vector2(mousePosition.x, mousePosition.y);

        }

        //if (Input.GetMouseButtonUp(0))
        //{
        //    particles.SetActive(false);
        //}
    }
}
