using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;

    // Update is called once per frame
    private void Update()
    {
        transform.position = _player.position + new Vector3(0, 0, transform.position.z);    
    }
}
