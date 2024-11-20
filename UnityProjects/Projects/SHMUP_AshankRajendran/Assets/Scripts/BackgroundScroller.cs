using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.5f;
    Material mySpriteRenderer;
    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>().material;
        offset = new Vector2(scrollSpeed , 0);
    }

    // Update is called once per frame
    void Update()
    {
        mySpriteRenderer.mainTextureOffset += offset * Time.deltaTime;
    }
}
