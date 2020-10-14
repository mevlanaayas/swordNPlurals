using System;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    public LayerMask clickableLayer;

    public Texture2D normalCursor;
    public Texture2D clickableCursor;
    public Texture2D doorwayCursor;
    public Texture2D combatCursor;

    public EventVector3 eventVector3;

    private void Update()
    {
        RaycastHit raycastHit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 50, clickableLayer))
        {
            var door = false;
            var item = false;
            if (raycastHit.collider.gameObject.CompareTag("doorway"))
            {
                Cursor.SetCursor(doorwayCursor, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }
            else if (raycastHit.collider.gameObject.CompareTag("item"))
            {
                Cursor.SetCursor(combatCursor, new Vector2(16, 16), CursorMode.Auto);
                item = true;
            }
            else
            {
                Cursor.SetCursor(clickableCursor, new Vector2(16, 16), CursorMode.Auto);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (door)
                {
                    eventVector3.Invoke(raycastHit.collider.transform.position);
                }
                else if (item)
                {
                    eventVector3.Invoke(raycastHit.collider.transform.position);
                }
                else
                {
                    eventVector3.Invoke(raycastHit.point);
                }
            }
        }
        else
        {
            Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}

[Serializable]
public class EventVector3 : UnityEvent<Vector3>
{
}