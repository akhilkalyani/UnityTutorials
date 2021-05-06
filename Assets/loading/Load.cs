using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MusicApp
{
    public class Load : MonoBehaviour
    {
        [SerializeField]Image loadImage;
        [SerializeField] Text loadText;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(LoadScreen());
        }
        IEnumerator LoadScreen()
        {
            yield return new WaitForSeconds(0.1f);
            float t = 0; 
            while(t<1)
            {
                t += Time.deltaTime;
                yield return new WaitForSeconds(0.1f);
                loadText.text = Mathf.FloorToInt(Mathf.Lerp(0,100f,t)) + "";
                loadImage.fillAmount = t;
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}