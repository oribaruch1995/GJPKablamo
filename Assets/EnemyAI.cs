using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // create spawn limit 
    // create random number  for spawn time
    private GameObject Destination;
    public NavMeshAgent Agent;
    public float SpawnTime;
    public float SpawnTimeRangeStart;
    public float SpawnTimeeRangeEnd;
    [SerializeField] private float _shootingTimer;
    // Start is called before the first frame update
    void Start()
    {
        Destination = GameObject.FindGameObjectsWithTag("Player")[0];
        _shootingTimer = Random.Range(SpawnTimeRangeStart,SpawnTimeeRangeEnd);
        Agent.SetDestination(Destination.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_shootingTimer <= 0)
        {
            Shot();
        }
        else
        {
            Debug.Log("enemy move");
            Agent.isStopped = false;
            _shootingTimer -= Time.deltaTime;
        }
        if(Vector3.Distance(Agent.transform.position, Destination.transform.position) < 0.5f) // change to if enemy hitpoints is lower than 0
        {
            Destroy(Agent.gameObject);
        }
           
    }
    public void Shot()
    {
        Debug.Log("pause movement enemy");
        Agent.isStopped = true;
        // Fire gun to target direction (Destination)
        Debug.Log("Fire Gun");
        StartCoroutine(GamePauser());

    }
    public IEnumerator GamePauser()
    {
        yield return new WaitForSeconds(Random.Range(0.7f,1.3f));
        _shootingTimer = Random.Range(SpawnTimeRangeStart, SpawnTimeeRangeEnd); // change it so it will be dynamic from inspector
    }
}
