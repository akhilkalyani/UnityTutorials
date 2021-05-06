using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIAnimation : MonoBehaviour
{
    public GameObject postAnswerObject;
    public GameObject currentButton;
    public GameObject SlideInObj, SlideOutObj;
    public GameObject streakParent;
    string correctAnswer="Option2";
    public bool isPlaying;
    public bool currentCorrect = false;
    public Image[] streakSongDiscList;
    public Image[] streakList;
    public int currentQuestionNumber = -1;
    public int streakcnt = -1;
    // Start is called before the first frame update
    private void Awake()
    {
        streakParent = transform.Find("StreakPanel").gameObject;
        streakList = new Image[4];
        streakSongDiscList = new Image[5];
        for (int i = 0; i < streakSongDiscList.Length; i++)
        {
            if(i<4)
            { 
                streakList[i] = streakParent.transform.Find("Streak" + i).GetComponent<Image>();
            }
            streakSongDiscList[i] = streakParent.transform.Find("SongDisk" + i).GetComponent<Image>();
        }
    }
    void Start()
    {
        Invoke("GetNextQuestion", 0.4f);
    }
    private void GetNextQuestion()
    {
        currentQuestionNumber++;
        SlideIn();
    }
    public void SlideIn()
    {
        SlideInObj.SetActive(true);
        //anim.Play("OptionSlideInAndOut");
       
    }
    public void ShowPostAnswer()
    {
        currentButton.GetComponent<OptionClick>().ResetToDefaultColor();
        postAnswerObject.SetActive(true);
        postAnswerObject.transform.Find("Text").GetComponent<Text>().
            text=currentButton.name==correctAnswer?"Correct Answer!":"Wrong Answer!";
        currentCorrect = currentButton.name == correctAnswer ? true : false;
        if (currentCorrect)
        {
            streakcnt++;
            ShowStreaks(streakcnt);
        }
        else
        {
            streakcnt = -1;
        }
        Invoke("OffPostAnswer",1f);
    }
    private void ShowStreaks(int streakcount)
    {
        if(currentQuestionNumber<=streakSongDiscList.Length-1)
        {
            streakSongDiscList[currentQuestionNumber].gameObject.SetActive(true);
            if(streakcount>0 && streakcnt<=streakList.Length)
            {
                streakList[currentQuestionNumber-1].gameObject.SetActive(true);
            }
        }
    }
    private void OffPostAnswer()
    {
        postAnswerObject.SetActive(false);
        SlideOutObj.SetActive(false);
        if(currentQuestionNumber<=streakList.Length-1)
        {
            GetNextQuestion();
        }
        //SlideIn();
    }
    public void ButtonClick(GameObject obj)
    {
        currentButton = obj;
        obj.GetComponent<OptionClick>().ChangeColor();
        Invoke("SlideOut", 0.5f);
    }
    public void SlideOut()
    {
         
        SlideInObj.SetActive(false);
         SlideOutObj.SetActive(true);
        StartCoroutine(ShowPostAnswerDelay());
    }
    IEnumerator ShowPostAnswerDelay()
    {
        while (SlideOutObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length >
        SlideOutObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime) { Debug.Log("&&&&&&&&&&&&&&&& Playing"); yield return null; }
        
        yield return new WaitForEndOfFrame();
        ShowPostAnswer();
    }
}
