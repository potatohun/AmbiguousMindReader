using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warnScript : MonoBehaviour
{
    [SerializeField]
    GameObject warn;
    public void WarnButtonClicked()
    {
        warn.SetActive(false);
    }
}
