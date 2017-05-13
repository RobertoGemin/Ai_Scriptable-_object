using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raggdoll : MonoBehaviour {
    //gameObject

    public GameObject pelvis;
    public GameObject spine3;
    public GameObject upperarm_l;
    public GameObject lowerarm_l;
    public GameObject upperarm_r;
    public GameObject lowerarm_r;
    public GameObject head;
    public GameObject thigh_l;
    public GameObject calf_l;
    public GameObject thigh_r;
    public GameObject calf_r;

   

    public bool partsAreInEnabled;



    public void enabledParts()
    {
        partsAreInEnabled = true;
        pelvis.GetComponent<BoxCollider>().enabled = true;
        spine3.GetComponent<BoxCollider>().enabled = true;
        upperarm_l.GetComponent<CapsuleCollider>().enabled = true;
        lowerarm_l.GetComponent<CapsuleCollider>().enabled = true;
        upperarm_r.GetComponent<CapsuleCollider>().enabled = true;
        lowerarm_r.GetComponent<CapsuleCollider>().enabled = true;
        head.GetComponent<SphereCollider>().enabled = true;
        thigh_l.GetComponent<CapsuleCollider>().enabled = true;
        calf_l.GetComponent<CapsuleCollider>().enabled = true;
        thigh_r.GetComponent<CapsuleCollider>().enabled = true;
        calf_r.GetComponent<CapsuleCollider>().enabled = true;
       //die.enabled = false;

      



    }

    void disableParts() {

        pelvis.GetComponent<BoxCollider>().enabled = false;
        spine3.GetComponent<BoxCollider>().enabled = false;
        upperarm_l.GetComponent<CapsuleCollider>().enabled = false;
        lowerarm_l.GetComponent<CapsuleCollider>().enabled = false;
        upperarm_r.GetComponent<CapsuleCollider>().enabled = false;
        lowerarm_r.GetComponent<CapsuleCollider>().enabled = false;
        head.GetComponent<SphereCollider>().enabled = false;
        thigh_l.GetComponent<CapsuleCollider>().enabled = false;
        calf_l.GetComponent<CapsuleCollider>().enabled = false;
        thigh_r.GetComponent<CapsuleCollider>().enabled = false;
        calf_r.GetComponent<CapsuleCollider>().enabled = false;
        partsAreInEnabled = false;
    }

    // Use this for initialization
    void Awake () {
        disableParts();


    }
	
	// Update is called once per frame
	void Update () {
		

	}



}
