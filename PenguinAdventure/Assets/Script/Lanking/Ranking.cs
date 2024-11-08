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
    private int rankCount = 0; // ���� ����� ��ŷ�� ����

    // ������ �߰��ϰ� �����ϴ� �޼���
    public void AddScore(string name, int score)
    {
        if (rankCount < ranks.Length)
        {
            ranks[rankCount] = new RankInfo(name, score);
            rankCount++;
        }
        else
        {
            // �迭�� ���� �� ���, �ּ� �������� ū ��쿡�� ��ü
            if (score > ranks[rankCount - 1].score)
            {
                ranks[rankCount - 1] = new RankInfo(name, score);
            }
        }

        // �迭�� ���� ������������ ����
        System.Array.Sort(ranks, (a, b) => b.score.CompareTo(a.score));
    }

    // �迭�� ����׿����� ����ϴ� �޼���
    public void PrintRanks()
    {
        for (int i = 0; i < rankCount; i++)
        {
            Debug.Log($"Rank {i + 1}: {ranks[i].name} - {ranks[i].score}");
        }
    }
}

