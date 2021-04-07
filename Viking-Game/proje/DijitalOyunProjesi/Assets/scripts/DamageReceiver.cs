using UnityEngine;

public class DamageReceiver : MonoBehaviour, IEntity
{
    //This script will keep track of player HP
    public float playerHP = 100;
    public CharacterController playerController;
   // public WeaponManager weaponManager;

    public void ApplyDamage(float points)
    {
        playerHP -= points;

        if(playerHP <= 0)
        {
            //Player is dead
            playerController.Move=false; 
            playerHP = 0;
        }
    }
}