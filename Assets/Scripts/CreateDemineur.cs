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
    [SerializeField] SpriteRenderer background;
    System.Random random = new System.Random();
    List<GameObject> bombs = new List<GameObject>();
    public GameObject[,] selectorArray { get; set; }
    public bool created = false;
    private int max = 5;
    private int min = -4;   
    private int bombNumber = 10;
    [Header("Assets")]
    [SerializeField] public GameObject victory;
    [SerializeField] public GameObject blurr;
    [SerializeField] public GameObject defeat;


    public bool _stop = false;
    [SerializeField] public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        victory.SetActive(false);
        defeat.SetActive(false);
        switch (Difficulty_Button.Instance.index)
        {
            case 1:            
                max = 4;
                min = -3;
                bombNumber = 5;
                cam.orthographicSize = 5f;
                background.transform.localScale = new Vector3(0.93f,0.93f,0.93f);
                break;
            case 2:              
                max = 7;    
                min = -6;
                cam.orthographicSize = 9.16f;
                background.transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
                bombNumber = 25;
                break;
            case 3:           
                max = 10;
                min = -9;
                bombNumber = 90;
                cam.orthographicSize = 12f;
                background.transform.localScale = new Vector3(2.27f, 2.27f, 2.27f);
                break;
        }
       
        selectorArray = new GameObject[max - min, max - min];

        for (int i = min; i < max; i++)
        {
            for (int j = min; j < max; j++)
            {
                GameObject block = Instantiate(clear, new Vector2(j, i), Quaternion.identity);
                block.transform.GetChild(0).gameObject.SetActive(false);
                block.transform.GetChild(1).gameObject.SetActive(false);
                selectorArray[i - min, j - min] = block;

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
        for (int i = min; i < max; i++)
        {
            for (int j = min; j < max; j++)
            {
                GameObject block = selectorArray[i - min, j - min];
                if (myBomb.transform.position == block.transform.position)
                {
                    myBomb.transform.SetParent(block.transform, true);
                }
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

    public void LooseGame()
    {
        defeat.gameObject.SetActive(true);
        blurr.transform.position = new Vector2(cam.transform.position.x, cam.transform.position.y);
    }
    public bool CheckWin()
    {
        int win = 0;
        if (CheckIfAllRevealed())
        {
            for (int i = min; i < max; i++)
            {
                for (int j = min; j < max; j++)
                {
                    GameObject block = selectorArray[i - min, j - min];
                    if (block.transform.GetChild(0).gameObject.activeSelf == true && block.transform.childCount == 3) win++;
                }
            }
        }
        if (win == bombNumber)
        {
            _stop = true;
            victory.gameObject.SetActive(true);
            blurr.transform.position = new Vector2(cam.transform.position.x, cam.transform.position.y);
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckIfAllRevealed()
    {
        int count = 0;
        for (int i = min; i < max; i++)
        {
            for (int j = min; j < max; j++)
            {
                GameObject block = selectorArray[i - min, j - min];
                if (block.transform.GetChild(1).gameObject.activeSelf == true) count++;
            }
        }
        if (count == (max + Math.Abs(min)) * (max + Math.Abs(min)) - bombNumber)
        {
            Debug.Log("oui");
            return true;
        }
        else
        {
            return false;
        }
    }
    public void CreateAllBomb()
    {
        foreach (var bomb in bombs)
        {
            bomb.transform.parent = null;
            Destroy(bomb);
        }
        bombs.Clear();
        // Debug.Log(bombs.Count);
        for (int i = 0; i < bombNumber; i++)
        {
            if (!CreateBomb())
            {
                CreateBomb();
            }
        }
        AddNumbers();
        }
    public void AddNumbers()
    {
        for (int i = min; i < max; i++)
        {
            for (int j = min; j < max; j++)
            {
                int count = 0;
                foreach (var bomb in bombs)
                {
                    if (bombCheck(bomb.transform.position, selectorArray[i - min, j - min].transform.position) && bomb.transform.position != selectorArray[i - min, j - min].transform.position)
                    {
                        count += 1;
                    }
                    selectorArray[i - min, j - min].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[count];
                }
            }
        }

    }
}