using UnityEngine;

public interface IDraggable
{
    bool IsDraggable { get; }

    void OnDragStart();
    void OnDragEnd();
}
