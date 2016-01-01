using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShadowDetection : MonoBehaviour
{
    public Image shadowDetector;
    float lightMeter;
    float lightRange;
    
	// Use this for initialization
	void Start()
    {
        lightRange = 0;
        lightMeter = 0;
        shadowDetector.color = new Color(lightMeter, lightMeter, lightMeter, 1);
    }
	
	// Update is called once per frame
	void Update()
    {
	    
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Light")
        {
            StartCoroutine("ShadowCoroutine", coll);
        }
    }

    IEnumerator ShadowCoroutine(Collider coll)
    {
        yield return new WaitForSeconds(0.01f);
        if(coll.GetComponent<Light>().type == LightType.Directional)
        {
            lightMeter = coll.GetComponent<Light>().intensity;
            Vector3 direction = coll.transform.position - transform.position;
            if (Physics.Raycast(transform.position, direction, distanceToLight(coll)))
            {
                lightMeter = 0;
            }
            shadowDetector.color = new Color(lightMeter, lightMeter, lightMeter, 1);
            Debug.Log("Hello! Your light is at:" + lightMeter);
            StartCoroutine("ShadowCoroutine", coll);
        }

        else if (distanceToLight(coll) < coll.GetComponent<Light>().range)
        {
            //Shadow Calculations
            lightRange = distanceToLight(coll);
            lightMeter = 1 - (lightRange / coll.GetComponent<Light>().range);
            Vector3 direction = coll.transform.position - transform.position;
            if (Physics.Raycast(transform.position, direction, distanceToLight(coll)))
            {
                lightMeter = 0;
            }
            shadowDetector.color = new Color(lightMeter, lightMeter, lightMeter, 1);
            //Restart Coroutine if you are still in light.
            //Debug.Log("Hello! Your light is at:" + lightMeter);
            StartCoroutine("ShadowCoroutine", coll);
        }
    }

    float distanceToLight(Collider coll)
    {
        return Mathf.Sqrt(Mathf.Pow((gameObject.transform.position.x - coll.transform.position.x), 2) + Mathf.Pow((gameObject.transform.position.y - coll.transform.position.y), 2) + Mathf.Pow((gameObject.transform.position.z - coll.transform.position.z), 2));
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.GetComponent<Collider>().name == "Head")
        {
            //shadowDetector.color.r -= 10;
        }
        if (coll.GetComponent<Collider>().name == "Head")
        {
            //shadowDetector.color.r -= 10;
        }
        if (coll.GetComponent<Collider>().name == "Head")
        {
            //shadowDetector.color.r -= 10;
        }
    }
}
