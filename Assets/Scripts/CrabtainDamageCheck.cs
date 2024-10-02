using UnityEngine;

public class CrabtainDamageCheck : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent; 
    public Transform player;

    public float damageRange = 1.25f;
    public float damageCooldown = 2f;
    bool alreadyDamaged = false;

    public int unitHealth = 500;

    //public GameState sceneChange;

    private void Start()
    {
        player = GameObject.FindWithTag("Enemy").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //sceneChange = GameObject.Find("GameState").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DamageRangeCheck())
        {
            TakeDamage();
        }

        CheckHealth();
    }

    bool DamageRangeCheck()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer <= damageRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void TakeDamage()
    {
        if(!alreadyDamaged)
        {
            unitHealth -= 25;
            alreadyDamaged = true;
            Invoke(nameof(ResetDamage), damageCooldown);
        }
    }

    private void ResetDamage()
    {
        alreadyDamaged = false;
    }

    private void CheckHealth()
    {
        if(unitHealth <= 0)
        {
            Debug.Log("lose");
            //sceneChange.Lose();
        }
    }
}
