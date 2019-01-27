using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    public Image image;
    public GameItem gameItem;

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        image.sprite = gameItem.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        // Make button work or not depending on currency
        if (button.IsInteractable() && PlayerController.instance.currency < gameItem.price)
        {
            button.interactable = false;
        }
        else if (!button.IsInteractable() && PlayerController.instance.currency >= gameItem.price)
        {
            button.interactable = true;
        }
    }

    public void OnClick()
    {
        PlayerController.instance.selectedTurret = gameItem;
        Cursor.SetCursor(image.sprite.texture, Vector2.zero, CursorMode.Auto);
    }
}
