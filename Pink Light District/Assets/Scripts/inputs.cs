using UnityEngine;
using UnityEngine.InputSystem;

public class inputs : MonoBehaviour
{
    [SerializeField] 
    float speed = 10.0f;
    [SerializeField]
    float walkAni = 22f;
    InputAction move;
    InputAction interact;
    

    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        interact = InputSystem.actions.FindAction("Interact");
        transform.Rotate(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = move.ReadValue<Vector2>();
        float x = input.x * speed * Time.deltaTime;
        float z = input.y * speed * Time.deltaTime;

        transform.position = transform.position + new Vector3(x, 0, z);

        while (input.x !=0 || input.y !=0)
        {
            transform.Rotate(walkAni, 0, 0);
            transform.Rotate(walkAni * -1, 0, 0);
        }
    }
}
