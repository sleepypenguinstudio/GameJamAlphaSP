using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public List<CanvasGroup> huds;
    private int index;

    void Start()
    {
        huds[0].alpha = 1f;
        huds[1].alpha = 0.2f;
        index = 0;
        StartCoroutine(ShowNextHUD());
    }

    IEnumerator ShowNextHUD()
    {
        yield return new WaitForSeconds(2f);
        huds[index].alpha = 0f;
        index++;
        huds[index].alpha = 1f;
    }

}
