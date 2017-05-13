using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouse : MonoBehaviour
{

    // Use this for initialization
    Camera camera;
    public float pushspeed;
   public IEnumerator coroutine;

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

            if (hit.transform.name == "makeAhuman")
            {
                //hit.rigidbody.AddForce(transform.forward * 5);
                hit.transform.gameObject.GetComponent<CapsuleCollider>().enabled = false;

                Animator die = hit.transform.gameObject.GetComponent<Animator>();
                Raggdoll ragdoll = hit.transform.gameObject.GetComponent<Raggdoll>();
                if (die != null && ragdoll != null)
                {
                    print("die.enabled = false; ");
                    ragdoll.enabledParts();
                    //  coroutine = WaitAndPrint(2.0f, die);
                    //   StartCoroutine(coroutine);
                    StartCoroutine(waitFrame(die,ragdoll));
                    //waitFrame(die)

                    //die.enabled = false;

                }
            }

        }
        else
        {
            print("I'm looking at nothing!");
        }

    }


    IEnumerator waitFrame(Animator die, Raggdoll ragdoll) {
        yield return new WaitForSeconds(1f);
        print("3 sec !");
        die.enabled = false;
        ragdoll.pelvis.GetComponent<Rigidbody>().AddForce(transform.forward * 5);
        yield return null;
    }

    private IEnumerator WaitAndPrint(float waitTime,Animator die)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            die.enabled = false;
            print("WaitAndPrint " + Time.time);
        }
    }
}
