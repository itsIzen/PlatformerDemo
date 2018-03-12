using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MainCharacter : MonoBehaviour
{
    public Camera cameraObject;
    public float cameraSmooth = 5f;

    private Rigidbody2D _rb;
    private Vector3 cameraVelocity = Vector3.zero;

    private float moveOffset = 5f;
    [SerializeField]
    [Range(3f,20f)]
    private float jumpOffset = 5f;

    // Use this for initialization
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (cameraObject == null)
        {
            cameraObject = Camera.main;
        }
    }

    // Update is called once per frame
    private void Update()
    {
         float horizontalMove = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontalMove*moveOffset, _rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y/10f);
            _rb.AddForce(Vector2.up*jumpOffset, ForceMode2D.Impulse);
        }

        // Smooth camera following
        Vector3 point = cameraObject.WorldToViewportPoint(transform.position);
        Vector3 delta = transform.position - cameraObject.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        Vector3 destination = cameraObject.transform.position + delta;
        cameraObject.transform.position = Vector3.SmoothDamp(cameraObject.transform.position, destination, ref cameraVelocity, cameraSmooth * Time.deltaTime);
    }
}