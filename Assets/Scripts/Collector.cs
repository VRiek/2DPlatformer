using Unity.VisualScripting;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IItem item = collision.GetComponent<IItem>();

        if (collision.gameObject.CompareTag("Gem"))
        {
            item.Collect();
        }
    }
}
