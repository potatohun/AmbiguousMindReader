using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFill : MonoBehaviour
{
    private Image image;
    public float delayFirst;
    public float delay;

    // (+) 코드추가
    [SerializeField]
    GameObject sign;
    [SerializeField]
    GameObject fade;
    private Animator animator;
    private Animator fadeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        animator = sign.GetComponent<Animator>();
        fadeAnimator = fade.GetComponent<Animator>();
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

    // (+) Animation 조건 추가
    void Update()
    {
        if(image.fillAmount > 0.9 && this.transform.name == "barcode")
        {
            animator.SetFloat("FillValue", 1.0f);
            fadeAnimator.SetFloat("FillValue", 1.0f);
        }
    }
}