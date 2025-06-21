using UnityEngine;
using UnityEngine.AI;

public class CoinBot : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform[] destinations;
    private int currentDestination = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPoint();
    }
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextPoint();
        }
    }
    void MoveToNextPoint()
    {
        currentDestination = Random.Range(0, destinations.Length);
        agent.SetDestination(destinations[currentDestination].position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
