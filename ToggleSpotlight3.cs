using UnityEngine;
using System.Collections;

public class ToggleSpotlight3 : MonoBehaviour
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
            yield return new WaitForSeconds(4f);

            spotlight.enabled = true;
            yield return new WaitForSeconds(1f);

            spotlight.enabled = false;
            yield return new WaitForSeconds(8f);

            spotlight.enabled = true;
            yield return new WaitForSeconds(7f);

            spotlight.enabled = false;
            yield return new WaitForSeconds(2f);
        }
    }
}
