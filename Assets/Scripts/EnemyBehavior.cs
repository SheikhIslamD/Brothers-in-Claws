using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent; 
    public Transform player;

    public float chaseRange = 1000f;
    public float attackRange = 4f;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
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

    }
}
