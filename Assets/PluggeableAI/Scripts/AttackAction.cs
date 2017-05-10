using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Complete;
using NewComplete;
using Complete;

[CreateAssetMenu(menuName ="PluggableAI/Actions/Attack")]
public class AttackAction : Action {
    public override void Act(StateController controller){
        Attack(controller);

    }
    private void Attack(StateController controller)
    {
        RaycastHit hit;
        Ray shootRay = new Ray();
        shootRay.origin = controller.eyes.position;
        shootRay.direction = controller.eyes.forward;


        //controller.navMeshAgent.isStopped = false;
        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.attackRange, Color.red);

        if (!controller.aiHealth.isDead)
        {
            // if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            if (Physics.SphereCast(controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.forward, out hit, controller.enemyStats.attackRange))
            {         //&& hit.collider.CompareTag("Player")//         {
                if (controller.checkIfCountDownElapsed(controller.enemyStats.attackRate))
                {
                    // controller.navMeshAgent.isStopped = true;
                    controller.aiShooting.canShoot = true;
                }
            }
        
        }
    }
}