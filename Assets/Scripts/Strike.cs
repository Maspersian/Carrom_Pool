using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Strike : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Transform selfTrans;
    Vector2 startPos;
    public Slider mySlider;
    Vector2 direction;
    Vector3 mousePos;
    Vector3 mousePos2;
    public LineRenderer line;
    bool hasStriked =false;
    bool positionSet = false;
    public GameObject bord;
    public static Strike instance;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        selfTrans = transform;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        line.enabled = false;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos2 = new Vector3(-mousePos.x, -mousePos.y-3, mousePos.z);
       /* if(mousePos2.y> -2.3802)
        {
            mousePos2.y = -2.3802f;
        }*/
        /*if (mousePos2.y < -0.11)
        {
            mousePos2.y = -0.11f;
        }
        if (mousePos2.x <-0.11)
        {
            mousePos2.y = -0.11f;
        }
        if (mousePos2.x < 2.84)
        {
            mousePos2.x = 2.84f;
        }*/
        if (!hasStriked && !positionSet)
        {
            selfTrans.position = new Vector2(mySlider.value, startPos.y);
        }
        if (Input.GetMouseButtonUp(0) && rigidbody.velocity.magnitude==0 && positionSet)
        {
            ShootStricker();
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!positionSet)
                {
                    positionSet = true;
                }
            }
        }

        if(positionSet && rigidbody.velocity.magnitude == 0)
        {
            line.enabled = true;
            line.SetPosition(0, selfTrans.position);           // line strating point
            line.SetPosition(1, mousePos2);                    // line ending point or ending direction
        }
        if(rigidbody.velocity.magnitude<0.2f && rigidbody.velocity.magnitude != 0)
        {
            StrikerReset();
            bord.GetComponent<GameManager>().count++;
        }
        
    }
    public void StrikerReset()
    {
        Debug.Log("Strike Reset");
        rigidbody.velocity = Vector2.zero;
        hasStriked = false;
        positionSet = false;
        line.enabled = true;
    }
    public void ShootStricker()
    {
        float x = 0;
        if (positionSet && rigidbody.velocity.magnitude == 0)
        {
            x = Vector2.Distance(transform.position, mousePos);
        }
        direction = (Vector2)(mousePos2 - transform.position);
        direction.Normalize();

        rigidbody.AddForce(direction *x* 200);
        hasStriked=true;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
    }
}
