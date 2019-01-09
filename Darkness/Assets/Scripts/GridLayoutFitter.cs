using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GridLayoutFitter : MonoBehaviour {

    public GameObject container;
    public float divide;
    public void Update()
    {
        float width = container.GetComponent<RectTransform>().rect.width;
        Vector2 newSize = new Vector2(width / divide, width / divide);
        container.GetComponent<GridLayoutGroup>().cellSize = newSize;
    }
}
