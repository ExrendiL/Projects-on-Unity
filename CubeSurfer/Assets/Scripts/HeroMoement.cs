using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private HeroController heroController;

    [SerializeField] private float forwardMovementSpeed;

    [SerializeField] private float horizontalMovementSpeed;

    [SerializeField] private  float horizontalLimitValue;

    private float newPosX;


    
    void FixedUpdate()
    {
        SetHeroForwardMove();
        SetHeroHorizontaldMove();
    }

    private void SetHeroForwardMove()
    {
        transform.Translate(Vector3.forward * forwardMovementSpeed * Time.fixedDeltaTime);
    }

    private void SetHeroHorizontaldMove()
    {
        newPosX = transform.position.x + heroController.HorizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPosX = Mathf.Clamp(newPosX, -horizontalLimitValue, horizontalLimitValue);

        transform.position = new Vector3(newPosX,transform.position.y,transform.position.z);
    }
}
