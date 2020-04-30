using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public float spawnRate;
    public float spawnMinDistance;
    public float spawnMaxDistance;
    //default mob, summoner
    public GameObject[] spawnArray;
    public int[] spawnChance = { 100,20 };
    private bool topOfGround = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, spawnMaxDistance);
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, spawnMinDistance);
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            //picks a random point on a CIRCLE thats in between minDistance and maxDistance
            float distance = Random.Range(spawnMinDistance, spawnMaxDistance);
            float angle = Random.Range(-Mathf.PI, Mathf.PI);

            Vector3 spawnPosition = transform.position;
            spawnPosition += new Vector3(Mathf.Cos(angle), 1, Mathf.Sin(angle)) * distance;
            spawnPosition.y = 1;

            //check to see if the area under enemy spawn is ground, if ground then allow spawning
            RaycastHit hit;
            if (Physics.Raycast(spawnPosition, Vector3.down*2, out hit))
            {
                if(hit.transform.name == "Ground")
                {
                    topOfGround = true;
                } else
                {
                    Debug.Log("Touched " + hit.transform.name);
                    topOfGround = false;
                }
            }
            else
            {
                Debug.Log("Touched nothing");
                topOfGround = false;
            }
            //choose a random mob from weighted array
            if (topOfGround)
            {
                var range = 0;
                for (int i = 0; i < spawnChance.Length; i++)
                    range += spawnChance[i];

                var rand = Random.Range(0, range);
                var top = 0;

                for (int i = 0; i < spawnChance.Length; i++)
                {
                    top += spawnChance[i];
                    if (rand < top)
                    {
                        Debug.Log("Spawning");
                        Instantiate(spawnArray[i], spawnPosition, transform.rotation);
                        break;
                    }
                }
                yield return new WaitForSeconds(spawnRate);
            }
            else
            {
                yield return new WaitForSeconds(.5f);
            }

        }
        
    }

}
