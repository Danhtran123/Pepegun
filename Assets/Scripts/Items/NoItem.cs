using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoItem : MonoBehaviour
{

    GameObject item;

    // Start is called before the first frame update
    private void Awake()
    {
        item = GameObject.FindWithTag("NoItem");
    }
    void Start()
    {
        Debug.Log("Spawning no items");
        Destroy(item);
    }

}
