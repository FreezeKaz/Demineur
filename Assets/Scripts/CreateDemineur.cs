using UnityEngine;

public class CreateDemineur : MonoBehaviour
{
    [SerializeField] private GameObject Case_Clear;
    [SerializeField] private GameObject Case_Bomb;
    [SerializeField] private GameObject Case_Flag;
    [SerializeField] private GameObject Case_One;
    void Start()
    {
        int x = 0;
        int y = 1;
        int c;
        for (int i = 0; i < 25; i++)
        {
            c = Random.Range(0, 4);
            if (i % 5 == 0)
            {
                y -= 1;
                x = 0;
            }

            switch (c)
            {
                case 0:
                    Instantiate(Case_Clear, new Vector2(x, y), Quaternion.identity);
                    break;

                case 1:
                    Instantiate(Case_Bomb, new Vector2(x, y), Quaternion.identity);
                    break;

                case 2:
                    Instantiate(Case_Flag, new Vector2(x, y), Quaternion.identity);
                    break;

                case 3:
                    Instantiate(Case_One, new Vector2(x, y), Quaternion.identity);
                    break;
            }
            x += 1;


        }
    }
}