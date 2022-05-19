using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pathfinding : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform player;

    public Transform[] waypoints;
    // public GameObject[] waypointObjects;

    private int randomWaypoint;

    private RaycastHit hit;

    void Awake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        randomWaypoint = Random.Range(0, waypoints.Length);
    }

    void Update()
    {
        // agent.SetDestination(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        // agent.SetDestination(player.position);
        // foreach (var point in GameObject.FindGameObjectsWithTag("Waypoint"))
        // {
        //     waypoints.Add(point.GetComponent<Transform>());
        //     Debug.Log(point.gameObject.GetComponent<Transform>());
        // }
        // waypointObjects = GameObject.FindGameObjectsWithTag("Waypoint");


        // Debug.Log(waypoints);


        agent.SetDestination(waypoints[randomWaypoint].position);

         if(Physics.Raycast(transform.position, transform.forward, out hit, 100f)){
             if(hit.collider.CompareTag("Player")){
                agent.SetDestination(player.position);
                agent.speed = 20;     
             }
         }
        if(Vector3.Distance(transform.position, player.position) <= 15){
            agent.SetDestination(player.position);
            agent.speed = 20;
        }else if(Vector3.Distance(transform.position, waypoints[randomWaypoint].position) < 3 ){
            randomWaypoint = Random.Range(0, waypoints.Length);
            agent.speed = 5;
        }
        
        // Debug.Log(agent.destination.ToString());
        

    }
}
