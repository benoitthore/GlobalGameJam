using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Region : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseEnter()
    {
        spriteRenderer.color = Color.red;
        Debug.Log("Mouse Over");    
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = Color.white;
    }
}