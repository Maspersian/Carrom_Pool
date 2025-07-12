using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int count = 0;
    public GameObject striker1;
    public GameObject striker2;
    public static GameManager instance;

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
        if(count % 2 == 0)
        {
            striker1.SetActive(true);
            striker2.SetActive(false);
        }
        else
        {
            striker2.SetActive(true);
            striker1.SetActive(false);
        }

    }
}
