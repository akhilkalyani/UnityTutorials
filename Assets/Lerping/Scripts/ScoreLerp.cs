using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreLerp : MonoBehaviour
{
    public float duration;
    public TMP_Text score;
    public Button lerpBTN;
    public int start, end;
    float prog = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LerpScore()
    {
        lerpBTN.interactable = false;
        StartCoroutine(Scorelerp(start, end, duration));
    }
    IEnumerator Scorelerp(int startScore, int endScore, float duration)
    {
        float progress = 0;
        yield return new WaitForSeconds(1);
        while (progress <= duration)
        {
            progress += Time.deltaTime;
            score.text = Mathf.FloorToInt(Mathf.Lerp(startScore, endScore, progress)).ToString();
            yield return null;
        }
        lerpBTN.interactable = true;
    }
    private void Update()
    {
        /*if(prog<=duration)
        {
            prog += Time.deltaTime;
            score.text = Mathf.FloorToInt(Mathf.Lerp(12, 120, prog)).ToString();
        }*/
    }
}
