using UnityEngine;
using System.Collections;

public class ToggleSpotlight2 : MonoBehaviour
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
            yield return new WaitForSeconds(1f);

            spotlight.enabled = false;
            yield return new WaitForSeconds(3f);

            spotlight.enabled = true;
            yield return new WaitForSeconds(6f);

            spotlight.enabled = false;
            yield return new WaitForSeconds(3f);

            spotlight.enabled = true;
            yield return new WaitForSeconds(3f);

            spotlight.enabled = false;
            yield return new WaitForSeconds(1f);
        }
    }
}
