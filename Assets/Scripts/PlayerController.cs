using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public GameObject gameUI;
    public AudioSource gameMusic;
    public AudioSource gameOverMusic;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Reset game over UI
        Time.timeScale = 1;
        ToggleUI(true);
        PlayGameMusic();

        instance = this;
    }

    public GameItem selectedTurret;
    public int score = 0;
    public int currency = 10;
    
    
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
                placeTurretAt(selectedTurret.prefab,mousePositionWorld);
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                SetCurrency(currency - selectedTurret.price);
                selectedTurret = null;
            }
        }
    }

    private void placeTurretAt(GameObject turret,Vector3 position)
    {
        Instantiate(turret, position, Quaternion.identity);
    }

    public void SetCurrency(int amount)
    {
        currency = amount;
    }

    public void SetScore(int amount)
    {
        score = amount;
    }

    public void ToggleUI(bool visible)
    {
        gameUI.SetActive(visible);
    }

    public void PlayGameMusic()
    {
        gameOverMusic.Stop();
        gameMusic.time = 0;
        gameMusic.Play();
    }

    public void PlayGameOverMusic()
    {
        gameMusic.Stop();
        gameOverMusic.time = 0;
        gameOverMusic.Play();
    }

    
}