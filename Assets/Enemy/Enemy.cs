using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float hpPlayer;
    public int damage;
    // patruyar
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Atacar
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //Estados
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // HP
    public Text txtHp;
    public Text txtWin;
    private void Awake()
    {
        player = GameObject.Find("Jugador").transform;
        agent = GetComponent<NavMeshAgent>();
        damage = 15;
        hpPlayer = GameObject.Find("Jugador").GetComponent<PlayerController>().hpPlayer;
        UpdateHp();
    }

    void Start()
    {
        //txtWin.text = "aerr";
        Debug.Log("Iniciando void start: ");
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 4f, ForceMode.Impulse);

            alreadyAttacked = true;

            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


    public void TakeDamageEnemy(int damage)
    {
        hpPlayer -= damage;
        UpdateHp();
        if (hpPlayer <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    void UpdateHp()
    {
        txtHp.text = "HP: " + hpPlayer.ToString();
        if (hpPlayer <= 0)
        {
            //
        }
    }
}
