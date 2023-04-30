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
    private bool canPickup = false; // bool zur Überprüfung, ob der Spieler in Reichweite ist

    private void Start()
    {
        pickupMessage.gameObject.SetActive(false); // Deaktiviert die Anzeige der Aufforderung zum Aufnehmen des Items zu Beginn des Spiels
    }

    private void Update()
    {
        // Überprüft, ob der Spieler in Reichweite des Items ist
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            // fügt das Item dem Inventar hinzu
            inventoryManager.AddItem(item);
            pickupMessage.gameObject.SetActive(false);
            // Zerstört das Spielobjekt, das das Item enthält
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Überprüft, ob der Kollider mit dem Spieler kollidiert ist
        if (other.CompareTag("Player"))
        {
            canPickup = true;
            // Aktiviert die Anzeige der Aufforderung zum Aufnehmen des Items
            pickupMessage.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Überprüft, ob der Kollider mit dem Spieler kollidiert ist
        if (other.CompareTag("Player"))
        {
            canPickup = false;
            // Deaktiviert die Anzeige der Aufforderung zum Aufnehmen des Items
            pickupMessage.gameObject.SetActive(false);
        }
    }
}
