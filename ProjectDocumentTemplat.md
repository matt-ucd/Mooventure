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

## Animation and Visuals

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio

**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**

*Introduction/tutorial scene* - We consciously noticed that it would be helpful to have a introduction and a brief tutorial before the game starts. However, we debated about how to encourage the players to watch the tutorial. We thought about having an attention-attracting "intro" button or giving a forced tutorial at the beginning. After discussions, we decided to add a pop-up window at the beginning, where when you click on the "start" button, it will ask you to go over an introduction. After you finished it or skipped it, you can still access it by clicking on the "intro" button later. This helps the player to get a better overview of our game backgrounds and how they should play the game.

*Interaction between the player and the turkey* - The player was designed to "die" if she is hurt by the turkey. However, it might be too frustrating if the player is not familiar with the attack technic. So we decided to change the interaction mechanism between the player and the turkey. Instead of dying directly, we added a "knockback" mechanism, in which the player would be not able to move forward for a certain time if she is hurt by the tureky. This mechanism fits well into the game because it is timed, and it also helps the player to survive longer in the game.

*Jump control* - In Unity, the left and right movements are bound to both left and right arrows and "A" and "D." And we also want to have a "jump" and an "attack" keyboard control. At first, we bound "jump" to the space bar, and "attack" to the left click on mouse. However, when we try to play the game, we find that it is a little hard to use left, right arrows, space bar and the mouse click at the same time. Therefore, we decided to add right click on mouse as "jump" as well so that players can freely choose the combination they are used to and have a better gaming experience.

