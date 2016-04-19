using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.2f;

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
