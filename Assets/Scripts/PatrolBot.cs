using UnityEngine;
using UnityEngine.AI;

public class PatrolBot : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    private int currentpoint = 0;
    private NavMeshAgent agent;
    [SerializeField] private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        agent.SetDestination(patrolPoints[currentpoint].position);
    }

    // Update is called once per frame
    void Update()
    {
        switch (player.currentMaterial)
        {
            case 0:
                Patrol(); 
                break;
            case 1:
                FleeFromPlayer(); 
                break;
            case 2:
                ChasePlayer(); 
                break;
        }
    }
    private void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentpoint = (currentpoint + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentpoint].position);
        }
    }
    private void FleeFromPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 5f)
        {
            Vector3 directionToPlayer = transform.position - player.transform.position;
            Vector3 fleeTarget = transform.position + directionToPlayer.normalized * 5f;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(fleeTarget, out hit, 5f, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }
        }
        else
        {
            agent.ResetPath();
        }
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }
}
