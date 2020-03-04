using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropChance : MonoBehaviour
{

    public GameObject []dropTable;
    public EnemyController enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        Debug.Log("DEAD");
    }
}
