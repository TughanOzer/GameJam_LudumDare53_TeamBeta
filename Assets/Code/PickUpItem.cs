using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupItem : MonoBehaviour
{
    public float pickupRadius = 2f; // Bereich, in dem sich der Spieler befinden muss, um das Item aufzunehmen
    public Item item;
    public TMP_Text pickupMessage; // Text zur Anzeige der Aufforderung zum Aufnehmen des Items
    public InventoryManager inventoryManager;
    private bool canPickup = false; // bool zur �berpr�fung, ob der Spieler in Reichweite ist

    private void Start()
    {
        pickupMessage.gameObject.SetActive(false); // Deaktiviert die Anzeige der Aufforderung zum Aufnehmen des Items zu Beginn des Spiels
    }

    private void Update()
    {
        // �berpr�ft, ob der Spieler in Reichweite des Items ist
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            // f�gt das Item dem Inventar hinzu
            inventoryManager.AddItem(item);
            pickupMessage.gameObject.SetActive(false);
            // Zerst�rt das Spielobjekt, das das Item enth�lt
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �berpr�ft, ob der Kollider mit dem Spieler kollidiert ist
        if (other.CompareTag("Player"))
        {
            canPickup = true;
            // Aktiviert die Anzeige der Aufforderung zum Aufnehmen des Items
            pickupMessage.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �berpr�ft, ob der Kollider mit dem Spieler kollidiert ist
        if (other.CompareTag("Player"))
        {
            canPickup = false;
            // Deaktiviert die Anzeige der Aufforderung zum Aufnehmen des Items
            pickupMessage.gameObject.SetActive(false);
        }
    }
}
