using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropChance : MonoBehaviour
{

    public GameObject[] dropTable;
    //No item, Jump Item, Speed Item, Health Item, Invinciblility Item, Teleport Item
    public int[] items = { 100,30,30,60,10,10};
    bool isQuitting;

    // Start is called before the first frame update
    void Start()
    {
        if (items.Length < dropTable.Length)
        {
            Debug.Log("There is not enough item array percentages to match up to dropTable's");
        }
        if (items.Length > dropTable.Length)
        {
            Debug.Log("There are too many percentages to match up to dropTable's");
        }
        if(items.Length == dropTable.Length)
        {
            Debug.Log("There are enough percentages to match up to dropTable's");
            Debug.Log(items.Length + "and" + dropTable.Length);
        }
    }
    
    //prevents item from spawning after ending game, saves memory.
    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if (!isQuitting && !PauseMenu.isPaused)
        {
            var range = 0;
            for (int i = 0; i < items.Length; i++)
                range += items[i];

            var rand = Random.Range(0, range);
            var top = 0;

            for (int i = 0; i < items.Length; i++)
            {
                top += items[i];
                if (rand < top)
                {
                    GameObject itemDrop = Instantiate(dropTable[i], transform.position,transform.rotation) as GameObject;
                    break;
                }
            }

            Debug.Log("ENEMY DEAD");
        }
    }

}
