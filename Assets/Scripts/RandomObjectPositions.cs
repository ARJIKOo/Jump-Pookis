using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class RandomObjectPositions : MonoBehaviour
{
    [SerializeField] private Transform[] transformsPositions;
    [SerializeField] private Vector3 objectScale;

    private int transformNum;

    private void Awake()
    {
        Vector3 position = transform.position;
        position.z = 0;
        transform.position = position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        transform.localScale = objectScale;
        transformNum = Random.Range(0, transformsPositions.Length);
        transform.position = transformsPositions[transformNum].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
