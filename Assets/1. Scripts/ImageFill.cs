using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFill : MonoBehaviour
{
    private Image image;
    public float delayFirst;
    public float delay;

    // (+) �ڵ��߰�
    [SerializeField]
    GameObject sign;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        animator = sign.GetComponent<Animator>();
        StartCoroutine(fillLeftToRight(delayFirst, delay));
    }

    IEnumerator fillLeftToRight(float delayFirst, float delay)
    {
        yield return new WaitForSeconds(delayFirst);
        float tmp = 0;

        while (tmp < 1)
        {
            image.fillAmount = tmp;
            tmp += 3 * Time.deltaTime;

            yield return new WaitForSeconds(delay);
        }
        tmp = 1;
    }

    // (+) Animation ���� �߰�
    void Update()
    {
        if(image.fillAmount > 0.9 && this.transform.name == "barcode")
        {
            animator.SetFloat("FillValue", 1.0f);
        }
    }
}