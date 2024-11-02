using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PassiceInfoScript;
public class PassiveBtnGroup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;          // ��ư�� �߰��� Panel
    public GameObject buttonPrefab;   // ��ư ������

    public List<PassiveInfo> passiveList = new List<PassiveInfo>();

    public void GenerateButtons()
    {
        LoadSettings();

        // ���� ��ư�� ������ ��� ����
        for (int i = panel.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(panel.transform.GetChild(i).gameObject);
        }

        // passiveList���� �� �ɷ� �����͸� ��ư�� ����
        foreach (var ability in passiveList)
        {
            GameObject newButton = Instantiate(buttonPrefab, panel.transform);
            Passive p = newButton.GetComponent<Passive>();

            if (p != null)
            {
                p.SetData(ability);  // SetData ȣ�� �� PassiveInfo Ÿ���� ����
            }
            else
            {
                Debug.LogError("Passive ������Ʈ�� ã�� �� �����ϴ�.");
            }
        }
    }

    void LoadSettings()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("PassiveInfo");

        if (jsonFile != null)
        {
            string wrappedArray = WrapArray(jsonFile.text);
            Debug.Log("JSON �ؽ�Ʈ (������ ����): " + wrappedArray);

            PassiveInfo[] abilitiesArray = JsonUtility.FromJson<PassiveArrayWrapper>(wrappedArray).passives;

            if (abilitiesArray != null)
            {
                Debug.Log("�Ľ� ����: �� " + abilitiesArray.Length + "���� �׸��� �ε��߽��ϴ�.");
                passiveList.AddRange(abilitiesArray);
            }
            else
            {
                Debug.LogError("JSON �Ľ� ���� - JSON �迭�� ��ȯ�� �� �����ϴ�.");
            }
        }
        else
        {
            Debug.LogError("JSON ������ ã�� �� �����ϴ�.");
        }
    }

    private string WrapArray(string jsonArray)
    {
        return "{ \"passives\": " + jsonArray + "}";
    }

    [System.Serializable]
    private class PassiveArrayWrapper
    {
        public PassiveInfo[] passives;
    }

    private void OnPassiveButtonClick(PassiveInfo clickedPassive)
    {
        PassiveManager.Instance.SetSelectedPassive(clickedPassive);
    }
}