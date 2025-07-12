using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    // public Transform[] coins;
    private Vector3[] startPoscoins;
    public GameObject[] coinsObject;

    private void Awake()
    {
        startPoscoins = new Vector3[coinsObject.Length];

        for (int i = 0; i < coinsObject.Length; i++)
        {
            startPoscoins[i] = coinsObject[i].transform.position;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetButton()
    {
        for (int i = 0; i < coinsObject.Length; i++)
        {
            coinsObject[i].transform.position = startPoscoins[i];
            coinsObject[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Optional: stop movement
            coinsObject[i].GetComponent<Rigidbody2D>().angularVelocity = 0f;     // Optional: stop rotation
        }
        Strike.instance.StrikerReset();
        CoinCollecter.instance.pointA = 0;
        CoinCollecter.instance.pointB = 0;
    }
}
