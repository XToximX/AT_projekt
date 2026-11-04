using UnityEngine;

public class FoodObject : MonoBehaviour, IDraggable
{
    [SerializeField] private bool isDraggable;
    public bool IsDraggable => isDraggable;

    [SerializeField] private FoodData foodData;
    public FoodData FoodData => foodData;

    [SerializeField] private SpriteRenderer sp;
    private BoxCollider2D collider2d;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();

        SetUpItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetUpItem()
    {
        sp.sprite = foodData.sprite;
    }

    public void OnDragStart()
    {
        collider2d.enabled = false;
    }

    public void OnDragEnd()
    {
        collider2d.enabled = true;
    }

    public void SetFood(FoodData food)
    {
        foodData = food;
        SetUpItem();
    }
}
