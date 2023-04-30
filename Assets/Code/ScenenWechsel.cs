using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenenWechsel : MonoBehaviour
{
    public GameObject Scene1;
    public GameObject Scene2;
    public GameObject Scene3;
    public GameObject player;
    public Transform spawnPosition;

    public bool destination1;
    public bool destination2;
    public bool destination3;

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if (other.CompareTag("Player")){
            if (destination1) {
                Scene1.SetActive(true);
                Scene2.SetActive(false);
                Scene3.SetActive(false);
            }
            else if (destination2) {
                Scene1.SetActive(false);
                Scene2.SetActive(true);
                Scene3.SetActive(false);
            }
            else if (destination3) {
                Scene1.SetActive(false);
                Scene2.SetActive(false);
                Scene3.SetActive(true);
            }
            Destroy(player);
            Instantiate(player, spawnPosition);
        }
    }
}
