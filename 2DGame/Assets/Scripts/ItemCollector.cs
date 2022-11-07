using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int _cherries = 0;

    [SerializeField] private Text _cherriesCount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            _cherries++;
            _cherriesCount.text = _cherries.ToString();
            Destroy(collision.gameObject);
        }
    }
}
