using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{



    [SerializeField] private GameObject original;
    [SerializeField] private GameObject target;
    public GameObject[,] selectorArr;

    // Start is called before the first frame update
    void Start()
    {
        selectorArr = new GameObject[10,10];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                selectorArr[i, j] = Instantiate(original, new Vector2( -5 + 1 * j, -4.5f + 1 * i), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
