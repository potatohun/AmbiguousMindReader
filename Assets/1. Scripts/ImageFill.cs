using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFill : MonoBehaviour
{
    private Image image;
    public float delayFirst;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
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
            Debug.Log(tmp);

            yield return new WaitForSeconds(delay);
        }
    }
}