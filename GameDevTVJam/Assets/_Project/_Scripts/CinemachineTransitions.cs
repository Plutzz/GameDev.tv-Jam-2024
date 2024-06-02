using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineTransitions : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private string stateName;
    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player Enter Camera Transition");
        if(collision.gameObject.CompareTag("Player"))
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName(stateName))
                SwitchCamera(stateName);
        }
    }

    private void SwitchCamera(string stateName)
    {
        StartCoroutine(FreezeGame(0.5f));
        anim.Play(stateName);
    }

    private IEnumerator FreezeGame(float seconds)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(seconds);
        Time.timeScale = 1;
    }


}
