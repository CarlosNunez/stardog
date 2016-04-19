using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 6;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.x > max.x + GetWidth())
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Meteor")
        {
            collider.gameObject.SendMessage("Delete");
            Destroy(gameObject);
        }
    }

    public float GetWidth()
    {
        return GetComponent<Renderer>().bounds.size.x;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
