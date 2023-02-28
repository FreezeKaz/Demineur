using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class CreateDemineur : MonoBehaviour
{
    [SerializeField] GameObject clear;
    [SerializeField] GameObject bomb;
    [SerializeField] Camera cam;
    System.Random random = new System.Random();
    List<GameObject> bombs = new List<GameObject>();
    public GameObject[,] selectorArray { get; set; }
    [SerializeField] int max = 5;
    [SerializeField] int min = -4;
    [SerializeField] int bombNumber = 10;


    [SerializeField] public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        switch (Difficulty_Button.index)
        {
            case 1:
                max = 5;
                min = -4;
                bombNumber = 1;
                cam.orthographicSize = 5f;
                break;
            case 2:
                max = 10;
                min = -9;
                bombNumber = 45;
                break;
            case 3:
                max = 15;
                min = -14;
                bombNumber = 90;
                cam.orthographicSize = 15;
                break;
        }
        int count;
        selectorArray = new GameObject[max - min, max - min];
        for (int i = 0; i < bombNumber; i++)
        {
            if (!CreateBomb())
            {
                CreateBomb();
            }
        }
        for (int i = min; i < max; i++)
        {
            for (int j = min; j < max; j++)
            {
                count = 0;
                GameObject block = Instantiate(clear, new Vector2(j, i), Quaternion.identity);
                block.transform.GetChild(0).gameObject.SetActive(false);
                selectorArray[i - min, j - min] = block;

                foreach (var bomb in bombs)
                {
                    if (bomb.transform.position == block.transform.position)
                    {
                        bomb.transform.SetParent(block.transform, true);
                    }
                    else if (bombCheck(bomb.transform.position, block.transform.position) && bomb.transform.position != block.transform.position)
                    {
                        count += 1;
                        block.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[count];
                    }
                }
            }
        }
    }

    public bool CreateBomb()
    {
        int x = random.Next(min, max);
        int y = random.Next(min, max);
        GameObject myBomb = Instantiate(bomb, new Vector2(x, y), Quaternion.identity);

        foreach (var bomb in bombs)
        {
            if (bomb.transform.position == myBomb.transform.position)
            {
                Destroy(myBomb);
                return false;
            }
        }
        bombs.Add(myBomb);
        return true;
    }


    public GameObject[,] getArray() { return selectorArray; }


    public bool bombCheck(Vector2 bombPos, Vector2 pos)
    {
        if (bombPos == pos + new Vector2(1, 1) ||
            bombPos == pos + new Vector2(1, 0) ||
            bombPos == pos + new Vector2(0, 1) ||
            bombPos == pos + new Vector2(-1, -1) ||
            bombPos == pos + new Vector2(-1, 0) ||
            bombPos == pos + new Vector2(0, -1) ||
            bombPos == pos + new Vector2(-1, 1) ||
            bombPos == pos + new Vector2(1, -1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void RevealAll(GameObject clickedObject)
    {
        foreach (var block in selectorArray)
        {
            if (bombCheck(clickedObject.transform.position, block.transform.position))
            {
                block.GetComponent<ClickEvent>().click();
            }

        }
    }

    public bool CheckWin()
    {
        int win = 0;
        for (int i = min; i < max; i++)
        {
            for (int j = min; j < max; j++)
            {
                GameObject block = selectorArray[i - min, j - min];
                if (block.transform.GetChild(0).gameObject.activeSelf == true && block.transform.childCount == 3) win++;
            }
        }
        if (win == bombNumber)
        {
            Debug.Log("let's go");
            return true;
        }
        else
        {
            return false;
        }
    }

}