/// This script moves the character controller forward
/// and sideways based on the arrow keys.
/// It also jumps when pressing space.
/// Make sure to attach a character controller to the same game object.
/// It is recommended that you make only one call to Move or SimpleMove per frame.
var speed = 6.0;
var jumpSpeed = 8.0;
var gravity = 20.0;

private var moveDirection = Vector3.zero;

function IsMoving()
{
	return moveDirection.x != 0 || moveDirection.z != 0;
}

function FixedUpdate()
{
	var controller : CharacterController = GetComponent(CharacterController);
	if (controller.isGrounded)
	{
		// We are grounded, so recalculate
		// move direction directly from axes
		moveDirection = Vector3(Input.GetAxis("Horizontal2"), 0,
			Input.GetAxis("Vertical2"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;

		if (Input.GetButton ("Jump"))
		{
			moveDirection.y = jumpSpeed;
		}
	}

	// Apply gravity
	moveDirection.y -= gravity * Time.deltaTime;

	// Move the controller
	controller.Move(moveDirection * Time.deltaTime);
}
