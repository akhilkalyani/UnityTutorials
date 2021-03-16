using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LerpCoroutines : MonoBehaviour
{

    public Vector3 startScale, endScale;
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScaleFlipAnimation(startScale, endScale, gameObject, duration));
    }
    IEnumerator ScaleFlipAnimation(Vector3 initialScale, Vector3 finalScale, GameObject obj, float timeDuration)
    {
        float progress = 0;
        while (progress <= timeDuration)
        {
            obj.transform.localScale = Vector3.Lerp(initialScale, finalScale, progress); //scale lerping...
            progress += Time.deltaTime;
            //score.text = Mathf.FloorToInt(Mathf.Lerp(0,23,progress)).ToString(); //sore lerping...
            yield return null;
        }
        progress = 0;
        while (progress <= timeDuration)
        {
            obj.transform.localScale = Vector3.Lerp(finalScale, initialScale, progress); //scale lerping...
            progress += Time.deltaTime;
            //score.text = Mathf.FloorToInt(Mathf.Lerp(23, 0, progress)).ToString(); //sore lerping...
            yield return null;
        }
    }
}
