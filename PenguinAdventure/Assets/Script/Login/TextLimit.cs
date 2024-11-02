using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro;

public class TextLimit : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textMeshPro; // TextMeshPro �ؽ�Ʈ ������Ʈ
    public int maxCharacters = 13; // �ִ� ���� ��
    public TMP_InputField inputfield;
    public TextMeshProUGUI warningMessage;

    public Button button;
    public Sprite image1;                  // �ؽ�Ʈ�� ���� �� �̹���
    public Sprite image2;
    private Image buttonImage;

    private void Start()
    {

        buttonImage = button.GetComponent<Image>();

        warningMessage.gameObject.SetActive(false);

        inputfield.characterLimit = maxCharacters;
        inputfield.onValueChanged.AddListener(OnTextChanged);
    }
    private void OnTextChanged(string text)
    {
        if (text.Length == 0)
        {
            buttonImage.raycastTarget = false;
            buttonImage.sprite = image1;
        }
        else
        {
            buttonImage.raycastTarget = true;
            buttonImage.sprite = image2;

        }
        // ���� ���� �ִ� ���� ���� �ʰ��� �� ��� �޽��� ǥ��
        if (text.Length >= maxCharacters)
        {
            // �ؽ�Ʈ�� �߶󳻾� �ִ� ���� ���� ����
            inputfield.text = text.Substring(0, maxCharacters);
            // ��� �޽��� Ȱ��ȭ
            warningMessage.text = $"{maxCharacters} ���� �̳��� �Է��� �ּ���!";
            warningMessage.gameObject.SetActive(true);
        }
        else
        {
            // ��� �޽��� ��Ȱ��ȭ
            warningMessage.gameObject.SetActive(false);
        }
    }
}