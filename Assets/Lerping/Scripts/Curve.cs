using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour
{
    public AnimationCurve flipCurve;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Pop());
    }
    IEnumerator Pop()
    {
        yield return new WaitForSeconds(2);
        float t = 0;
        while(t<=1)
        {
            t += Time.deltaTime;
            float v = flipCurve.Evaluate(t);
            transform.localScale = new Vector3(v, v, v);
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
