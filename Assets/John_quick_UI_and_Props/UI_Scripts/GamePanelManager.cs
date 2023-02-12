
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GamePanelManager : MonoBehaviour
{

    public CanvasGroup panel1;
    public CanvasGroup panel2;

    void Start()
    {
        panel2.alpha = 0;
        StartCoroutine(ShowPanels());
    }

    IEnumerator ShowPanels()
    {
        
        panel1.alpha = 1;
        yield return new WaitForSeconds(3f);
        panel1.alpha = 0;
        panel2.alpha = 1;
    }


}
