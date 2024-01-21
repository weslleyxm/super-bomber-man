using Remake.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer spriterRenderer;
    private AnimatorController controller;

    private void Start()
    {
        spriterRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<AnimatorController>();
    }

    void Update()
    {
        Vector2 dir = Input.GetAxisRaw("Horizontal") * Vector2.right + Input.GetAxisRaw("Vertical") * Vector2.up;

        if (dir != Vector2.zero)
        {
            string animationName = "";

            if (dir.x != 0) 
                animationName = dir.x > 0 ? "walk_right" : "walk_left";  
            else if (dir.y != 0) 
                animationName = dir.y > 0 ? "walk_back" : "walk_front";    

            controller.Play(animationName, Remake.Animations.PlayMode.LOOP);
        }
        else
        {
            controller.Stop();
        }
    }

    private void HandlerInput(KeyCode key, Vector2 dir, bool flip)
    {
        if (Input.GetKeyDown(key))
        {
            spriterRenderer.flipX = flip;
        }
    }
}



//void Update()
//{

//    HandlerInput(KeyCode.W, Vector2.zero, false);
//    HandlerInput(KeyCode.S, Vector2.zero, false);
//    HandlerInput(KeyCode.A, Vector2.zero, true);
//    HandlerInput(KeyCode.D, Vector2.zero, false);
//}

