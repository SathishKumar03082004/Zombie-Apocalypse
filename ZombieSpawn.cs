using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    [Header("ZombieSpawn Var")]
    public GameObject zombiePrefab;
    public Transform ZombieSpawnpositions;
    public GameObject dangerZone1;
    private float repeatcycle=1f;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Player"){
            InvokeRepeating("EnemySpawner",1f,repeatcycle);
            StartCoroutine(dangerZoneTimer());
            Destroy(gameObject ,10f);
            gameObject.GetComponent<BoxCollider>().enabled=false;
        }
    }


    void EnemySpawner(){
        Instantiate(zombiePrefab,ZombieSpawnpositions.position,ZombieSpawnpositions.rotation);
    }

    IEnumerator dangerZoneTimer(){
        dangerZone1.SetActive(true);
        yield return new WaitForSeconds(5f);
        dangerZone1.SetActive(false);
    }
}
