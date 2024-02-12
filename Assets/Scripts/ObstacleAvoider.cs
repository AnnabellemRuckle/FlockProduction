using UnityEngine;

public class ObstacleAvoider : MonoBehaviour
{
    public float avoidanceRadius = 2f; 
    public float avoidanceForce = 1f; 

    private void Update()
    {

        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

       
        Vector3 avoidanceVector = Vector3.zero;
        foreach (GameObject obstacle in obstacles)
        {
            Vector3 direction = obstacle.transform.position - transform.position;
            float distance = direction.magnitude;

            if (distance < avoidanceRadius)
            {
                
                Vector3 scaledDirection = direction.normalized * (1 - (distance / avoidanceRadius));
                avoidanceVector -= scaledDirection;
            }
        }

        
        transform.position += avoidanceVector * avoidanceForce * Time.deltaTime;
    }
}
