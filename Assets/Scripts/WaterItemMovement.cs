using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaterItemMovement : MonoBehaviour
{

    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] private float speed;
    private bool isSomethingInBoat=false;
    
    // boat random start position 
    [SerializeField] private Transform[] BoatStartPositions;
    private int positionNum;
    private System.Random random;
    
    // boat speed
    [SerializeField] private int startSpeed;
    [SerializeField] private int endSpeed;
    
    // Start is called before the first frame update

    private void Awake()
    {
        random = new System.Random();
    }

    void Start()
    {
        InitializeBoat();
    }
    
    private void InitializeBoat()
    {
        SetRandomPosition();
        SetRandomSpeed();
        SetBoatDirection();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
        if (other.gameObject.CompareTag("RoadLine"))
        {
            
            SetRandomSpeed();
            SetRandomPosition();
            Debug.Log("shetrialeba");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player") && isSomethingInBoat==false)
        {
            other.transform.SetParent(transform);
            isSomethingInBoat = true;
        }
    }


    private void SetBoatDirection()
    {
        if (positionNum == 0)
        {
            // Flip the boat to face right if it starts on the left
            if (transform.localScale.x < 0)
            {
                Flip();
            }
            speed = Mathf.Abs(speed);
        }
        else
        {
            // Flip the boat to face left if it starts on the right
            if (transform.localScale.x > 0)
            {
                Flip();
            }
            speed = -Mathf.Abs(speed);
        }
    }
    
    private void Flip()
    {
        transform.localScale = new Vector2(-(transform.localScale.x), transform.localScale.y);
    }


    public void SetRandomPosition()
    {
        if (BoatStartPositions.Length > 0)
        {
            positionNum = random.Next(0, BoatStartPositions.Length);
            transform.position = BoatStartPositions[positionNum].position;
            if (positionNum == 0 || positionNum == 2)
            {
                speed = -speed;
            }
            else
            {
                speed = speed;
            }
        }
        else
        {
            Debug.LogWarning("BoatStartPositions array is empty.");
        }
    }

    public void SetRandomSpeed()
    {
        speed = Random.Range(startSpeed, endSpeed);
    }
}
