
using System;
using UnityEngine;
using System.Collections.Generic;

namespace Complete
{
    [Serializable]
    public class AICharacterManager
    {
        public Color m_PlayerColor;
        public Transform m_SpawnPoint;
        [HideInInspector]// The position and direction the tank will have when it spawns.
        public int m_PlayerNumber;            // This specifies which player this the manager for.
        [HideInInspector]
        public string m_ColoredPlayerText;    // A string that represents the player with their number colored to match their tank.
        [HideInInspector]
        public GameObject m_Instance;         // A reference to the instance of the Ai Character when it is created.
        [HideInInspector]
        public int m_Wins;                    // The number of wins this player has so far.
        [HideInInspector]
        public AIHealth aiHealth;


        private UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter m_Movement;                        // Reference to tank's movement script, used to disable and enable control.
        private Complete.PlayerShooting m_Shooting;                        // Reference to tank's shooting script, used to disable and enable control.
        private GameObject m_CanvasGameObject;                  // Used to disable the world space UI during the Starting and Ending phases of each round.
        private StateController m_StateController;              // Reference to the StateController for AI tanks


        public void SetupAI(List<Transform> wayPointList){
            m_StateController = m_Instance.GetComponent<StateController>();
            m_StateController.SetupAI(true, wayPointList);
            aiHealth = m_Instance.GetComponent<AIHealth>();

            // find gameobject in child where the shooting script is

            m_Shooting = m_Instance.GetComponent<Complete.PlayerShooting>();
            m_Shooting.m_PlayerNumber = m_PlayerNumber;
            //m_Instance.ac
            m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;
            m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>";        
        }

        // Used during the phases of the game where the player shouldn't be able to control their tank.
        public void DisableControl()
        {
            if (m_Movement != null)
                m_Movement.enabled = false;

            if (m_StateController != null)
                m_StateController.enabled = false;

            m_Shooting.enabled = false;

            m_CanvasGameObject.SetActive(false);
        }


        // Used during the phases of the game where the player should be able to control their tank.
        public void EnableControl()
        {
            if (m_Movement != null)
                m_Movement.enabled = true;

            if (m_StateController != null)
                m_StateController.enabled = true;

            m_Shooting.enabled = true;
            m_CanvasGameObject.SetActive(true);
        }


        // Used at the start of each round to put the tank into it's default state.
        public void Reset()
        {
            aiHealth.ResetAnimation();
            m_StateController.resetNavMeshAgent();
            m_Instance.transform.position = m_SpawnPoint.position;
            m_Instance.transform.rotation = m_SpawnPoint.rotation;
            m_Instance.GetComponent<Rigidbody>().isKinematic = false;

            m_Shooting.DisableEffects();


            /*
            m_Instance.SetActive(false);
            m_Instance.SetActive(true);
            */
        }


    }
}