using UnityEngine;
using System.Collections;

public class ToggleSpotlight4 : MonoBehaviour
{
    private Light spotlight;

    void Start()
    {
        spotlight = GetComponent<Light>();
        StartCoroutine(ToggleVisibility());
    }

    IEnumerator ToggleVisibility()
    {
        while (true)
        {
            //45
            spotlight.enabled = true;
            yield return new WaitForSeconds(4f);

            spotlight.enabled = false;
            yield return new WaitForSeconds(1f);

            spotlight.enabled = true;
            yield return new WaitForSeconds(3f);

            spotlight.enabled = false;
            yield return new WaitForSeconds(5f);

            spotlight.enabled = true;
            yield return new WaitForSeconds(8f);

            spotlight.enabled = false;
            yield return new WaitForSeconds(1f);
        }
    }
}
