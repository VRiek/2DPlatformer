using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 50f;
    public GameController gameController;


    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameController.isPaused)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Get mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Direction from us to mouse
        Vector3 shootDirection = (mousePosition - transform.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(shootDirection.x, shootDirection.y) * bulletSpeed;

        Destroy(bullet, 2f);
    }
}
