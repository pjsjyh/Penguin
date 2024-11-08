using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RankingPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RankingOn()
    {
        RankingPanel.SetActive(true);
    }
    public void RankingOff()
    {
        RankingPanel.SetActive(false);
    }
}
