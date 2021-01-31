using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{

    public GameObject bulb;
    public GameObject lamp;
    public Material off;
    public Material on;
    bool isReadyForNew = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(lightgoesoff());
    }

    // Update is called once per frame
    void Update()
    {
        if (isReadyForNew == true)
        {
            StartCoroutine(lightgoesoff());
        }
    }
    IEnumerator lightgoesoff()
    {
        isReadyForNew = false;
        int random = Random.Range(1, 5);
        yield return new WaitForSeconds(random / 2);
        bulb.SetActive(false);
        lamp.GetComponent<Renderer>().material = off;
        StartCoroutine(lightgoeson());
    }

    IEnumerator lightgoeson()
    {
        int random = Random.Range(1, 5);
        yield return new WaitForSeconds(random / 2);
        bulb.SetActive(true);
        lamp.GetComponent<Renderer>().material = on;
        isReadyForNew = true;
    }
}
