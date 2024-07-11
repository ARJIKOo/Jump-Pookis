using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private bool waterTach;
    [SerializeField] private GameObject Pookies;
    [SerializeField] private Vector3 pookiesTransfrom;

    [Header("COIN")] [SerializeField] private TMP_Text TMPText;
    [SerializeField] private int coinCount=0;

    [SerializeField] private GameObject RestartPanel;

    private void Start()
    {
        RestartPanel.SetActive(false);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, -3.68f, transform.position.z);
        TMPText.text = coinCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            Debug.Log("tach Boat");
            //pookiesTransfrom.x = other.gameObject.transform.position.x;
            waterTach = true;
            return;
        }
        if (other.gameObject.CompareTag("Water") && waterTach==false )
        {
            Debug.Log("tach Water");
            waterTach = true;
            Destroy(gameObject);
            RestartPanel.SetActive(true);
            
        }

        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            coinCount += 1;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            Debug.Log("test");
            pookiesTransfrom.x = other.gameObject.transform.position.x;
            pookiesTransfrom.y = transform.position.y;
            
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            Debug.Log("exit Boat");
            waterTach = false;
            
        }
    }
}
