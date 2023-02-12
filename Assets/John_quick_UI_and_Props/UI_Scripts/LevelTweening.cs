//using DG.Tweening;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LevelTweening : MonoBehaviour
//{

//    public float tweenTime = 1f;
//    public GameObject levelWord;

//    private void Start()
//    {
//        StartCoroutine(ShowLevelWord());
//    }

//    private IEnumerator ShowLevelWord()
//    {
//        // Smoothly transition in
//        levelWord.GetComponent<CanvasGroup>().DOFade(1f, tweenTime).SetEase(Ease.Linear);
//        yield return new WaitForSeconds(tweenTime);

//        // Wait for 3 seconds
//        yield return new WaitForSeconds(3f);

//        // Smoothly transition out
//        levelWord.GetComponent<CanvasGroup>().DOFade(0f, tweenTime).SetEase(Ease.Linear);
//    }


//}
