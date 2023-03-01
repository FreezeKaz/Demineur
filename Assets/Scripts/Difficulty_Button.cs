using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public sealed class Difficulty_Button : MonoBehaviour
{
    public int index = 0;
    [SerializeField] public Sprite[] spriteArray;
    private static Difficulty_Button _instance = null;
    public static Difficulty_Button Instance => _instance;

    // Start is called before the first frame update
    public void Start()
    {
        index = 0;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
        }

    }

    public void AddOne()
    {
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

