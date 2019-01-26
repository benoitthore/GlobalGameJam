using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public GameObject selectedTurret;
    private bool isPlacingDefence = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (isPlacingDefence)
        {
            var mousePosition = Input.mousePosition;
            var mousePositionWorld = Camera.main.ScreenToWorldPoint(new Vector2(mousePosition.x, mousePosition.y));
            mousePositionWorld.z = transform.position.z;

            if (Input.GetMouseButtonUp(0))
            {
                placeTurretAt(mousePositionWorld);
                SetPlacingDefence(false);
            }
        }
    }

    private void placeTurretAt(Vector3 position)
    {
        Debug.Log(position);
        Instantiate(selectedTurret, position, Quaternion.identity);
    }

    public void SetPlacingDefence(bool isPlacing)
    {
        isPlacingDefence = isPlacing;
    }
}