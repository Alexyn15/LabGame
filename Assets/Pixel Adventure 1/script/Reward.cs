using UnityEngine;
using UnityEngine.UI;
   
   public class Reward : MonoBehaviour
{
    public int cointValue = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.instance.AddScore(cointValue);
            Destroy(gameObject);
        }
    }
}

