using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject selectedTurret;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var mousePosition = Input.mousePosition;
            var mousePositionWorld = Camera.main.ScreenToWorldPoint(new Vector2(mousePosition.x, mousePosition.y));
            mousePositionWorld.z = transform.position.z;
            placeTurretAt(mousePositionWorld);
        }
    }

    private void placeTurretAt(Vector3 position)
    {
        Debug.Log(position);
        Instantiate(selectedTurret, position, Quaternion.identity);
    }
}