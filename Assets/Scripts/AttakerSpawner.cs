using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class AttakerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    
    [SerializeField] Attaker[] attackerPrefabArray;
    [SerializeField] float rndtime;

    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        
        {
            
        SpawnAttaker();
        rndtime = UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay);
        yield return new WaitForSeconds(rndtime);
        
        }

    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttaker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);

        //Attaker newAttaker = Instantiate(attakerprefab, transform.position, transform.rotation) as Attaker;
        //newAttaker.transform.parent = transform;
    }

    private void Spawn(Attaker myAttacker)
    {
        Attaker newAttacker = Instantiate
            (myAttacker, transform.position, transform.rotation)
            as Attaker;
        newAttacker.transform.parent = transform;
    }


    void Update()
    {
        
    }
}
