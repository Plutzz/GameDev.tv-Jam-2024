using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TendrilIndicator : MonoBehaviour
{
    [SerializeField] private float indicatorTime;
    [SerializeField] private float tendrilTime;
    [SerializeField] private GameObject tendril;
    private float indicatorTimer;

    private void Start()
    {
        indicatorTimer = indicatorTime;
    }

    private void Update()
    {
        indicatorTimer -= Time.deltaTime;

        if(indicatorTimer < 0)
        {
            GameObject _tendril = Instantiate(tendril, transform.position + Vector3.up * 2.033f + Vector3.right * .25f, Quaternion.identity);
            Destroy(_tendril, tendrilTime);
            Destroy(gameObject);
        }
    }


}
