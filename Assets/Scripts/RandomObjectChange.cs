using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectChange : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] gameObjects;

    [SerializeField] private Sprite[] Images;
    // Start is called before the first frame update
    void Start()
    {
        foreach (SpriteRenderer gameObjectsprite in gameObjects)
        {
            
            int number =Random.Range(0, Images.Length);
            Sprite ObjectImage = Images[number];
            gameObjectsprite.sprite = ObjectImage;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
