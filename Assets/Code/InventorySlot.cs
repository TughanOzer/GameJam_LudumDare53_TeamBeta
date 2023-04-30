using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // checks if an item is already in inventory slot
        if (transform.childCount == 0) 
        {
            //checks if an item is dropped
            GameObject dropped = eventData.pointerDrag; 
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            // sets inventory slot as new parent
            draggableItem.parentAfterDrag = transform; 
        }
    }
}
    