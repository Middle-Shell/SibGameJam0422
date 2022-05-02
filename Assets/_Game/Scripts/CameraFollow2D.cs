
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] float damping = 1.5f;
    [SerializeField] Vector2 offset = new Vector2(2f, 1f);
    [SerializeField] bool faceLeft;
	private Transform player;
	private int lastX;

    [SerializeField]
    Camera cam;
    [SerializeField] float newSize;
    bool sizeIsChanged;

    [Space]
    [SerializeField] Vector2 minCord;
    [SerializeField] Vector2 maxCord;

    public int numCristals;
    AudioSource audioSrc;
    [SerializeField] Text txt;

    void Start ()
    {
        numCristals = 0;
       // txt.text = "";
         
        //cam = GetComponent<Camera>();
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
		FindPlayer(faceLeft);
    }

	public void FindPlayer(bool playerFaceLeft)
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		lastX = Mathf.RoundToInt(player.position.x);

        Vector2 pp = player.position;
	}

	void Update () 
	{
		if(player)
		{
			int currentX = Mathf.RoundToInt(player.position.x);
			if(currentX > lastX) faceLeft = false; else if(currentX < lastX) faceLeft = true;
			lastX = Mathf.RoundToInt(player.position.x);

			Vector3 target;
			if(faceLeft)
			{
				target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
			}
			else
			{
				target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
			}

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);

            if (currentPosition.x > minCord.x && currentPosition.x < maxCord.x)
            {
                transform.position = new Vector3(currentPosition.x, transform.position.y, transform.position.z);
            }
            if (currentPosition.y > minCord.y && currentPosition.y < maxCord.y)
            {
                transform.position = new Vector3(transform.position.x, currentPosition.y, transform.position.z);
            }

        }

        if (cam.orthographicSize == newSize)
        {
            sizeIsChanged = false;
        }

        if (sizeIsChanged)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newSize, Time.deltaTime * 3);
        }
    }

    public void ChangeSize(float _newSize)
    {
        sizeIsChanged = true;
        newSize = _newSize;
    }

    public void addCreistals()
    {
        numCristals += 1;

        txt.text = numCristals.ToString();
    }
}
