using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent; 
    public Transform player;

    [HideInInspector]public float chaseRange = 1000f;
    public float rangedAttackRange = 2f;
    public float meleeAttackRange = 1.25f;

    public float timeBetweenRangedAttacks = 10f;
    public float timeBetweenMeleeAttacks = 2f;
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

        /*if (AttackRangeCheckRanged())
        {
            RangedAttack();
        }*/

        if (AttackRangeCheckMelee())
        {
            agent.SetDestination(transform.position);
            MeleeAttack();
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    /*bool AttackRangeCheckRanged()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer <= rangedAttackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/

    bool AttackRangeCheckMelee()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer <= meleeAttackRange)
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

    /*private void RangedAttack()
    {
        if (!alreadyAttacked)
        {
            agent.SetDestination(transform.position);

            //transform.LookAt(player); 
            Debug.Log("Enemy Attack being called");
            // Attack code
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
            rb.AddForce(transform.up * 2f, ForceMode.Impulse);

            
            Debug.Log("Enemy Attacked");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenRangedAttacks);
        }
    }*/

    private void MeleeAttack()
    {
        agent.SetDestination(transform.position);
        /*
            FUNCTION TO REDUCE HEALTH OF UNIT
        */
        //Invoke(nameof(ResetAttack), timeBetweenMeleeAttacks);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        Debug.Log("Enemy Attack CD");
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Selectable")
        {
            MeleeAttack();
            Invoke(nameof(ResetAttack),timeBetweenMeleeAttacks);
        }
    }*/
}
