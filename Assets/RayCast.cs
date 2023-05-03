using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public GameObject DialogCassette;
    public GameObject DialogPancake;
    public GameObject DialogNewspaper;
    public GameObject Dialoghairclip;

    public GameObject DialogComic;
    public GameObject DialogSteto;
    public GameObject Dialogcollar;
    //public GameObject heart2;

    void Update()
    {
        string itemName = PlayerPrefs.GetString("item");


        if (itemName != null) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (PlayerPrefs.GetString("dragging") == "true" && Physics.Raycast(ray, out hit, 10000.0f)) {
                if (hit.collider.CompareTag("Arnold")) {
                    if (itemName == "cassette") {
                        DialogCassette.GetComponent<DialogTrigger>().TriggerDialog();
                    }
                    else if(itemName == "pancakes") {
                        DialogPancake.GetComponent<DialogTrigger>().TriggerDialog();
                    }
                    else if(itemName == "newspaper") {
                        DialogNewspaper.GetComponent<DialogTrigger>().TriggerDialog();
                    }
                    else if(itemName == "hairclip") {
                        Dialoghairclip.GetComponent<DialogTrigger>().TriggerDialog();
                        Destroy(hit.collider.gameObject);
                    }
                    else if(itemName == "heart") {
                        Destroy(hit.collider.gameObject);
                    }
                }

                //halskette, Comic, stethoscope

                if (hit.collider.CompareTag("Susan")) {
                    if (itemName == "comic") {
                        DialogComic.GetComponent<DialogTrigger>().TriggerDialog();
                        Destroy(hit.collider.gameObject);
                    }
                    else if (itemName == "collar") {
                        Dialogcollar.GetComponent<DialogTrigger>().TriggerDialog();
                    }
                    else if (itemName == "stethoscope") {
                        DialogSteto.GetComponent<DialogTrigger>().TriggerDialog();
                    }
                    else if (itemName == "heart") {
                        Destroy(hit.collider.gameObject);
                    }
                }

            }
        }
    }
}
