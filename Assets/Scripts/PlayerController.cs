using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject selectedTurret;


    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current && EventSystem.current.IsPointerOverGameObject())
            return;

        if (selectedTurret)
        {
            var mousePosition = Input.mousePosition;
            var mousePositionWorld = Camera.main.ScreenToWorldPoint(new Vector2(mousePosition.x, mousePosition.y));
            mousePositionWorld.z = transform.position.z;

            if (Input.GetMouseButtonUp(0))
            {
                placeTurretAt(mousePositionWorld);
                selectedTurret = null;
            }
        }
    }

    private void placeTurretAt(Vector3 position)
    {
        Instantiate(selectedTurret, position, Quaternion.identity);
    }

    
}