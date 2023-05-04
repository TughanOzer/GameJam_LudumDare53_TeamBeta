using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class ScenenWechsel : MonoBehaviour
{
    public NavMeshSurface NavMeshSurface;

    public GameObject SForest1;
    public GameObject SForest2;
    public GameObject SGraveYard;
    public GameObject SVillage;
    public GameObject SVillage2;
    public GameObject SChappel;

    public GameObject player;
    private GameObject[] oldPlayer;
    public Transform spawnPosition;

    public bool DestinationForest1;
    public bool DestinationForest2;
    public bool DestionationGrave;
    public bool DestinationVillage;
    public bool DestinationVillage2;
    public bool DestinationChapel;



    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            if (DestinationForest1) {
                TurnAllScenesOff();
                SForest1.SetActive(true);
            }

            else if (DestinationForest2) {
                TurnAllScenesOff();
                SForest2.SetActive(true);
            }
            else if (DestionationGrave) {
                TurnAllScenesOff();
                SGraveYard.SetActive(true);
            }
            else if (DestinationVillage) {
                TurnAllScenesOff();
                SVillage.SetActive(true);
            }
            else if (DestinationVillage2) {
                TurnAllScenesOff();
                SVillage2.SetActive(true);
            }
            else if (DestinationChapel) {
                TurnAllScenesOff();
                SChappel.SetActive(true);
                
            }
            oldPlayer = GameObject.FindGameObjectsWithTag("Player");
            //oldPlayer[0].transform.position = spawnPosition.transform.position;
            oldPlayer[0].GetComponent<NavMeshAgent>().Warp(spawnPosition.transform.position);
        }
    }


    void TurnAllScenesOff() {
        SForest1.SetActive(false);
        SForest2.SetActive(false);
        SGraveYard.SetActive(false);
        SVillage.SetActive(false);
        SVillage2.SetActive(false);
        SChappel.SetActive(false);
    }
}
