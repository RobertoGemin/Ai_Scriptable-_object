using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouse : MonoBehaviour {

    // Use this for initialization
    Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            print("I'm looking at " + hit.transform.name);

            //hit.transform.gameObject.rigidbody.AddForce(transform.forward * thrust);
            hit.rigidbody.AddForce(transform.forward * 5);

            Animator die = hit.transform.gameObject.GetComponentInParent<Animator>();
            if (die != null)
            {
                die.enabled = false;
            }
        }
        else
        {
            print("I'm looking at nothing!");
        }

    }
}
