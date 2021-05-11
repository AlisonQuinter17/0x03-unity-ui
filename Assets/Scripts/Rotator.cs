using UnityEngine.SceneManagement;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate (45f * Time.deltaTime, 0, 0);
    }
}
