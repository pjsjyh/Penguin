using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct RankInfo
{
    public string name;
    public int score;

    public RankInfo(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
public class Ranking : MonoBehaviour
{
   
    public GameObject rankingPre;
    public RankInfo[] ranks = new RankInfo[100];
    private int rankCount = 0; // 현재 저장된 랭킹의 개수

    // 점수를 추가하고 정렬하는 메서드
    public void AddScore(string name, int score)
    {
        if (rankCount < ranks.Length)
        {
            ranks[rankCount] = new RankInfo(name, score);
            rankCount++;
        }
        else
        {
            // 배열이 가득 찬 경우, 최소 점수보다 큰 경우에만 교체
            if (score > ranks[rankCount - 1].score)
            {
                ranks[rankCount - 1] = new RankInfo(name, score);
            }
        }

        // 배열을 점수 내림차순으로 정렬
        System.Array.Sort(ranks, (a, b) => b.score.CompareTo(a.score));
    }

    // 배열을 디버그용으로 출력하는 메서드
    public void PrintRanks()
    {
        for (int i = 0; i < rankCount; i++)
        {
            Debug.Log($"Rank {i + 1}: {ranks[i].name} - {ranks[i].score}");
        }
    }
}

