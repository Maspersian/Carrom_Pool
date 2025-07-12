using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollecter : MonoBehaviour
{
    public int pointA = 0;
    public int pointB = 0;
    public TextMeshProUGUI pointsA;
    public TextMeshProUGUI pointsB;
   // public GameObject strikerB;
   // public GameObject board;
   public static CoinCollecter instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(GameManager.instance.count);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Striker")
        {
            Debug.Log("Striker hit the coin collector");
            //GameManager.instance.count++;
           // Strike.instance.StrikerReset();
            Debug.Log(GameManager.instance.count);

            /* if(GameManager.instance.count %2==0)
             {
                 Debug.Log("PointA Working");
                 pointA -= 1;
                 GameManager.instance.count++;
                 Strike.instance.StrikerReset();
             }
             else
             {
                 Debug.Log("PointB Working");
                 pointB -= 1;
                 GameManager.instance.count++;
                 Strike.instance.StrikerReset();
                 //pointsB.text = "Points: " + pointB.ToString();
             }*/
        }
        else if (collision.gameObject.tag == "RedCoin")
        {
            Destroy(collision.gameObject);
            if (GameManager.instance.count % 2 == 0)
            {
                Debug.Log("PointA Working");

                pointA += 5;
            }
            else
            {
                Debug.Log("PointB Working");
                pointB += 5;
                //pointsB.text = "Points: " + pointB.ToString();
            }

        }
        else if (collision.gameObject.tag == "WhiteCoin")
        {
            Destroy(collision.gameObject);
            if (GameManager.instance.count % 2 == 0)
            {
                Debug.Log("PointA Working");

                pointA += 2;
            }
            else
            {
                Debug.Log("PointB Working");
                pointB += 2;
                //pointsB.text = "Points: " + pointB.ToString();
            }

        }
        else
        {
            Destroy(collision.gameObject);
            if (GameManager.instance.count % 2 == 0)
            {
                Debug.Log("PointA Working");
                pointA += 1;
            }
            else
            {
                Debug.Log("PointB Working");
                pointB += 1;
                //pointsB.text = "Points: " + pointB.ToString();
            }

        }
       
        pointsA.text = "Points: " + pointA.ToString();
        pointsB.text = "Points: " + pointB.ToString();


    }

}
