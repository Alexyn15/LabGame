using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LookGap : MonoBehaviour
{
    public GameObject obstacleObject;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            obstacleObject.transform.localScale = new Vector3(-obstacleObject.transform.localScale.x,  obstacleObject.transform.localScale.y, obstacleObject.transform.localScale.z);
        }
    }
}
