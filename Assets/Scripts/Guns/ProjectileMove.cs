using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Place script on projectile type, allows for different damage/speeds/range, Works for at least machinegun
// Ideas/Code comes from https://www.youtube.com/watch?v=xenW67bXTgM and https://www.youtube.com/watch?v=DEtZUeVY9qk
public class ProjectileMove : MonoBehaviour
{

    public float Damage;
    public float Speed;
    public float Range;
    private Vector3 initialDistance;

    void Start()
    {
        initialDistance = transform.position;
        //ignores player and own bullets
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
        EnemyController target = co.transform.GetComponent<EnemyController>();
        if(target != null)
        {
            Debug.Log(target);
            target.TakeDamage(Damage);
        }
        Speed = 0;
        Destroy(gameObject);
    }
}
