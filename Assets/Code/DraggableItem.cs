using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// allows implementing mouse dragging
using UnityEngine.EventSystems;  

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
 {
    [Header("UI")]
    public Image image;

    [HideInInspector] public Item item;
    // save original parent of the object
    [HideInInspector] public Transform parentAfterDrag;

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
    }

    // Player starts the drag
    public void OnBeginDrag(PointerEventData eventData) 
    {
        Debug.Log("Begin Drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        // places object on the top of the view while dragging
        transform.SetAsLastSibling();
        // allows game to recognize inventory slot beneath item
        image.raycastTarget = false;           
    }

    // Player is dragging
    public void OnDrag(PointerEventData eventData) 
    {
        //Debug.Log("Dragging");

        if (Input.GetMouseButtonUp(0)) {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f)) {
                Debug.Log("Pew");

                if (hit.collider.CompareTag("Arnold")) {
                    if (item.name == "cassette") {
                        Debug.Log("Es funktioniert");
                    }

                }
                else if (hit.collider.tag == "Susan") {


                }

                    
            }
        }

        // Item follows mouse position while dragging
        transform.position = Input.mousePosition; 
    }

    // Player stops drag
    public void OnEndDrag(PointerEventData eventData) 
    {
        Debug.Log("End Drag");
        transform.SetParent(parentAfterDrag);
        // interaction with item possible again after dragging
        image.raycastTarget = true;             
    }
}
