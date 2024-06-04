using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private Transform spawnpoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(boss, spawnpoint.position, Quaternion.identity);
        AudioManager.Instance.SetMusicArea(AudioManager.MusicArea.Boss);
        Destroy(gameObject);
    }
}
