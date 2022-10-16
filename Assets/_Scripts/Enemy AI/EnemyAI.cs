using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private GameObject Bullet;
    [SerializeField] private float SpawnTimeRangeStart;
    [SerializeField] private float SpawnTimeeRangeEnd;
    [SerializeField] private float _shootingTimer;
    //[SerializeField] private float sightRange;
    [SerializeField] private float attackRange;
    [SerializeField] private Vector2 enemySpeedRange;
    private GameObject Projectiles;
    private NavMeshAgent Agent;
    private GameObject Player;
    private bool alreadyAttacked;
    private bool playerInSightRange;
    private bool playerInAttackRange;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        Projectiles = GameObject.Find("Projectiles");
        Agent = GetComponent<NavMeshAgent>();
        Agent.speed = Random.Range(enemySpeedRange.x, enemySpeedRange.y);
        _shootingTimer = Random.Range(SpawnTimeRangeStart, SpawnTimeeRangeEnd);


    }

    // Update is called once per frame
    void Update()
    {
        Agent.transform.LookAt(Player.transform);
        Agent.SetDestination(Player.transform.position);
        playerInAttackRange = Vector3.Distance(Agent.transform.position, Player.transform.position) < attackRange;
        //Check for sight and attack range
        //Check for sight and attack range
        /*        playerInSightRange = Vector3.Distance(Agent.transform.position, Player.transform.position) < sightRange;
                playerInAttackRange = Vector3.Distance(Agent.transform.position, Player.transform.position) < attackRange;

                Debug.Log(playerInSightRange.ToString());

                if (playerInSightRange)
                {
                    Agent.SetDestination(Player.transform.position);
                }*/

        Debug.Log(playerInAttackRange.ToString());
        if (playerInAttackRange)
        {
            if (_shootingTimer <= 0)
            {
                Shot();
            }
            else
            {
                _shootingTimer -= Time.deltaTime;
            }
        }
        if (Vector3.Distance(Agent.transform.position, Player.transform.position) < 0.5f) // change to if enemy hitpoints is lower than 0
        {
            Destroy(Agent.gameObject);
        }

    }
    public void Shot()
    {
        Agent.SetDestination(transform.position);
        if (alreadyAttacked)
            return;
        StartCoroutine(GamePauser());

    }
    public IEnumerator GamePauser()
    {
        alreadyAttacked = true;
        yield return new WaitForSeconds(Random.Range(0.3f, 0.6f));
        Debug.Log("Fire Gun");
        Instantiate(Bullet, transform.GetChild(0).GetChild(0).position, Quaternion.identity, Projectiles.transform);
        yield return new WaitForSeconds(Random.Range(0.6f, 1f));
        alreadyAttacked = false;
        _shootingTimer = Random.Range(SpawnTimeRangeStart, SpawnTimeeRangeEnd); // change it so it will be dynamic from inspector
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
/*        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);*/
    }

}
