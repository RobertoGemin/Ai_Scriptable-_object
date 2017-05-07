using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Complete;
using NewComplete;

namespace Complete { 
public class StateController : MonoBehaviour {

    public State currentState;
    public EnemyStats enemyStats;
    public Transform eyes;
    public State remainState;


    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    // public Complete.TankShooting tankShooting;
   // public Complete.TankShooting tankShooting;
    // public Complete.TankShooting tankShooting;
    public Complete.PlayerShooting aiShooting;

    [HideInInspector]public AIHealth aiHealth;// check health
    public List<Transform> wayPointlist;
    [HideInInspector]public int nextWaypoint;
    [HideInInspector]public Transform chaseTarget;
    [HideInInspector]public float stateTimeElapsed;

    private bool aiActive;
        


	// Use this for initialization
	void Awake() {
        aiShooting = GetComponent<Complete.PlayerShooting>();
        navMeshAgent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        aiHealth = GetComponent<AIHealth>();
        }



        public void resetNavMeshAgent() {
            navMeshAgent.enabled = true;


        }

        public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager){
        wayPointlist = wayPointsFromTankManager;
        aiActive = aiActivationFromTankManager;//verwijderen
    }

	// Update is called once per frame
	void Update () {
        if (aiHealth.isDead){
                navMeshAgent.enabled = false;
                return;
        }
        else {
            currentState.UpdateState(this);
        }
    }

    void OnDrawGizmos()
    {
        if (currentState != null && eyes != null){
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);

        }
    }
    public void TransitionState(State nextState) {
        if (nextState != remainState) {
            currentState = nextState;
            OnExitState();
        }
        //tankShooting.Fire();
        //GetComponent<Completeold.TankShootingold>().Fire(); ;
    }

    public bool checkIfCountDownElapsed(float duration) {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    public void OnExitState(){
        stateTimeElapsed = 0;
    }

    }

}