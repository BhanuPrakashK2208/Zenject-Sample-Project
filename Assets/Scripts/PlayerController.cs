using UnityEngine;
using System;
using Zenject;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
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
        if (Input.GetMouseButtonUp(0))
        {
            startingPosition = endingPosition = Vector3.zero;
        }
        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            if(transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color == 
                other.transform.GetChild(0).GetComponent<Renderer>().material.color)
            {
                Destroy(other.gameObject);
            }
            else
            {
                _settings.playerForwardSpeed = 0;
                isDead = true;
                playerAnimator.SetBool("Run", false);
                Destroy(other.gameObject);
            }
        }
    }
    [Serializable]
    public class Settings
    {
        public float playerForwardSpeed;
        public float playerSideMovementSpeed;
    }

}
