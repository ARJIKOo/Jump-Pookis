using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWidth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScaleObjectToScreenWidth();
    }

    void ScaleObjectToScreenWidth()
    {
        float screeWidthInPixels = Screen.width;
        Camera mainCamera = Camera.main;

        float screenWidthInWorldUnits = mainCamera.ScreenToWorldPoint(new Vector3(screeWidthInPixels, 0, mainCamera.transform.position.z)).x * 2;
        Vector3 currentScale = transform.localScale;
        currentScale.x = screenWidthInWorldUnits;
        transform.localScale = currentScale;
    }

  
}
