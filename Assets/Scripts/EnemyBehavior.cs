using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent; 
    public Transform player;

    public float chaseRange = 1000f;
    public float attackRange = 2f;

    public float timeBetweenAttacks = 10f;
    public GameObject projectile;
    bool alreadyAttacked = false;
    


    private void Awake()
    {
        player = GameObject.FindWithTag("Selectable").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ChaseRangeCheck())
        {
            ChasePlayer();
        }

        if (AttackRangeCheck())
        {
            Attack();
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    bool AttackRangeCheck()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer <= attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool ChaseRangeCheck()
    {
        float distanceToPlayer2 = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer2 <= chaseRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Attack()
    {
        if (!alreadyAttacked)
        {
            agent.SetDestination(transform.position);

            transform.LookAt(player);
            Debug.Log("Enemy Attack being called");
            // Attack code
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
            rb.AddForce(transform.up * 2f, ForceMode.Impulse);

            
            Debug.Log("Enemy Attacked");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        Debug.Log("Enemy Attack CD");
    }
}
