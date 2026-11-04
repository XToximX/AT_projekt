using UnityEngine;
using UnityEngine.Rendering;

public class ItemDragHandler : MonoBehaviour
{
    private GameObject draggedItem = null;
    private Vector2 ogItemPos;

    private void OnEnable()
    {
        draggedItem = null;
        InputManager.I.OnLClickStart += CheckForItem;
        InputManager.I.OnLClickEnd += DropDraggedItem;
    }

    private void OnDisable()
    {
        draggedItem = null;
        InputManager.I.OnLClickStart -= CheckForItem;
        InputManager.I.OnLClickEnd -= DropDraggedItem;
    }

    // Update is called once per frame
    void Update()
    {
        if(draggedItem != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(InputManager.I.MousePos);
            draggedItem.transform.position = mousePos;
        }
    }

    private void CheckForItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(InputManager.I.MousePos);

        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider == null)
            return;

        if (hit.collider.TryGetComponent<IDraggable>(out IDraggable draggable))
        {
            if(draggable.IsDraggable)
            {
                draggedItem = hit.collider.gameObject;
                draggable.OnDragStart();

                ogItemPos = draggedItem.transform.position;
            }
        }

    }

    private void DropDraggedItem()
    {
        if (draggedItem == null)
        {
            ClearDraggedItem();
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(InputManager.I.MousePos);

        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider == null)
        {
            ClearDraggedItem();
            return;
        }

        if (hit.collider.TryGetComponent<CookingStation>(out CookingStation station))
        {
            if(station.TryPlaceItem(draggedItem))
            {
                draggedItem.GetComponent<IDraggable>().OnDragEnd();
                draggedItem = null;
                return;
            }
        }
    }

    private void ClearDraggedItem()
    {
        if (draggedItem == null)
            return;

        draggedItem.transform.position = ogItemPos;
        draggedItem.GetComponent<IDraggable>().OnDragEnd();
        draggedItem = null;
    }

    public GameObject GetDraggedItem()
    {
        return draggedItem;
    }
}
