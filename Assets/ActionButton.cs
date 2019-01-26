using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    public Image image;
    public GameItem gameItem;
    public PlayerController playerController;

    private Button button;

    private void Awake()
    {
        playerController = PlayerController.instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        image.sprite = gameItem.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController)
        {
            // Make button work or not depending on currency
            if (button.IsInteractable() && playerController.currency < gameItem.price)
            {
                button.interactable = false;
            }
            else if (!button.IsInteractable() && playerController.currency >= gameItem.price)
            {
                button.interactable = true;
            }
        }
    }

    public void OnClick()
    {
        playerController.selectedTurret = gameItem;
    }
}
