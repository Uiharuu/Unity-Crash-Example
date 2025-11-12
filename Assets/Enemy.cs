using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] float redDuration = 1;
    [SerializeField] float timer;
    [SerializeField] float currentTime;
    [SerializeField] float lastDamagedTime;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        currentTime = Time.time;
        
        if (currentTime > lastDamagedTime + redDuration)
        {
            sr.color = Color.white;
        }
    }
    public void TakeDamage()
    {
        if (sr.color == Color.white)
        {
            Debug.Log(gameObject.name + "get attacked!");
            sr.color = Color.red;

            lastDamagedTime = Time.time;
        }
    }

}
