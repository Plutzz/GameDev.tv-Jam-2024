using FMODUnity;
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
        GameManager.Instance.currentMusicEventEmitter.Stop();
        Destroy(GameManager.Instance.musicEventEmitter.GetComponent<StudioEventEmitter>());
        GameManager.Instance.currentMusicEventEmitter = AudioManager.Instance.InitializeEventEmitter(FMODEvents.NetworkSFXName.BossTheme, GameManager.Instance.musicEventEmitter);
        GameManager.Instance.currentMusicEventEmitter.Play();
        Destroy(gameObject);
    }
}
