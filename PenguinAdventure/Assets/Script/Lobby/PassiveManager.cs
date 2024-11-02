using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PassiceInfoScript;
public class PassiveManager : MonoBehaviour
{
    public static PassiveManager Instance { get; private set; }

    public PassiveInfo SelectedPassive { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSelectedPassive(PassiveInfo passive)
    {
        SelectedPassive = passive;
        Debug.Log("���õ� �нú�: " + SelectedPassive.title);
    }
}

