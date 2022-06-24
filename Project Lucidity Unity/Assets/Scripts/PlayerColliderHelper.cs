using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderHelper : MonoBehaviour
{
    private Player player;
    public enum ColliderType {Bottom, Left, Right, Top};
    public ColliderType colliderType;

    // Start is called before the first frame update
    void Start(){
        player = transform.parent.GetComponent<Player>();
    }

    public void OnTriggerEnter2D(){
        switch(colliderType){
            case ColliderType.Bottom:
                player.onGround = true;
                break;
            case ColliderType.Left:
                player.touchingLeft = true;
                break;
            case ColliderType.Right:
            player.touchingRight = true;
                break;
            case ColliderType.Top:
                break;
        }
    }
    public void OnTriggerExit2D(){
        switch(colliderType){
            case ColliderType.Bottom:
                player.onGround = false;
                break;
            case ColliderType.Left:
                player.touchingLeft = false;
                break;
            case ColliderType.Right:
                player.touchingRight = false;
                break;
            case ColliderType.Top:
                break;
        }
    }
}
