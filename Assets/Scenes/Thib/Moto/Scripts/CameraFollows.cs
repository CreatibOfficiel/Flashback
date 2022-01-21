using UnityEngine;
public class CameraFollows : MonoBehaviour
{
    public Transform target;
    public float smoothing = 15f;
    float offset;

    private void Update()
    {
        if (RaceManager.instance.getGameState())
        {
            if (PlayerMove.instance._rigidbody.velocity.x < 0.2f)
            {
                offset = 10;
            }
            else
            {
                offset = PlayerMove.instance._rigidbody.velocity.x - 4;

            }
            if (Vector2.Distance(transform.position, PlayerMove.instance.transform.position) > 15 && transform.position.x < PlayerMove.instance.transform.position.x)
            {
                offset = PlayerMove.instance._rigidbody.velocity.x + 2;
            }
            if (Vector2.Distance(transform.position, PlayerMove.instance.transform.position) > 35)
            {
                RaceManager.instance.StopGame(true);
            }
        }
    }
    void FixedUpdate()
    {
        if (RaceManager.instance.getGameState())
        {
            Vector3 targetCamPosition = new Vector3(transform.position.x + offset, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetCamPosition, 1 * Time.deltaTime);
        }
    }
}
