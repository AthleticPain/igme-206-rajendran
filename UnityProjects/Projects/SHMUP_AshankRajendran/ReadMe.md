# SHMUP

### Student Info

-   Name: Ashank Rajendran
-   Section: IGME 206

## Game Design

-   Camera Orientation: Top-down
-   Camera Movement: Camera is static, background scrolls to give the illusion of constant movement
-   Player Health: Player has a 100 hit points, 1 damage is taken from enemy projectiles and 10 damage is taken from collisions with enemy ships or asteroids
-   End Condition: Player dies. 
-   Scoring: 10 points earned per enemy ship destroyed

### Game Description

A physics heavy space shoot 'em up where you can use black holes and asteroids to your advantage!
The objective of the game is to kill as many enemy ships as possible before dying. The game is infinite and only ends when the player dies by taking enough damage and running out of HP.

### Controls

-   Movement
    -   Up: UpArrow or W
    -   Down: DownArrow or S
    -   Left: LeftArrow or A
    -   Right: RightArrow or D
    - Left Analog Stick for Controller

-   Firing Primary Gun
    - Spacebar on keyboard
    - Right Trigger on controller

-   Firing Secondary Gun (Homing Projectile)
    - X or M on keyboard
    - Left Trigger on controller

## Your Additions

-   Implemented:
    - Infinite scrolling parallax background and Parallax star field particle system (One near field and one far field) to give the player a sense of hyperspeed even though the camera is actually static.
    - Dynamic rocket trail for spaceships
	Rocket trail particle effect is dynamic and enlarges, shrinks and bends depending on the movemenet direction of the ship. 
    - Full Controller support
	This game is fully playable with a controller
    - Enemy Spawning and movement paths
	Enemies are spawned one by one on a delay based timer. There is a limit to how many enemies can be on screen at a single time. If there are that many enemies on screen, new enemies will not spawn in.
    - Black holes with active gravity fields
	Black holes spawn periodically and move across the screen. They feature a bespoke particle effect. They have their own gravity field which pulls player ships, enemy ships, projectiles and small asteroids towards it. During gameplay use black holes to bend your projectiles while being wary of less predictable enemy projectiles due to the same effect.
    - Dynamically destructible asteroids
	Asteroids will spawn in periodically and travel across the screen. There are two types of asteroids: Large asteroids and mini asteroids. Large asteroids only collide with the player and player projectiles. Mini asteroids collide with enemies and destroy them. 
	Large asteroids will be destroyed after being hit 30 times by the player. When they are destroyed the spawn a bunch of mini asteroids that scatter across the screen semi randomly in the direction of the enemies.
	The design intention is that players should destroy large asteroids in order to spawn these mini asteroids which are incredibly useful at clearing out the map.

-   Abandoned:
    - Wave-based enemy spawning

## Sources

-   All art assets https://www.kenney.nl/assets

## Known Issues

- Homing missiles can be fired at a much faster rate by spamming the button instead of holding it down.
- I initially intended to spawn the enemies in waves but as I tested the game out I found it much more fun to have a constant barrage of enemies coming in. I have limited the number of enemies that can be on screen at a single time.

### Requirements not completed
 - None
