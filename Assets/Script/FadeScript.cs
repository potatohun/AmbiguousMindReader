using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField]
    GameObject fade;

    void delete()
    {
        fade.SetActive(false);
    }
}
