using UnityEngine;

public class CustomGridLayout : MonoBehaviour
{
    public int columns;
    public float cellWidth;
    public float cellHeight;
    public Vector2 spacing;

    private bool lastSpawWasItem1;

    private void Start()
    {
        ArrangeChildrenInGrid();
    }

    public void ArrangeChildrenInGrid()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);

            int row = i / columns;
            int column = i % columns;

            float xPosition = column * (cellWidth + spacing.x);
            float yPosition = -row * (cellHeight + spacing.y);

            child.localPosition = new Vector3(xPosition, yPosition, 0);
        }
    }

    // Optional: Add methods to dynamically add or remove items
    public void AddItem(GameObject item,GameObject item2)
    {
        GameObject newItem;
        if (lastSpawWasItem1)
        {
            newItem=Instantiate(item, transform);
            ArrangeChildrenInGrid();
            lastSpawWasItem1 = false;
        }
        else
        {
            newItem=Instantiate(item2, transform);
            ArrangeChildrenInGrid();
            lastSpawWasItem1 = true;
        }
        newItem.transform.SetSiblingIndex(0);

        ArrangeChildrenInGrid();
    }

    public void RemoveItem(GameObject item)
    {
        Destroy(item);
        ArrangeChildrenInGrid();
    }

    public void RemoveFirstItem()
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(transform.childCount-1).gameObject);
            ArrangeChildrenInGrid();
        }
        else
        {
            Debug.LogWarning("No items to remove.");
        }
    }

    public void ClearItems()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}