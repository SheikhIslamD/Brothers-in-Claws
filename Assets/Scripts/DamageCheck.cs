using UnityEngine;
using UnityEngine.AI;

public class DamageCheck : MonoBehaviour
{
    public NavMeshAgent agent; 
    public Transform player;

    public float damageRange = 1.25f;
    public float damageCooldown = 2f;
    private bool alreadyDamaged = false;

    public int unitHealth = 100;

    private void Awake()
    {
        // Ensure that each unit has its own reference to the player and agent
        player = GameObject.FindWithTag("Enemy")?.transform; // Find player with tag "Enemy"
        agent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            Debug.LogError("Player not found! Ensure the player object has the correct tag.");
        }

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component missing on this object!");
        }
    }

    void Update()
    {
        // Ensure player exists and is within damage range
        if (player != null && DamageRangeCheck())
        {
            TakeDamage();
        }

        // Check health each frame to destroy if necessary
        CheckHealth();
    }

    // Checks if unit is within damage range
    bool DamageRangeCheck()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer <= damageRange;
    }

    // Handles taking damage
    private void TakeDamage()
    {
        if (!alreadyDamaged)
        {
            unitHealth -= 25; // Reduce health
            alreadyDamaged = true;
            Invoke(nameof(ResetDamage), damageCooldown); // Cooldown for next damage
            Debug.Log("Took damage! Remaining Health: " + unitHealth);
        }
    }

    // Resets the damage cooldown
    private void ResetDamage()
    {
        alreadyDamaged = false;
    }

    // Destroys the unit if health is 0 or below
    private void CheckHealth()
    {
        if (unitHealth <= 0)
        {
            Debug.Log("Unit destroyed!");
            // Ensure only this specific instance is destroyed
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // This will only affect the specific unit being destroyed
        if (agent != null)
        {
            agent.enabled = false; // Disable NavMeshAgent before destruction
        }
    }
}
