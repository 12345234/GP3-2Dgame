using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    Vector3 preplayerpos;
    // Update is called once per frame
    void Update()
    {
        if(player.transform.position != preplayerpos)
        {
            transform.position = new Vector3(player.transform.position.x + 5,1,-10);
            preplayerpos = player.transform.position;
        }
    }
}
