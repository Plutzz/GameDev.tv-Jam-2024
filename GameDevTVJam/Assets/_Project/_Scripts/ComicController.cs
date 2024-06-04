using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ComicController : MonoBehaviour
{
    public ComicGroup[] comicGroups;
    public float duration = 2f;
    float timer = 0f;
    int currentPanel = 0;
    int currentGroup = 0;
    [SerializeField] SceneField nextScene;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var comicGroup in comicGroups)
        {
            for (int i = 0; i < comicGroup.panels.Length; i++)
            {
                comicGroup.panels[i].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
            }

            if (comicGroup.background != null)
            {
                Color bgColor = comicGroup.background.color;
                comicGroup.background.color = new Color(bgColor.r, bgColor.g, bgColor.b, 0);
            }
        }
      

        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Condition 1: " + (currentGroup == comicGroups.Length - 1));
        //Debug.Log("Condition 2: " + (currentPanel == comicGroups[currentGroup].panels.Length - 1));

        if (Input.anyKeyDown && currentGroup == comicGroups.Length - 1 && currentPanel == comicGroups[currentGroup].panels.Length - 1)
        {
            // Load next scene
            Debug.Log("Load Next Scene");
            //SceneManager.LoadScene(2);
            SceneSwapManager.Instance.SwapSceneFromDoorUse(nextScene, DoorTriggerInteraction.DoorToSpawnAt.One);
        }

        //Show next panel
        if (timer < duration)
        {
            Debug.Log("1");
            timer += Time.deltaTime;
        }
        else if(currentPanel < comicGroups[currentGroup].panels.Length - 1)
        {
            Debug.Log("2");
            timer = 0f;
            Mathf.Clamp(++currentPanel, 0, comicGroups[currentGroup].panels.Length - 1);
        }
        else if(Input.anyKeyDown && currentGroup < comicGroups.Length - 1)
        {
            Debug.Log("3");
            // Show next group
            currentGroup++;
            StartCoroutine(ShowNextGroupBackground());
            currentPanel = 0;
            timer = 0f;
        }
        else if(currentGroup <= comicGroups.Length - 1)
        {
            Debug.Log("4");
            comicGroups[currentGroup].nextButton.SetActive(true);
        }

        float t = timer / duration;
        comicGroups[currentGroup].panels[currentPanel].GetComponentInChildren<Image>().color = new Color(1, 1, 1, t);
    }
    IEnumerator ShowNextGroupBackground()
    {
        float a = 0f;

        while (a < 1f && comicGroups[currentGroup].background != null)
        {
            Color bgColor = comicGroups[currentGroup].background.color;
            comicGroups[currentGroup].background.color = new Color(bgColor.r, bgColor.g, bgColor.b, a);
            a += .1f;
            yield return null;
        }

        if(comicGroups[currentGroup].background != null)
        {
            Color bgColor = comicGroups[currentGroup].background.color;
            comicGroups[currentGroup].background.color = new Color(bgColor.r, bgColor.g, bgColor.b, 1);
        }
        yield return null;
    }
}

[Serializable]
public class ComicGroup
{
    public GameObject[] panels;
    public Image background;
    public GameObject nextButton;
}
