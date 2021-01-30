using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    bool doPrology = true;
    bool goDark = true;
    public GameObject goBlackPanel;
    float goDarkDuration = 2;
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Prology()
    {
        Debug.Log("Prology: " + doPrology);
        if (doPrology)
        {

            Color blackColor = new Color(0, 0, 0, 1);
            Color invisibleColor = new Color(0, 0, 0, 0);

            yield return new WaitForSeconds(5);
            if (goDark)
            {
                goBlackPanel.GetComponent<Image>().color = UnityEngine.Color.Lerp(invisibleColor, blackColor, t);
                if (t <= 1)
                {
                    t += Time.deltaTime / goDarkDuration;
                }
            }
            else
            {
                yield return new WaitForSeconds(5);
                if (t >= 0)
                {
                    t -= Time.deltaTime / goDarkDuration;
                }
            }

            //doPrology = false;

        }
    }
}
