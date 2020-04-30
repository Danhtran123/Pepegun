using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    Transform target;
    NavMeshAgent agent;
    GameObject player;
    GameManager man;

    public float health;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        man = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        agent.SetDestination(target.position);
        FacePlayer();

    }

    void FacePlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        int scoreAdd = 0;
        if(transform.name == "Summoner(Clone)")
        {
            scoreAdd = 100;
        } else if(transform.name =="Basic Enemy(Clone)")
        {
            scoreAdd = 50;
        } else if(transform.name == "SummonedMonster(Clone)")
        {
            scoreAdd = 10;
        }
        Debug.Log(transform.name);
        Debug.Log(scoreAdd);
        man.AddScore(scoreAdd);
    }
}
