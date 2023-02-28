using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty_Button : MonoBehaviour
{
    static public int index = 0;
    [SerializeField] public Sprite[] spriteArray;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void AddOne()
    {
        Debug.Log(index);
        if (index == spriteArray.Length - 1)
        {
            index = 1;
        }
        else
        {
            index++;
        }
        GetComponent<Image>().sprite = spriteArray[index];
    }
}
