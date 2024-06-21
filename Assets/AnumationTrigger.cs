using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnumationTrigger : MonoBehaviour
{
    public string animationName;
    private void OnEnable()
    {
        GetComponent<Animator>().Play(animationName);
    }
}
