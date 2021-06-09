# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**

## Gameplay Explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**


**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

*Cow-print window frames* - To better integrate UC Davis elements into our game, we designed cow-print window frames. [UIs](https://github.com/matt-ucd/Mooventure/tree/trunk/Mooventure/Assets/ui-kit)

*UC Davis gold and Aggie blue color theme* - While the cow-print are in black and white, we want to add more colors to fit in the happy vibe of the game. So we decided to include the iconic UC Davis gold and Aggie blue color theme. We modified the brightness and the saturation to make it more pop up from the game. We used this color theme for all of our buttons and UIs to make it look consistent. [UIs](https://github.com/matt-ucd/Mooventure/tree/trunk/Mooventure/Assets/ui-kit)

*flat windows and buttons* - Windows and buttons are designed in flat 2D, because we found out that flat ones look brighter and clearer than the ones with gradient. [UIs](https://github.com/matt-ucd/Mooventure/tree/trunk/Mooventure/Assets/ui-kit)

*shadowed texts* - Texts are designed to have a black shadow in the back and a white highlight in the front. In this way, the texts look like they pop up from the background, and make the texts easier to read. It also corresponds to the black and white cow-print theme. [Text design](https://github.com/matt-ucd/Mooventure/blob/7bbe46c8cd4f3a4bba6f8f5120d09bb64e49cb19/Mooventure/Assets/Scenes/Intro.unity#L1008)

*distance bar* - We designed the distance bar with a head icon of the player as the handler and the goal building icon as the destination. In this way, the player could keep track of the remaining distance, and try to see if they can successfully reach the goal in time. [Distance bar script](https://github.com/matt-ucd/Mooventure/blob/trunk/Mooventure/Assets/Scripts/DistanceBar.cs)

*digital timer* - We designed the timer as a digital timer so that the time is shown clearly and it is easy to read. [Timer script](https://github.com/matt-ucd/Mooventure/blob/trunk/Mooventure/Assets/Scripts/Timer.cs)

*font design* - The large texts are in BaksoSapi, and the smaller texts are in PinkChicken-Regular. They are free fonts found on dafont.com. We chose these two because both of them are in a hand-written style, and we think this fit well into our game. [Fonts](https://github.com/matt-ucd/Mooventure/tree/trunk/Mooventure/Assets/Resources/Fonts)

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**
The physics system is the standard physics system implemented by Unity. Movement scripts were crafted using the Unity physics engine, with some slight modifications to certain objects:  

* The gravity scale of the player was increased to 6, to give the jump less of a "floaty" feel, and to decrease the amount of sliding when a direction was released.  
* An invisible object was placed at the beginning of the stage to prevent the player from moving off the camera. A physics material with 0 friction was added to the collider of this object to prevent the player from sticking to it, which would allow them to pseudo-climb it.  
* Colliders for the energy drink power-ups were changed to triggers. This would allow the player to still collect them, but prevent them from being physically touched and changing the velocity of the player.  
* Turkeys are made to ignore player collisions when fleeing to avoid the player being knocked back even after defeating them.

Our movements are the abilities to go left (A or left arrow), right (D or right arrow), jump (space or right click), and attack (left click). These were implemented using the command pattern.

The turkeys follow a simple script to move back and forth a specified distance from their spawn point. Once the player is within their aggro radius, the turkey will chase them until they move beyond their de-aggro radius. Once a turkey drops aggro it will run back to its' spawn area and continue moving back and forth.

Turkeys attack the player by running into them, which will stop all velocity of the player, and then knock them back with a sudden force. The player will also be stunned a short duration where they can't act. Currently the player has no period of invulnerability after being hit.

The player can attack the turkey by giving it a stern talking-to. Upon being thoroughly chastized, it will become sad and fly away. 

## Animation and Visuals

**List your assets including their sources and licenses.**
All visuals were created using Illustrator from the Adobe Creative Cloud.

*Backgrounds*:

[Dorm](https://github.com/matt-ucd/Mooventure/tree/trunk/Mooventure/Assets/Resources/Backgrounds/Dorm) -

[Level](https://github.com/matt-ucd/Mooventure/tree/trunk/Mooventure/Assets/Resources/Backgrounds/Level%201) -

[Map]() -


*Assets*

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

...

## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

Transitions between all scenes -  In the project, to avoid crashing the player's computer  by loading too many materials at once, we decided to build different scenes and load them when necessary. This function has been achieved by the Unity scene manager. We learn this method from the Udemy tutorial. In most of the scenes, there is a game object which contains the script of transition called trans to help scene transition.

Finalize all button functions- Since our project is a 2D project. The button function in unity can satisfy our requirements. Most of the buttons are used for transitions. But, some buttons also have other functions, such as the pause button in the level scene and the quit button in the start scene. When the pause button has been clicked, the game will create a pop-up window and halt the game. The pause function uses the Time.timeScale to halt the game. For the quit button. It utilizes the Application quit function to let the player quit the game. These implementation ideas are also inspired by the Udemy tutorial.

Energy drink- In our game, there is an item called energy drink which provides the player a 5-second speed boost. When a player collides with an energy prefab, the prefab will be destroyed, and the character controller will double the speed of the player. The maximum time of energy drink is five seconds. Getting a new energy drink will refresh the time but not extend the time. The collision mechanism is inspired by the coin prefab of the first project.

Pop-up windows - There are some pop-up windows in the game which provide necessary information and assistance to the player. The mechanism of the pop-up windows is quite simple. Each pop-up window is a prefab that contains necessary functions. When the player clicks some buttons, a clone of the pop-up window will be created. The pop-up window is on the top layer, which blocks other functions of the scene. After the player makes choices. Some functions will be executed, and the pop-up window will be destroyed. The idea of the pop-up window is from the fourth. The projectile in the project will create when the player clicks the mouth and be destroyed when colliding with the shield.

Typing animation - In the intro scene. There are a series of instructions that help the player to know how to play the game. To make the instructions more vivid and easier to read. We add a typing animation to the instructions. This function has been achieved by showtext.cs. All the instructions have been assigned to a string at the beginning. Then the textbox will keep updating in certain seconds which makes the player feel like the instructions have been typed to the screen. The script also detects the click from the player to skip the text.


## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio

**List your assets including their sources and licenses.**
All music and sounds are royalty-free and sourced properly with no charge.

*Background Music*:

[Dorm Scene]() - Feel Good from Purple Planet Music

[Level Scene]() - Quirky Moments from Purple Planet Music

[Map Scene]() - Happy Go Lucky from Purple Planet Music


*Popup Windows*:

[Fail Window]() - from SoundJay

[Success Window]() - from SoundBible


*Sound Effects*:

[Player receives speed boost from energy drink.]() - from SoundJay

[Player attacks the turkey as an obstacle.]() - from SoundJay

[Turkey gobbles when player is spotted.]() - from SoundBible


*License Information*:

[Purple Planet Music](https://www.purple-planet.com/licence-info)

[SoundJay](https://www.soundjay.com/tos.html)

[SoundBible](https://soundbible.com/about.php)

**Describe the implementation of your audio system.**

...

**Document the sound style.** 

...

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

The narrative design of the game is quite simple. We start the narrative design process by deciding which kind of game we want to make first. During the discussion, we find that we all miss the time which we spend on campus, and if there is a game that can help us to experience the landscape of the campus would be better. Inspired by this idea, we finally decided to make a game about UCDavis. On the one hand, this game can remind us of student life on campus. On the other hand, we also want to use this game to introduce UCDavis to other people.  Such as the history of some buildings or some interesting features about our college. 

After deciding the main theme, we also consider which kind of people are our potential players. After a short discussion, we decided that our potential players might be some UC Davis students who want to re-visit the campus or someone interested in knowing UC Davis. Thus, we decided instead of creating a virtual story, we want to focus on the design of the scene and UI to add more UC Davis symbols to our game. Therefore, our game does not have any magnificent story for the player. Instead of that, we decided to add more UC Davis features to our game and introduce history to the players.

UI always is the best place to convert the idea of the game designers to the player. Therefore, The main theme of our scenes is Aggie blue. We want to use this typical color to give the player a sense of familiarity. Furthermore, talking about UC Davis, cows are another symbol that we cannot forget. Therefore, in most of the scenes, there are cow-related elements. Such as the title in our stars scene. Or the energy drink which the player can encounter during the gameplay. 

As for gameplay, because our main point is to let the user view the landscape of the campus, we do not plan to add any intensive battle element to the gameplay. The main idea we want to give to the player is to use the scene to remind the player of campus life or introduce the landscape and history to the player who wants to know more about UC Davis


## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**

*Introduction/tutorial scene* - We consciously noticed that it would be helpful to have a introduction and a brief tutorial before the game starts. However, we debated about how to encourage the players to watch the tutorial. We thought about having an attention-attracting "intro" button or giving a forced tutorial at the beginning. After discussions, we decided to add a pop-up window at the beginning, where when you click on the "start" button, it will ask you to go over an introduction. After you finished it or skipped it, you can still access it by clicking on the "intro" button later. This helps the player to get a better overview of our game backgrounds and how they should play the game.

*Interaction between the player and the turkey* - The player was designed to "die" if she is hurt by the turkey. However, it might be too frustrating if the player is not familiar with the attack technic. So we decided to change the interaction mechanism between the player and the turkey. Instead of dying directly, we added a "knockback" effect, in which the player would be pushed back and not able to move right after if she is hurt by the turkey. This mechanism fits well into the game because it is timed, and it also helps the player to survive longer in the game.

*Jump control* - In Unity, the left and right movements are bound to both left and right arrows and "A" and "D." And we also want to have a "jump" and an "attack" keyboard control. At first, we bound "jump" to the space bar, and "attack" to the left click on mouse. However, when we try to play the game, we find that it is a little hard to use left, right arrows, space bar and the mouse click at the same time. Therefore, we decided to add right click on mouse as "jump" as well so that players can freely choose the combination they are used to and have a better gaming experience.

*Buttons for transitions between scenes* - We designed to go back to the dorm scene every time when the player finish a level. However, we were ahead of time and added a map scene for the player to choose the level. We found that it would be more convenient for the player to select a different level directly after finishing one level instead of clicking on map every time. We also found out that there is no way for the player to go back to the main menue and quit the game if the player finished a level. Therefore, we added a menu button to connect the dorm scene with the main game menu to have a smoother transition.
