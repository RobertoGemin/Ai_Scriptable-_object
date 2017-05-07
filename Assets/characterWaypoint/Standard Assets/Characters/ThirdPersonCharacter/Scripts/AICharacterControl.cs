using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
      public class AICharacterControl : MonoBehaviour{
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }          
        public ThirdPersonCharacter character{ get; private set; }

    
       

    private void Start(){
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            
            agent.updateRotation = false;
	        agent.updatePosition = true;         
           

        }

        

        private void OnTriggerEnter(Collider other)
        {
           
            /*
      
            if (other.name == "speed")
            {
                if (agent.speed == 1) {
                    agent.speed = (UnityEngine.Random.Range(0.1f, 1.0f));
                }
                else
                {
                    agent.speed = 1.0f;
                }


       

            }

            */
        }


        private void Update(){

          
            character.Move(agent.desiredVelocity, false, false);
            /*
            if (target != null){
                agent.SetDestination(target.position);
            }
          

            if (agent.remainingDistance > agent.stoppingDistance){
                character.Move(agent.desiredVelocity, false, false);
               

            }

            else {
                character.Move(Vector3.zero, false, false);
                checkNextTarget = true;

            }
            */
        }
    
      
    }
}
