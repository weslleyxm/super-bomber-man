using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Remake.Animations
{
    public enum PlayMode
    {
        LOOP,
        ONCE
    }

    public class AnimatorController : MonoBehaviour
    {
        public UnityAction<string> AnimationsStartedEventHandler;
        public UnityAction<string> AnimationFinishedEventHandler;

        public bool IsPlaying { get; private set; } = false;

        [SerializeField] private float framesPerSecond = 10;
        [SerializeField] private Animation[] animations;

        private int currentFrame = 0;
        private int lastFrame = 0;
        private float timer = 0f;
        private SpriteRenderer spriteRenderer;
        private PlayMode playMode;
        private Animation currentAnimation;

        private void Start()
        {
            InitialiezeAnimations();
        }

        private void LateUpdate()
        {
            if (currentAnimation == null)
                return;

            timer += Time.deltaTime;

            float totalFrames = currentAnimation.sprites.Length;
            float frameTime = 1 / totalFrames;

            if (timer >= frameTime)
            {
                currentFrame = (currentFrame + 1) % currentAnimation.sprites.Length;
                spriteRenderer.sprite = currentAnimation.sprites[currentFrame];

                if (currentFrame == lastFrame)
                {
                    StartCoroutine(AnimationEndEvent(frameTime));

                    if (playMode == PlayMode.ONCE)
                    {
                        IsPlaying = false;
                    }
                }

                timer = 0;
            }
        }

        private IEnumerator AnimationEndEvent(float time)
        {
            yield return new WaitForSeconds(time);
            AnimationFinishedEventHandler?.Invoke(currentAnimation.animationName);
        }

        private void InitialiezeAnimations()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void Stop()
        {
            IsPlaying = false;
            timer = 0;
              
            if (currentAnimation != null)
            {
                var defaultSprite = currentAnimation.defaultSprite;
                currentAnimation = null;

                if (defaultSprite != null)
                {
                    spriteRenderer.sprite = defaultSprite;
                }
            } 
        }

        public void Play(string animationName, PlayMode playMode)
        {
            for (int i = 0; i < animations.Length; i++)
            {
                if (animations[i].animationName.Equals(animationName))
                {
                    currentAnimation = animations[i];

                    lastFrame = currentAnimation.sprites.Length - 1;
                    break;
                }
            }

            if (currentAnimation != null)
            {
                Debug.LogWarning("It was not possible to play the animation because it was not found");
                return;
            }

            this.playMode = playMode;
            timer = int.MaxValue;
            IsPlaying = true;

            AnimationsStartedEventHandler?.Invoke(currentAnimation.animationName);
        }
    }
}