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

    public bool goLadder = false;
    public bool goStairs = false;

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
        if (canvasScript.canWalk)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    //Move agent
                    agent.SetDestination(hit.point);


                    if (hit.transform.name == "LaddersToAttic")
                        goLadder = true;
                    else
                        goLadder = false;

                    if (hit.transform.name == "StairsToBasement")
                        goStairs = true;
                    else
                        goStairs = false;

                }
            }
        }

        if ((transform.position - agent.destination).magnitude - agent.stoppingDistance > 0.1f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }


}
