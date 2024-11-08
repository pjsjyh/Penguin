using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInfoManager;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PoolManager poolmanager;
    public Player player;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != this)
                Destroy(this.gameObject);
        }
      

    }
}
