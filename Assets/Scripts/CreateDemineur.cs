using UnityEngine;

public class CreateDemineur : MonoBehaviour
{
    [SerializeField] private GameObject Case_Clear;
    [SerializeField] private GameObject Case_Bomb;
    System.Random random = new System.Random();
    int max = 5;
    int min = -4;

    public GameObject[,] selectorArr;
    void Start()
    {
        selectorArr = new GameObject[10, 10];

        // Start is called before the first frame update

        for (int i = 0; i < 10; i++)
        {
            //Cells
            for (int j = 0; j < 10; j++)
            {
                //Instantiate(Case_Clear, new Vector2(j - 4, i - 4), Quaternion.identity);
                selectorArr[i, j] = Instantiate(Case_Clear, new Vector2(j - 4, i - 4), Quaternion.identity);
            }
        }

        for (int i = 0; i < 10; i++)
        {
            //Bombs
            int x = random.Next(min, max);
            int y = random.Next(min, max);
            //Instantiate(Case_Bomb, new Vector2(x, y), Quaternion.identity);
            selectorArr[x + 4, y + 4] =  Instantiate(Case_Bomb, new Vector2(x, y), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }
}