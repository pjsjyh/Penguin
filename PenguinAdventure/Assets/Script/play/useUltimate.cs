using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerInfoManager;
public class useUltimate : MonoBehaviour
{
    public int selectUltimate = 0;
    public Sprite[] Ultimate;
    public GameObject ultimateDelayObject;
    public GameObject penguin;
    public RuntimeAnimatorController muzukPenguin;
    private void Start()
    {
        GameObject ultimateObject = GameObject.Find("ultimateBTN");
        Image buttonImage = ultimateObject.GetComponent<Image>();
        if (buttonImage != null && Ultimate.Length > selectUltimate)
        {
            if (PlayerManager.Instance.SelectedPassive.imgSource == null|| PlayerManager.Instance.SelectedPassive.imgSource == "")
            {
                Sprite newSprite = Resources.Load<Sprite>("Images/NotOpen");
                buttonImage.sprite = newSprite;
            }
            else
            {
                Texture2D texture = Resources.Load<Texture2D>(PlayerManager.Instance.SelectedPassive.imgSource);

                Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                // 텍스처 할당
                //buttonImage.sprite = Ultimate[selectUltimate];
                buttonImage.sprite = newSprite;
            }
            
        }
        else
        {
            Debug.LogWarning("buttonImage 컴포넌트가 없거나 인덱스 범위를 벗어났습니다.");
        }
    }
    // Start is called before the first frame update
    public void clickUltimate()
    {
        if (ultimateDelayObject != null)
        {
            Debug.Log("click");
            // 오브젝트가 존재할 때 수행할 작업
            ultimateDelayObject.SetActive(true);
           if(PlayerManager.Instance.SelectedPassive.title=="무적 효과")
            {
                Debug.Log("무적발동");
                RuntimeAnimatorController origin = penguin.GetComponent<Animator>().runtimeAnimatorController;
                penguin.GetComponent<Rigidbody2D>().isKinematic = false;
                penguin.GetComponent<CapsuleCollider2D>().enabled = false;

                penguin.GetComponent<Animator>().runtimeAnimatorController = muzukPenguin;
                StartCoroutine(MuzukrDelay(PlayerManager.Instance.SelectedPassive.nowLevel*1.5f, origin));
            }
            else if (PlayerManager.Instance.SelectedPassive.title == "스피드 향상")
            {
                penguin.GetComponent<Player>().speed = (PlayerManager.Instance.SelectedPassive.nowLevel * 1.5f)/6;
                StartCoroutine(AfterDelay(PlayerManager.Instance.SelectedPassive.nowLevel * 3f));
            }
            else if(PlayerManager.Instance.SelectedPassive.title == "체력 증가")
            {

            }
            else if(PlayerManager.Instance.SelectedPassive.title == "북극곰아 도와줘")
            {

            }
            Debug.Log("Found the ultimateDelay GameObject!");
        }
        else
        {
            // 오브젝트가 존재하지 않을 때
            Debug.LogWarning("GameObject with the name 'ultimateDelay' was not found.");
        }
    }
    private IEnumerator AfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        penguin.GetComponent<Player>().speed = PlayerManager.Instance.myPlayer._moveSpeed / 50;
    }
    private IEnumerator MuzukrDelay(float delay, RuntimeAnimatorController origin)
    {
        yield return new WaitForSeconds(delay);
        penguin.GetComponent<Animator>().runtimeAnimatorController = origin;
        penguin.GetComponent<Rigidbody2D>().isKinematic = true;
        penguin.GetComponent<CapsuleCollider2D>().enabled = true;

    }
}
