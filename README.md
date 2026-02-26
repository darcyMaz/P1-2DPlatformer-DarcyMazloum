This Unity project includes an advanced character controller for a 2D platformer.

## Character Movement Explanation:
#      I decided to use RigidBody2D for my character because
#      1) I get to easily manipulate the velocity of the RigidBody (calculate it using SmoothDamp and just multiply that speed by the direction), 
#      2) I know that it will collide properly with the static colliders since the RigidBody is tracked by the physics engine,
#      3) I can set the RigidBody to have interpolate=interpolate and collision detection=continuous to avoid common bugs, and 
#      4) RigidBodys, where the loop is FixedUpdate(), are perfect for 2D platformers where we rely on forces from the physics engine and precise collisions.
 
 Polling vs. Callback Methods:
      I decided to use polling for both the movement and the jump because I needed frame by frame precision for both.
      I know that you recommend using callbacks for jumps, but it was critical for me to know the exact frame when the jump button was pressed and released.
      For example, when the Jump has its velocity cut when the player releases the jump button on the way up. There is one frame where the jump button 
          was released AND they are still jumping AND they are still moving upwards. Having all these states be known was critical. By polling I can
          easily access the status of the button while also tracking other logic.
         
 Ground Detection Method: RayCast
      I decided to use the RayCast for my ground detection for its precision. It allowed the code to have zero frames of ground detection after the 
      jump had been performed.
      
 Coyote Time or Buffered Jump: Both
      I decided to include both.
