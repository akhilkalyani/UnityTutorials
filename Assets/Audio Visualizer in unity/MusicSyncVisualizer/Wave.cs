using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{
    public float multiplyer;
    public Color color;
    public GameObject[] leftlist;
    public GameObject[] rightlist;

    private void Start()
    {
        for (int i = 0; i < leftlist.Length; i++)
        {
            leftlist[i].GetComponent<Image>().color = color;
            rightlist[i].GetComponent<Image>().color = color;
        }
    }

    void Update()
    {
        if (AudioSpectrum.spectrumValues.Length <= 0)
            return;
        for (int i = 0; i < leftlist.Length;i++)
        {
            float d = AudioSpectrum.spectrumValues[i];
            float YScale = Mathf.Clamp(d * multiplyer, 0, 1);
            leftlist[i].transform.localScale = new Vector3(leftlist[i].transform.localScale.x, YScale, 0);
            rightlist[i].transform.localScale = new Vector3(leftlist[i].transform.localScale.x, YScale, 0);
        }
    }
}
