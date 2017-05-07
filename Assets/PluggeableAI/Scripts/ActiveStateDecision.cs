using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Complete;
[CreateAssetMenu(menuName ="PluggableAI/Decisions/ActiveState")]
public class ActiveStateDecision : Decision{
    public override bool Decide(StateController controller)
    {
        bool chaseTargetIsActive = controller.aiHealth.isDead; ///controller.chaseTarget.gameObject.activeSelf;
        return chaseTargetIsActive;
   }

    // Use this for initialization

}
