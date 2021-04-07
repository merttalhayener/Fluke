using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;

    bool colliderBusy = false;
    bool dead = false;
    public Slider slider;
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !colliderBusy)
        {
            colliderBusy = true;
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            colliderBusy = false;
        }
    }
    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }

        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
    }

    void AmIDead()
    {
        if (health <= 0)
        {
            dead = true;
        }
    }


}
