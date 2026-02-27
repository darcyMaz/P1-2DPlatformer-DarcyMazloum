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

      As the movement is a continuous input, it is best to use polling for it. Whereas the jump should use callback methods as pressing and releasing the jump button are discrete actions..

      I initially built my jump with polling and realized afterwards that callbacks are best. I have made a second script that includes a pseudo code implementation of the jump mechanic that would use callback methods.

      The controller I made that uses polling for the jump works perfectly, so I will only change it to use callbacks if I have time. But I recognize that callbacks would have been better to use and intend to use them going forward.
         
## Ground Detection Method: RayCast
      I decided to use the RayCast for my ground detection for its precision. It allowed the code to have zero frames of ground detection after the 
      jump had been performed.
      
## Coyote Time or Buffered Jump
      I decided to include both.
