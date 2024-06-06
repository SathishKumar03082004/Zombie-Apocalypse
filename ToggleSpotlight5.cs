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
            //101101
            spotlight.enabled = true;
            yield return new WaitForSeconds(2f);

            spotlight.enabled = false;
            yield return new WaitForSeconds(2f);

            spotlight.enabled = true;
            yield return new WaitForSeconds(2f);

            spotlight.enabled = true;
            yield return new WaitForSeconds(2f);

            spotlight.enabled = false;
            yield return new WaitForSeconds(2f);

            spotlight.enabled = true;
            yield return new WaitForSeconds(2f);
        }
    }
}
