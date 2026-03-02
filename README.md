This Unity project prototypes an advanced character controller for a 2D platformer. Crisp and fluid movement free of common bugs from collision and ground detection. A precise jump mechanic that includes coyote time and jump buffering. All using industry standard design patterns.

Darcy Mazloum - 2545876

Controls:
Left Stick or A/D for left and right.
South Gamepad Button or Space Bar to Jump.

## Character Movement Explanation
      I decided to use RigidBody2D for my character because:
      
      1) I get to easily manipulate the velocity of the RigidBody (calculate it using SmoothDamp and just multiply that speed by the direction), 
      2) I know that it will collide properly with the static colliders since the RigidBody is tracked by the physics engine,
      3) I can set the RigidBody to have interpolate=interpolate and collision detection=continuous to avoid common bugs, and 
      4) RigidBodys, where the loop is FixedUpdate(), are perfect for 2D platformers where we rely on forces from the physics engine and precise collisions.
 
## Polling vs. Callback Methods
      
      I decided to use polling for both the movement and the jump.

      As the movement is a continuous input, it is best to use polling for it. Whereas the jump should use callback methods as pressing and releasing the jump button are discrete actions.

      I initially made the jump functionality use polling but upon better understanding of best practices, I made a new script where it uses event callbacks.

      However, I had an issue combining ground detection and the coyote time functionality which led to unintended double jumps. I then took a better look at your scripts, made a second version, and had the same problem.

      I will likely come to you to go over this in the future, as I'd like this to work, but for now I am submitting my fully functional polling version for the jump mechanic due to time constraints.
         
## Ground Detection Method: RayCast
      I decided to use the RayCast for my ground detection for its precision. It allowed the code to have zero frames of ground detection after the 
      jump had been performed.
      
## Coyote Time or Buffered Jump
      I decided to include both.
