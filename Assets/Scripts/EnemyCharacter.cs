using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyCharacter : MonoBehaviour
{
    public GameObject playerCharacter;

    private Rigidbody2D _rb;

    private float attractionRadius = 2f;
    private float attractionOffset = 10f;
    private float maxAttraction = 20f;

    // Use this for initialization
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerCharacter)
        {
            // Apply attraction to PlayerCharacter
            Vector2 direction = playerCharacter.transform.position - transform.position;

            if (direction.magnitude <= attractionRadius)
            {
                _rb.AddForce(direction.normalized * attractionOffset, ForceMode2D.Force);
                if (_rb.velocity.magnitude > maxAttraction)
                {
                    _rb.velocity = _rb.velocity.normalized * maxAttraction;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GlobalsInit.gameOverMessage.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}