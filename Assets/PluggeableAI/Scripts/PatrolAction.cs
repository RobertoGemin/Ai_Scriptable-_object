using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Complete;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action {

    // Use this for initialization
    public override void Act(StateController controller)
    {
        Patrol(controller);
    }

    // Update is called once per frame
    private void Patrol (StateController controller) {
        
     controller.navMeshAgent.destination = controller.wayPointlist[controller.nextWaypoint].position;
        controller.navMeshAgent.isStopped = false;
       

        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending) {
            controller.nextWaypoint = (controller.nextWaypoint + 1) % controller.wayPointlist.Count;
        }
	}
}
