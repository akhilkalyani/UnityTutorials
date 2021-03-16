using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreLerp : MonoBehaviour
{
    public float duration;
    public TMP_Text score;
    float prog = 0;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Scorelerp(0, 120, duration));
    }
    IEnumerator Scorelerp(int startScore, int endScore, float duration)
    {
        float progress = 0;
        while (progress <= duration)
        {
            progress += Time.deltaTime;
            score.text = Mathf.FloorToInt(Mathf.Lerp(startScore, endScore, progress)).ToString();
            yield return null;
        }
    }
    private void Update()
    {
        if(prog<=duration)
        {
            prog += Time.deltaTime;
            score.text = Mathf.FloorToInt(Mathf.Lerp(12, 120, prog)).ToString();
        }
    }
}
