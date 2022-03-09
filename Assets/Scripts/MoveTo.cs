using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform target;

    NavMeshAgent agent;

    

    // Start is called before the first frame update
    void Start()
    {
        // assign the variable 'agent' to the component on this gameObject.
        agent = this.GetComponent<NavMeshAgent>();
        // tell the navMeshAgent component to move to the target's position.
        agent.destination = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        //edit later to remove navmeshagent when health reaches 0
        

        if(Vector3.Distance(transform.position, target.position) > 1) {
            // tell the navMeshAgent component to move to the target's position.
            agent.destination = target.position;
        }
        else {
            // otherwise, stay where you are.
            agent.destination = this.transform.position;
        }
    }
}
