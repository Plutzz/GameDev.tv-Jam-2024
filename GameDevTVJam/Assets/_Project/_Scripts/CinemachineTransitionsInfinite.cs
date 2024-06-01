using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineTransitionsInfinite : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private string stateName;
    [SerializeField] private float cameraWidth;
    [SerializeField] private CinemachineVirtualCamera camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player Enter Camera Transition");
        if (collision.gameObject.CompareTag("Player"))
        {
            if(camera.Follow == null)
                camera.Follow = collision.transform;

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
        CheckAndSortCameras();
    }


    public void CheckAndSortCameras()
    {
        int index = 0;
        foreach (Transform child in transform.parent)
        {
            if (child == transform)
            {
                break;
            }
            index++;
        }
        Transform _firstChild = transform.parent.GetChild(0);
        Transform _lastChild = transform.parent.GetChild(2);
        switch (index)
        {
            case 0:
                // Camera in index 2 needs to become camera in index 0
                _lastChild.position = new Vector3(_firstChild.position.x - cameraWidth, _lastChild.position.y, _lastChild.position.z);
                _lastChild.SetAsFirstSibling();
                
                break;
            case 1:
                // Camera is in the right spot
                break;
            case 2:
                // Camera in index 0 needs to become camera in index 2

                _firstChild.position = new Vector3(_lastChild.position.x + cameraWidth, _firstChild.position.y, _firstChild.position.z);
                _firstChild.SetAsLastSibling();
                break;
        }
    }
}
