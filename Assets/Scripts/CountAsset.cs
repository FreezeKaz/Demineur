using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountAsset : MonoBehaviour
{

    [SerializeField] public Sprite[] spriteArray;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Image>().sprite = spriteArray[Difficulty_Button.Instance.index - 1];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
