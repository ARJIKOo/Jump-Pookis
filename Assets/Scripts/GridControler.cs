using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridControler : MonoBehaviour
{
    [SerializeField] private CustomGridLayout CustomGridLayout;
    [SerializeField] private GameObject prefab1;

    [SerializeField] private GameObject prefab2;

    private int call = 15;

    private bool actionTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < call; i++)
        {
            CustomGridLayout.AddItem(prefab1,prefab2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleTouchInput();
        if (Input.GetKeyDown(KeyCode.M))
        {
            CustomGridLayout.AddItem(prefab1,prefab2);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            CustomGridLayout.RemoveFirstItem();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CustomGridLayout.AddItem(prefab1,prefab2);
            CustomGridLayout.RemoveFirstItem();
        }
    }

    public void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && actionTrigger == false)
            {
                TriggerAction();
                actionTrigger = true;
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                actionTrigger = false;
            }
        }
    }

    public void TriggerAction()
    {
        Debug.Log("shexeba");
        CustomGridLayout.AddItem(prefab1,prefab2);
        CustomGridLayout.RemoveFirstItem();
    }
}
