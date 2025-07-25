using Unity.VisualScripting;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IItem item = collision.GetComponent<IItem>();
        /*if (item != null)
        {
            item.Collect();
            //Debug.Log("ITEM COLLISION");
        }*/

        if (collision.gameObject.CompareTag("Gem"))
        {
            item.Collect();
            Debug.Log("Piste");
        }
    }
}
