# Game Basic Information #

## Summary ##

“Moo—” The cows are on campus! If you are interested in a campus with cows, come and explore the UC Davis campus with our game “Moo-venture!”  “UC Davis campus is the largest in area of the 10 campuses in the UC system,” we have cows, horses, an arboretum, a university farm, a vineyard, and so on! It takes up  We are going to take you around the campus and introduce the buildings and fun facts about different places to you. You will also meet a lot of “friends” on your way, and you can try to interact with them!

## Gameplay Explanation ##

In this game, the goal is to reach your destination, the building, within the time limit. As you play through the level to reach the building, which is located at the very right end of the level, there will be obstacles (turkeys) to hinder you and speed boosters (energy drinks) to help you move faster. You need to use the arrows or A and D on your keyboard to move the player left and right. To avoid the obstacles, you can choose to jump over the turkeys with the space bar or right click. You can also counter-attack the turkey to make them fly away. 

For the user's convenience, there are many ways you can choose to control the player. For example, we recommend hovering over the A and D keys and space bar with your left hand, and hovering over the mouse with your right hand to that you can left-click to attack. Another method you could try out is using the arrow keys with left hand to move your player in different directions, and control both jump and attack with the mouse in your right hand. Do not forget that there is a timer counting down how much time have left to reach the building and a distance bar that is keeping track of your progress as you go. You should also choose wisely between attacking and jumping to find the fastest way to overcome the obstacles, but feel free to explore both!

[Team Drive]([ECS 189L Group Project - Google Drive](https://drive.google.com/drive/u/0/folders/0ABOKrF96JRgFUk9PVA))

## Animation and Visuals

**List your assets including their sources and licenses.**
All visuals were created using Illustrator from the Adobe Creative Cloud.

*Start Scene (Menu)* - This is the opening page of the game, displaying the cow-print title "**Mooventure**" and the menu that features two **buttons** (listed under the User Interface section above) that allows the player to start or quit the game. The background of the scene is this **dorm**, giving the player a sneak peek before playing the game!

*Intro Scene (Tutorial)* - This scene features a Resident Advisor (**RA**) character that walks the player through the character, introducing the game's purpose, how the player can move around, jump, and attack, and what the player will encounter while they explore campus through the levels! Same as the Start Scene, the background of this scene is the **dorm**.

*Dorm Scene (Base)* - Here, the player can see their **character** for the first time in their **dorm** and test out their actions that they learned from the tutorial before exploring campus! The player can access this scene after watching or skipping the Intro Scene, and here, the player can revisit the Intro Scene if they need a refresher or check out the map by clicking on the labelled Gold and Blue **posters** (listed under the User Interface section above) on the wall.

*Level1 Scene (Gameplay)* - This is where the fun begins! Here, the player tries to reach **Shield Library** within the one-minute time limit, encountering **turkeys as obstacles** and **energy drinks as speed boosters** along the way. The background of this scene is made up of several **separate components (sky, buildings, trees, etc.)** that have been overlapped and combined together in order to create a beautiful, scenic view of the campus. The Shields Library is that the right end of this scene, and once the player reaches the front of the building, a pop up window will appear, introducing the library to the player.

*Map Scene (Level Navigation)* - To explore campus and visit the different buildings on campus, the player will access this scene to explore the **campus**. [Map Scene]([Mooventure/map-scene.png at trunk · matt-ucd/Mooventure (github.com)](https://github.com/matt-ucd/Mooventure/blob/trunk/Mooventure/Assets/Resources/Backgrounds/Level 1/map-scene.png)) is used at the background image for when the player visits the map, and in this scene, the player can view the different buildings / levels they can can visit. These three buildings () are implemented as buttons, which lead the player directly into the level. So far, the **Shields Library** level is live, and though the **other levels are "under construction"**, these were still placed on the map to display supplemental ideas we had for the game!

- [Map Scene (campus)]([Mooventure/map-scene.png at trunk · matt-ucd/Mooventure (github.com)](https://github.com/matt-ucd/Mooventure/blob/trunk/Mooventure/Assets/Resources/Backgrounds/Level 1/map-scene.png))
- [Level Scene (sky, sun, clouds, buildings, trees, road, library)]([Mooventure/Mooventure/Assets/Resources/Backgrounds/Level 1 at trunk · matt-ucd/Mooventure (github.com)](https://github.com/matt-ucd/Mooventure/tree/trunk/Mooventure/Assets/Resources/Backgrounds/Level 1))
- [Dorm Scene (with and without poster buttons)]([Mooventure/Mooventure/Assets/Resources/Backgrounds/Dorm at trunk · matt-ucd/Mooventure (github.com)](https://github.com/matt-ucd/Mooventure/tree/trunk/Mooventure/Assets/Resources/Backgrounds/Dorm))
- [Static Visuals (player character, turkey, energy drink)](https://github.com/matt-ucd/Mooventure/blob/trunk/Mooventure/Assets/Resources/Sprites/Character.png)
- [Animated Visuals (player, turkey, energy drink)]([Mooventure/Mooventure/Assets/Resources/Animations at trunk · matt-ucd/Mooventure (github.com)](https://github.com/matt-ucd/Mooventure/tree/trunk/Mooventure/Assets/Resources/Animations)) 

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

With the pandemic, many new students have not yet had the opportunity to experience campus in-person, so we wanted to create a fun, light-hearted game for these students to allow them to explore campus virtually! Here, we incorporated world-exploring and 2D platformer experiences into our gameplay to make the user's journey engaging and exciting!

To create a cheerful, happy atmosphere, we decided to use light and bright colors throughout each scene and with each individual component. These visuals were also enhanced with subtle shadows and gradients to bring more dimension and create more depth to the user's perspective. For the player's character, we decided to use a black-and-white line art style, which seems very simple and clean, to imitate a hand-drawn visual. Also, the user interface in this game, such as the popup windows and the buttons, also have a flat design (no gradients or shadows) as well. This not only allows makes these components stand out the user, but it also highlights what exactly the user can interact with directly, creating a nice contrast between interactions. For the [animations](https://github.com/matt-ucd/Mooventure/tree/trunk/Mooventure/Assets/Resources/Animations), we created different frames for each moving component, which are the [player](https://github.com/matt-ucd/Mooventure/blob/trunk/Mooventure/Assets/Resources/Sprites/Character.png)), speed boosters ([energy drinks](https://github.com/matt-ucd/Mooventure/blob/trunk/Mooventure/Assets/Resources/Sprites/Energy drink.png)), and obstacles ([turkeys](https://github.com/matt-ucd/Mooventure/blob/trunk/Mooventure/Assets/Resources/Sprites/Turkey.png)). 

For an extensive deep dive into the decision-making process and the choices made on the visuals and animations, please check out the [Visual Style Guide](https://docs.google.com/document/d/18Xc7zdXNgCwSsPZSjzJqdy3TAc0sKruAAQBtJ29eevg/edit?usp=sharing)!

## Input

**Describe the default input configuration.**

Platform and Input Information - For this project, the only platform we choose is PC. We are planning to make both the Windows version and Mac version which allows most people to play it. Because our game is a 2D game and only released on PC, our game relies on the mouse and keyboard to play. Therefore, we are trying to optimize the experience of using the keyboard and mouse. For example, the player can use both “WADS” or arrow buttons to control the character, and we also provide two ways to make the character jump. The player can choose a control method by their preference.

Transitions between all scenes -  In the project, to avoid crashing the player's computer  by loading too many materials at once, we decided to build different scenes and load them when necessary. This function has been achieved by the Unity scene manager. We learn this method from the [Udemy tutorial by Ben Tristem](https://www.udemy.com/course/unitycourse/learn/lecture/12210894#overview).
 In most of the scenes, there is a game object which contains the script of transition called trans to help scene transition.

Finalize all button functions- Since our project is a 2D project. The button function in unity can satisfy our requirements. Most of the buttons are used for transitions. But, some buttons also have other functions, such as the pause button in the level scene and the quit button in the start scene. When the pause button has been clicked, the game will create a pop-up window and halt the game. The pause function uses the Time.timeScale to halt the game. For the quit button. It utilizes the Application quit function to let the player quit the game. These implementation ideas are also inspired by the [Udemy tutorial by Ben Tristem](https://www.udemy.com/course/unitycourse/learn/lecture/10760212#overview).

Energy drink- In our game, there is an item called energy drink which provides the player a 5-second speed boost. When a player collides with an energy prefab, the prefab destroys itself, and the character controller will double the speed of the player. The maximum time of energy drink is five seconds. Getting a new energy drink will refresh the time but not extend the time. The collision mechanism is inspired by the [mechanism of coin prefab in the first project](https://github.com/dr-jam/CommandPatternExercise/blob/3c2ca1930af2b6de60823219cbee03328a42edb4/Captain/Assets/Scripts/CaptainController.cs#L55).

Pop-up windows - There are some pop-up windows in the game which provide necessary information and assistance to the player. The mechanism of the pop-up windows is quite simple. Each pop-up window is a prefab that contains necessary functions. When the player clicks some buttons, a clone of the pop-up window will be created. The pop-up window is on the top layer, which blocks other functions of the scene. After the player makes choices. Some functions will be executed, and the pop-up window will be destroyed. The idea of the pop-up window is get form Last project’s [ManualFire.cs](https://github.com/dr-jam/FactoryExercise/blob/976d6c82fa1b79d9ab205da5c05490db841618a0/Aegis/Assets/Scripts/ManualFire.cs#L5).

Typing animation - In the intro scene. There are a series of instructions that help the player to know how to play the game. To make the instructions more vivid and easier to read. We add a typing animation to the instructions. This function has been achieved by showtext.cs. All the instructions have been assigned to a string at the beginning. Then the textbox will keep updating in certain seconds which makes the player feel like the instructions have been typed to the screen. The script also detects the click from the player to skip the text. This also inspired by [Udemy tutorial by Ben Tristem](https://www.udemy.com/course/unitycourse/learn/lecture/10602858#overview).


## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

The interpretation of the Game Logic role was to keep a documentation of the progress and work done for our game throughout the three weeks we had to work on the game. All documentation regarding our game progress, states, and data used were done in a Master Shared Folder using Google Drive. There’s a main GoogleSheet that has access to the tasks, timeline, and other logistics of the game. See [here](https://docs.google.com/spreadsheets/d/1ynzckEy1m7fSg_NK0vH7rjGVvV6vhkn1GI6IUPYEISM/edit?usp=sharing) for the Master Sheet. On the master sheet, I primarily keep track of the Tasks assignment and timeline. Since we had roughly three weeks to work on the project, there are three main categories of the game state that we aimed to finish for each week:  Week1: Assets, Game Menu, one Game Level, and Player movement Week2: Integrate UI, Visuals, and player animation and interaction Week3: Refine & Improve game levels, popups, transition, and menu Then, breaking it down into tasks to do in each week, everyone is a task owner to some tasks that their roles or aspects others need help working on and a progress bar is given. I included the option for a Gantt Chart, but everyone seemed to be satisfied with the Progress Bar so we stuck to that only.  The Master sheet also has a Logistic sub sheet where links for meeting, github, and meeting notes are at. For every meeting, a google doc is created and all the progress, concerns, and next steps that were discussed in the meeting were recorded there.



# Sub-Roles

## Audio

**List your assets including their sources and licenses.**
All music and sounds are royalty-free and sourced with no charge.

*License Information*: [Purple Planet Music](https://www.purple-planet.com/licence-info) | [SoundJay](https://www.soundjay.com/tos.html) | [SoundBible](https://soundbible.com/about.php)

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

**Describe the implementation of your audio system.**

We implemented the background music by creating GameObjects in each scene with audio source .mp3 files and the Tags <Intro_Background>, <Level_Background>, <Map_Background> with their respective DontDestroy.cs, DontDestroyLevel.cs, and DontDestroyMap.cs scripts. In these scripts, we declare GameObjects[] array with the tags and destroy the objects of the tag that are not meant to play the audio in that specific scene.  Some Citation: 

For the implementation of the sound effects used in player's collision with the turkeys and the energy drinks, we added a SoundManager script that does what we did with background music, except this time completely hardcoded. We implement the sound effects in the level scene this way because player's interaction with the objects are done in PlayerController.cs. Hence, this is the most efficient method of sound effect implementation. 

*Citations:*

[Background music](https://www.youtube.com/watch?v=JKoBWBXVvKY)

[Sound effects](https://www.youtube.com/watch?v=8pFlnyfRfRc)

**Document the sound style.** 

[*Background Music and Sound Effects*](https://github.com/matt-ucd/Mooventure/tree/trunk/Mooventure/Assets/sounds)

Because our game's targeted audience is new students and its purpose is to introduce the UC Davis campus, we wanted our game to have a fun and welcoming atmosphere! For each of our three background visuals (dorm, map, level), we selected a different music to play in the background to create more differentiation when the player switches between scenes. These three soundtracks all have a cheerful vibe to them, establishing a light-hearted atmosphere throughout the game, and the carefree and serene pacing of these music selections allows the player to navigate through the game and explore the campus at their own leisure.

We also added sound effects to make the game feel more immersive to the player. Across all scenes, we implemented a quick, chirpy sound for button clicks to give the player feedback as they navigate through the game. For the level scene, we added sounds effects for the pop-up windows and the player's interactions with the speed boosters and obstacles during active gameplay. Once they open up, both pop-up windows play a trumpet sound -- the fail window sad, downcast tune, while the success window plays a happy, congratulatory tune! The turkey also plays a turkey gobble noise every time it spots the player and starts charging at them angrily. Having these sound effects not only make the game more responsive and intuitive, but they also add humor to the gameplay and contribute to the happy, light-hearted tone of the game!

## Gameplay Testing

Gameplay testing was performed gradually along with development. Each time a new feature was added, or adjusted, that feature, along with any other features that shared interactions, would be tested. This helped to adjust the game feel as development progressed, and to find any bugs early.

### Improvements

* Found player movement felt too slippery and floaty. Altered the player gravity, speed, and jump height to attain a more desirable movement.  
* The initial camera didn't feel quite right for a 2D platformer, so it was updated to Mario World style camera.
* Initial knockback force from turkeys was too strong. Adjusted until it felt right.
* The player was initially able to move during knockback, so all velocity is removed on collision, and the player is stunned for a short time.
* Stun time during knockback took some fine-tuning to make it feel good.
* The power-ups initially had a physical box collider, but this would sometimes cause the player to lose physically collide with them even though they were set to be destroyed on collision. They were changed to triggers, so the player cannot actually make physical contact with them, but they can still be collected.
* Turkeys initially had only 1 distance for aggro, so if you could move in and out to make them become aggressive and passive. This didn't feel right, so a new, larger, distance was added that would cause the turkeys to lose aggro. This way they would chase the player for a while before becoming passive again.

### Bugs
* The initial Mario World camera was very buggy. At one point the camera would move continually back and forth between two points, and then the player would inexplicably fall through the ground. This was eventually fixed and the camera works correctly.
* The player could only attack to one side regardless of the direction they faced. Had to rework the way the sprite was being flipped to also move the attack point.
* The player was able to stick to the level boundary, and could slowly scale up the screen and off the camera. A physics material was added to the boundary with 0 friction to avoid this problem.

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

The narrative design of the game is quite simple. We start the narrative design process by deciding which kind of game we want to make first. During the discussion, we find that we all miss the time which we spend on campus, and if there is a game that can help us to experience the landscape of the campus would be better. Inspired by this idea, we finally decided to make a game about UC Davis. On the one hand, this game can remind us of student life on campus. On the other hand, we also want to use this game to introduce our campus to other people.  Such as the history of some buildings or some interesting features about our college. 

After deciding the main theme, we also consider which kind of people are our potential players. After a short discussion, we decided that our potential players might be some students who want to revisit the campus or someone interested in knowing UC Davis. Thus, instead of creating a virtual story, we want to give the player a feeling or visit the campus while they are playing the game. Therefore, our game does not have any magnificent story for the player. Instead of that, we decided to add some UC Davis features to our game and introduce history to the players.

UI always is the best place to convert the idea of the game designers to the player. Therefore, The main theme of our scenes is Aggie blue. We want to use this typical color to give the player a sense of familiarity. Furthermore, talking about UC Davis, animals are another symbol that we cannot forget. Therefore, in most of the scenes, there are cow-related elements. Such as the title in our stars scene or energy drink which is an item of the game. We also set the obstacle as turkeys. 

As for gameplay, because our main point is to let the user view the landscape of the campus, we do not plan to add any intensive battle element to the gameplay. The main idea we want to give to the player is to use the scene to remind the player of campus life or introduce the landscape and history to the player who wants to know more about UC Davis. 


## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

PressKit link: http://jlo0507.github.io/ecs189l/ 

Trailer Link: https://youtu.be/wcrtbHhJNAY  

*Music Credits for Trailer*: 

First half - Sense Of Loss from Purple Planet Music

Second Half - Feel Good from Purple Planet Music

(License information listed in Audio above.)

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**

How did you choose what to show in the trailer? Why did you choose your screenshots? For the Press Kit, we decided to make it from scratch to have full power on the implementation and design of the page. We used the same color schemes we have in the game. For the screenshots, I just decided to include the main components of our game scenes. On the Press Kit, we have multiple sections dedicated to all the aspects of the game that we want to let our audience know, which include game description, trailer, screenshots, and our team bio.  For the trailer, I took some b-roll shots from two YouTube sources: [AggieStudio](https://www.youtube.com/watch?v=e3ytGlr6WSg) and [Jerry Dong](https://youtu.be/oJ4L23aKJiA) for the first half of the trailer. We wanted to start the trailer with real footage of the campus during COVID and SIP to explain the purpose of our game. Then, with a happier tone, introduce some playthrough footage of our actual game! By showing the trailer in this flow, the viewers have a better understanding and motivation to do that “virtual tour” with our game.

## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**

*Introduction/tutorial scene* - We consciously noticed that it would be helpful to have a introduction and a brief tutorial before the game starts. However, we debated about how to encourage the players to watch the tutorial. We thought about having an attention-attracting "intro" button or giving a forced tutorial at the beginning. After discussions, we decided to add a pop-up window at the beginning, where when you click on the "start" button, it will ask you to go over an introduction. After you finished it or skipped it, you can still access it by clicking on the "intro" button later. This helps the player to get a better overview of our game backgrounds and how they should play the game.

*Interaction between the player and the turkey* - The player was designed to "die" if she is hurt by the turkey. However, it might be too frustrating if the player is not familiar with the attack technic. So we decided to change the interaction mechanism between the player and the turkey. Instead of dying directly, we added a "knockback" effect, in which the player would be pushed back and not able to move right after if she is hurt by the turkey. This mechanism fits well into the game because it is timed, and it also helps the player to survive longer in the game.

*Jump control* - In Unity, the left and right movements are bound to both left and right arrows and "A" and "D." And we also want to have a "jump" and an "attack" keyboard control. At first, we bound "jump" to the space bar, and "attack" to the left click on mouse. However, when we try to play the game, we find that it is a little hard to use left, right arrows, space bar and the mouse click at the same time. Therefore, we decided to add right click on mouse as "jump" as well so that players can freely choose the combination they are used to and have a better gaming experience.

*Buttons for transitions between scenes* - We designed to go back to the dorm scene every time when the player finish a level. However, we were ahead of time and added a map scene for the player to choose the level. We found that it would be more convenient for the player to select a different level directly after finishing one level instead of clicking on map every time. We also found out that there is no way for the player to go back to the main menu and quit the game if the player finished a level. Therefore, we added a menu button to connect the dorm scene with the main game menu to have a smoother transition.
