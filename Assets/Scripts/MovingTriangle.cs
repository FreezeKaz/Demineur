using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingTriangle : MonoBehaviour
{
    public int rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        switch (Difficulty_Button.Instance.index)
        {
            case 2:
                transform.localScale = new Vector3(1.83f, 1.83f, 1.83f);
                break;
            case 3:
                transform.localScale = new Vector3(2.24f, 2.24f, 2.24f);
                break;
        }
    }

    // Update is called once per frame
    void Update()   
    {
        transform.Rotate(new Vector3(0, 0, 0.01f));
    }
}
