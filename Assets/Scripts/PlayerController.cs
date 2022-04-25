using UnityEngine;
using System;
using Zenject;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    

    public GameColor playerColor;

    Settings _settings;
    


    [Inject]
    public void Construct(Settings settings)
    {
        _settings = settings;
    }

    private bool isDead = false;

    [SerializeField]
    private Animator playerAnimator;

    Vector3 startingPosition, endingPosition;

    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _settings.playerForwardSpeed = 3f;
        _settings.playerSideMovementSpeed = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        ResetMovement();
        ReloadScene();
    }
    void Movement()
    {
        if (!isDead)
        {
            playerAnimator.SetBool("Run", true);
            Position += Vector3.forward * _settings.playerForwardSpeed * Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            startingPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            endingPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            Vector3 difference = endingPosition - startingPosition;

            Position += new Vector3(difference.x, 0, 0) * _settings.playerSideMovementSpeed * Time.smoothDeltaTime;
            startingPosition = endingPosition;
        }
    }
    void ResetMovement()
    {
        if (Input.GetMouseButtonUp(0))
        {
            startingPosition = endingPosition = Vector3.zero;
        }
    }
    void ReloadScene()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NPC>() != null)
        {
            CollisionDetection(other);
        }
    }
    void CollisionDetection(Collider other)
    {
        if (playerColor == other.GetComponent<NPC>()._npcColor)
        {
            CorrectCollision(other);
        }
        else
        {
            InCorrectCollision(other);
        }
    }
    void CorrectCollision(Collider other)
    {
        Destroy(other.gameObject);
    }
    void InCorrectCollision(Collider other)
    {
        Debug.Log("Both are not same color");
        _settings.playerForwardSpeed = 0;
        _settings.playerSideMovementSpeed = 0;
        isDead = true;
        playerAnimator.SetBool("Run", false);
        Destroy(other.gameObject);
    }
    [Serializable]
    public class Settings
    {
        public float playerForwardSpeed;
        public float playerSideMovementSpeed;
    }

}
