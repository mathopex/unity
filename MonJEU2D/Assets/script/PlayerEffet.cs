using UnityEngine;
using System.Collections;

public class PlayerEffet : MonoBehaviour
{
    public void AddSpeed(int speedBoost, float speedDuration)
    {
        MovePlayer.instance.moveSpeed += speedBoost;
        StartCoroutine(RemoveSpeedBoost(speedBoost,speedDuration));
    }

    private IEnumerator RemoveSpeedBoost(int speedBoost, float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);
        MovePlayer.instance.moveSpeed -= speedBoost;
    }
   
}
