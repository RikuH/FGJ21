using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    Rigidbody rigidbody;

    Animator anim;
    Transform myTransform;
    Vector3 lastPos;
    bool IsMoving;

    public CanvasScript canvasScript;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        myTransform = transform;
        lastPos = myTransform.position;
        IsMoving = false;


    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(canvasScript.Prology());

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                //Move agent
                agent.SetDestination(hit.point);
            }
        }

        if (myTransform.position != lastPos)
        {
            Debug.Log("Kävelee");
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        lastPos = myTransform.position;
    }


}
