using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Complete;
[CreateAssetMenu(menuName ="PluggableAI/State")]
public class State : ScriptableObject {

   
    public Action[] actions;
    public Color sceneGizmoColor = Color.gray;
    public Transition[] transitions;
    public void UpdateState(StateController controller){
        DoActions(controller);
        CheckTransitions(controller);
    }
    private void DoActions(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++){
            actions[i].Act(controller);
        }

    }
    private void CheckTransitions(StateController controller){
        for (int i = 0; i < transitions.Length; i++){
            bool decisionSucceeded = transitions[i].decision.Decide(controller);
            if (decisionSucceeded){
                controller.TransitionState(transitions[i].trueState);
            }
            else {
                controller.TransitionState(transitions[i].falseState);

            }
        }
    }

}

