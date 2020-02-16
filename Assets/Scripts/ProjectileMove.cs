using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

    public float Damage;
    public float Speed;
    public float Range;
    private Vector3 initialDistance;

    void Start()
    {
        initialDistance = transform.position;
        Physics.IgnoreLayerCollision(9, 9);
        Physics.IgnoreLayerCollision(9, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Speed != 0)
        {
            transform.position += transform.forward * (Speed * Time.deltaTime);
        }

        float currentDistance = Vector3.Distance(transform.position, initialDistance);
        if (currentDistance > Range)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision co)
    {
        EnemyTarget target = co.transform.GetComponent<EnemyTarget>();
        if(target != null)
        {
            Debug.Log("This hit!");
            target.TakeDamage(Damage);
        }
        Speed = 0;
        Destroy(gameObject);
    }
}
