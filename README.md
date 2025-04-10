# HackTrap

## Dokumentation

Dokumentation zum Deepspace Projekt: :page_facing_up: [Deepspace-Docs](./docs/Deepspace-Docs.md)
Dokumentation zur VR-Version: :page_facing_up: [VR-Docs](./docs/VR-Docs.md)

## What is HackTrap?

HackTrap is an AEC-DeepSpace-Game which teaches young children how to deal safely with the digitized internet world by playing through an exciting hacker-attack and killing the virus.

![HackTrap Logo](Skizzen/00_LOGO.png)

# Table of Contents
 * [Sprint Userstories](#userstories)
 * [Sprints Overview](#sprints)
 * [Initial Situation](#our-team)
 * [Goal & Game Procedure](#2-goal)
    * [Scene 1 - Ipad](#safari-3-games)
    * [Scene 2 - MiniGame](#opening-an-app)
    * [Scene 3 - Hacker Question](#question-to-continue-playing)
    * [Scene 4 - Attack](#pop-up-attack)
    * ...
 * [Risk Analysis](#3-risk-analysis)
 * [Project Workflow](#4-project-workflow)

# Userstories
### Need to be done
Here you can see the progress of our Userstories: [HackTrap Userstory Backlog](https://github.com/orgs/SYP-AHIF-2023-24-25/projects/6/views/1)

### Sprint 2
- [x] The User should be able to see a virtual ipad which will be projected on the main screen.
- [x] The User should be able to use the ipad to click on one of the three cards each with a different minigame and get to the minigame.
- [x] The user will be able to communicate with the ipad through clicking onto the cards.
- [x] The User should be able to play the desired minigame (tic-tac-toe) by clicking on the different fields.
- [x] The User should be able to see a question after playing one round of the desired minigame.
- [x] The User should be able to choose between a "yes" or "no" button for the question asked. Eather way choosen, the user gets to the next scene.

### Sprint 3
- [x] The User should be able to see and experience the hacker attack (due to sounds and animation).
- [x] The user should be able to see opening credits as long as not all users are inside the deepspace / the game doesn't start. 
- [x] The User should be able to hear game sounds for all kind of activities.
- [x] The User should be able to be inizialised as a player for a team (via Usertracking).
- [x] The User should be able to pick up/collect viruses on the floor.
- [x] The User should be able to dump his collected viruses in (only) his team container.

### Sprint 4
- [x] The User should be able to see viruses on the floor.
- [x] The User should be able to see four team container.
- [x] The User should be able to enjoy an instruction to the "Encrypt The Virus-Box"-Game.
- [x] The User should be able to see an animation where all the virus-cages of the teams fly into one virus-box.
- [x] The User should be able to play the "Encrypt The Virus-Box"-Game under time pressure with a ticking timer.
- [x] The user should be able to select letters on the floor in the “Encrypt The Box” game.
- [x] The User should hear a "Correct"-sound and see the letter disappear from the floor, when selecting a correct letter in the correct order.
- [x] The user should hear a "wrong" sound and see the letter on the floor in red color for 3 seconds.
- [x] The User should be able to enjoy and see a Success/Failure Ceremony in the end of the game (depending on the result of the Encrypting Box Game).
- [x] The User should be able to see an advertisment at the end of the game (Ars Electronica x HTL Leonding).
- [x] The User should be able to see a game-evaluation with the main-game-results of each team, after all the viruses are collected.
- [x] The User should be able to see a game-evaluation with the main-game-results of each team, after all the viruses are collected.
- [x] The User is able to play TicTacToe (SinglePlayerMode).

### Sprint 5
- [x] The User should be able to enjoy the Hacking-Attack-Scene and the "You've been hacked!"-Scene in a better performance-quality than before.
- [x] The User should be able to see a skull on the wall & floor and hear a sound after clicking onto the memory or rock-paper-scissors card.
- [x] The User should in the iPad-Scene only be able to start the TicTacToe game (not the memory & rock-paper-scissors games).
- [x] The User should be able to enjoy a nice background music with adjusted volume.
- [x] The User should be able to enjoy music & sounds during the game which fit even from scene to scene together, and whose volume is adjusted for a pleasant game-experience.
- [x] The User should be able to enjoy a cleaner SinglePlayer UserTracking.
- [x] The User should be able to enjoy a new Scene Transition.
- [x] The User should be able to enjoy a new and better Welcome Scene at the beginning of the HackTrap-Game.
- [x] The User should enjoy a better and more uniform Scene Design over the whole game.
- [x] The User should be able to enjoy a Success Animation.
- [x] The User should be able to enjoy a Failure Animation.
- [x] The User should be able to enjoy the Main-Game of HackTrap. 

### Sprint 6
- [x] The User should be able to enjoy a nice flowing-transition by moving from one scene to another.
- [x] The User should be able to enjoy the HackTrap game with a better performance by playing with the new HackTrap-template.
- [x] The User should be able to enjoy the HackTrap game in a better game-quality & resolution by playing with the new HackTrap-template.
- [x] The User should see in the team-assignment-procedure how many players are already on the DeepSpace floor.
- [x] The User should be able to see the team-virus-score of his/her team during the game on the wall.
- [x] The User should be able to get assigned to a team by stepping onto the DeepSpace floor.
- [x] The User should be able to enjoy a new and better Welcome Scene at the beginning of the HackTrap-Game.
- [x] The User should see a fluent transition (animation) from the Ipad Cards to the desired minigame. 
- [x] The User should be able to collect a maximum of four viruses into/with the Select-Virus-Box.
- [x] The User should be able to drop the viruses into it's team Drop-Virus-Off-Container only.
- [x] The User should be able to see in the Select-Virus-Box a ring in his/her assigned team-color. 
- [x] The User should be able to see one part of the Select-Virus-Box getting red by collecting a virus.
- [x] The User should be able to see the Selected-Virus-Box split into four parts, which represents the number of free spaces for viruses. 
- [x] The User should not be able to drop the viruses into anothers team Drop-Virus-Off-Container. 
- [x] The User should be able to collect a maximum of four viruses into/with the Select-Virus-Box.
- [x] The User should be able to see a Select-Virus-Box under his/her feet by stepping onto the DeepSpace floor. 

# Sprints
### 1. Sprint - Project Initialisation
- [x] Project proposal
- [x] Feedback from Prof. Hasi - revise user stories (after AEC meeting)
- [x] Get Horizon template up and running (incorporate into code)
- [x] Download Unity (AEC Developer Kid)
- [x] Preparation for AEC meeting (20.10)

### 2. Sprint - Ipad & Minigame
- [x] Unity Tutorials
- [x] Set up a 3D project (AEC standards)
- [x] Ipad + MiniGame Gards UI
- [x] Implementation of first minigame (TicTacToe)
- [x] Scene (Configuration) Flow + Floor UI
- [x] Hacker question

### 3. Sprint - Usertracking, Main-Game & Animation
- [x] Hacker Attack
- [x] Welcome Scene
- [x] Teamevaluation on the floor
- [x] Maingame on the floor
- [ ] Usertracking
- [x] Teamresults in realtime
- [x] Animations
- [x] Scene Adaption on Wall and Floor Canvas

### 4. Sprint - Usertracking Testen & Rest vom Game
- [x] Projekt mit neuer Unity-Version
- [x] Container-Animation (Virus-Box)
- [x] Game-Auswertung
- [x] "Encrypt The Virus-Box"-Gameanleitung
- [x] "Encrypt The Virus-Box"-Game (Wall + Floor)
- [x] TicTacToe (Single Player Mode)
- [x] Success & Failure Ceremony
- [x] Advertisment (Ars Electronica x HTL Leonding)
- [x] Main-Game with UserTracking
- [x] Scenes-transformation with UserTracking

### 5. Sprint - Adjustments, Improvements
- [x] Scene-StateManager (All Scenes into one)
- [x] Make the SinglePlayer UserTracking clean
- [x] Scene Transitions
- [x] Welcome-Scene (New & Better Verison)
- [x] Finish iPad-Scene (Adjustments on Wall + Floor)
- [x] Improvements on Scene Designs
- [x] Performance Improvement on two Hacking-Scenes
- [x] Music & Sound Adjustments/Improvements
- [x] Volume Adjustments
- [x] Main-Game
- [x] Unity Overall Template Redesign
- [x] Success & Failure Animation

### 6. Sprint - Fixes
- [x] Transitions (Übergänge)
- [x] Verbesserung der Ordnerstruktur
- [x] Neues DeepSpace-SetUp
- [x] 3D-Modelle mit Blender (Virus, Select-Virus-Box, 4x Drop-Virus-Off-Container)
- [x] Integration & Anpassung der 3D-Modelle in das Main-Game
- [x] Testen der 3D-Modelle (Main-Game); ("Skelett"-Demo)
- [x] Code Refactoring
- [x] Connection mit Wall & Floor im Main-Game
- [x] Anpassung der Hacking-Scene
- [x] Team-Assignment


## Our Team
Christian Ekhator, Julian Kapl, Julia Meyr & Amina Gabeljic

## 1. Initial Situation
### 1.1. Current Situation
Since children tend to learn about Internet use at an early age, they still have little idea of what is happening in the background.
The current project from the ARS Elektroniker Center in Linz, NewHorizon, explains to children how data is distributed. However, dangers can arise that children are not yet aware of.

### 1.2. Potential for improvement
#### Problems
- The children usually have no knowledge about the dangers that the internet comes with
- Outdated technology / game

#### Improvements
- A better overview of the dangers on the Internet
- Let the cooperation be maintained
- Another learning effect for children to use in every day life 

## 2. Goal
Our goal is to teach children that there are dangers and traps on the Internet. CubeIT should trigger a learning effect that shows the children how they should react and what happens if they (unintentionally) do something wrong.

## Target state

### Start of the game
The game begins with the screen on the wall producing a preview of an iPad, with 3 apps being displayed on the iPad. It should stay with only 3 apps, so as not to overwhelm the children with too many app displays at the beginning.

Overview of the 3 apps:
1st App: Safari
2nd App: Folder
3rd app: Settings
![Apps on the I-Pad](Skizzen/01_apps.png)

### Safari: 3 games
Safari opens automatically, and then you have the option to play three different games. This is to ease the tension at the beginning.

How do the children choose a game?
Three fields appear on the floor, which is for the selection of the desired game. The fields on the floor should be the same size as the "game fields" on the screen. Whichever field has more users inside, that game is selected. 

Overview of the 3 different games:
1st game: Rock-Scissor-Paper
2nd game: Tic-Tac-Toe
3rd game: Memory

![Open Apps](Skizzen/02_apps_oeffnen.png)

### Opening an app
In this example, we open the game Tic-Tac-Toe and the children can play one round of the respective game to the end.
![Tic Tac Toe](Skizzen/03_ticTacToe.png)

### Question to continue playing
After the end of the game, a box will appear above the game where the question will come: "Do you want to continue?". Here, two squares will appear on the floor, with the squares being the same size as the buttons on the screen to select "Yes" or "No".
Here again, the children choose whether they want to select "Yes" or "No" by climbing on one of the respective fields.
What the children don't know, however, is that no matter whether "Yes" or "No" is selected, when each button is clicked, the hacker attack will be sent in any case - so it doesn't really matter whether the children click on "Yes" or "No".
![Question](Skizzen/04_question.png)

### Pop-up attack
Suddenly, loud flickering pop-ups appear, and the children immediately notice that something is wrong. Various random memes are to be displayed on the pop-ups.
![Question](Skizzen/05_popUp.png)

### Boom
After numerous random memes appeared and disappeared on the screen, the entire DeepSpace finally goes black, and at the same time, you hear a 'Boom.' This is meant to symbolize the 'shutdown' of DeepSpace or represent the complete takeover by the hacker.
![Boom](Skizzen/06_boom.png)

### You've Been Hacked
In the next moment, the entire DeepSpace will turn red, and at the same time, everything will beep. On the front of the screen, the message 'You've been Hacked!' will be displayed (+ skull).
![You've been hacked!](Skizzen/07_hacked.png)

### Inizialising each Player
Timer: 1 Minute 

Before the game starts, for each player will appear a block with footsteps on the floor. Everyone should find a block and step inside one. As soon as all blocks are stepped on, each player will be inizialised and therefore scaned via face id.
For the game, each player will be included in one of the four teams. Each row forms a team.
![Inizialising each Player](Skizzen/11_face-scan.png)

### Game On The Floor 
Timer: 3 Minutes
Viruses: 300 (for 20 people, each person we say collects 5 viruses 3 times)

Then red "viruses" with skulls pop up mainly on the floor. Some viruses might appear in the air, if a player then stands under one, the virus will be "destroyed", drop on the floor and will automatically be collected by the player. In each corner of the DeepSpace a container with a different color for each team appears.
Each player has now a crate in their teamcolor under their feet to collect a maximum of 5 red viruses by standing on them before dumping them into their team container by standing on top of it. Each crate should have a small counter that goes up to 5 to show the player when he has to dump the viruses into his team container (Display: 0/5, 1/5, etc.). 
By dumping the collected viruses the own player's crate clears itself, the capacity is now back to 0/5 and you can collect even more viruses. 
If the player's crate is full (5/5) and he runs into another virus, all collected viruses of his create will be set free again.
![Floor Game](Skizzen/12_floor-game.png) 


#### Evaluation
As soon as all viruses are collected or the timer stopps, a graph shows which team "cleared" the most viruses by collecting them and putting them into their team container.
![Evaluation](Skizzen/13_evaluation.png) 

#### Animation & Encrypting Viruses
Now we can see every container (from each team). Those will be put together into a bigger container which the people now have to encrypt.
For this a random anagram will be generated, displayed on the screen and the people have to order the letters in order to generate a password and encrypt the container with the viruses inside. The difficulty here is to find the correct word from the anagram.
If the word was found, the container is now "hackerproof".
![Animation + Encrypting](Skizzen/14_anagram.png)

### Succes - DeepSpace is virusfree
So the DeepSpace has been freed from the hacker viruses! Now the entire room turns blue, and "SUCCES" is displayed in large letters on the front of the screen. In addition, a certain "success sound" is to sound and a group photo (made when scanning each player via face id) will be displayed to all of the people.
![Success](Skizzen/10_success.png)

## 3. Risk Analysis
### Opportunities

- Teaching children a future-oriented approach to the internet and social media in a playful manner.
- Maintaining cooperation with the AEC.
- The project remains within the AEC DeepSpace - support for both HTL Leonding and AEC due to the cooperation.

### Project Risks

- Complications in the complex and new environment (Unity, etc.).
  - Unity Version
- Incorrect estimation of time requirements (time management).
- Complications in collaboration with the AEC/DeepSpace.

## 4. Project Workflow

### 4.1 Framework

#### Personnel

- Clear role distribution.
- Clean code.
- Democracy.
  - Consensus on decisions among team members.
  - Mutual support.
- Thorough documentation.
  - Git commits.
  - Versions.
  - Bug fixes.

#### Financial

- The tools we use should be freely available to us.
- Possibly: financial support/private contributions.

### 4.2 Development Environment

#### Environment

- GitHub.
- Unity.
- Visual Studio 2022.

### 4.3 Project Implementation Milestones

#### Winter Semester

- Approval of the project proposal.
- Task allocation (who does what?).
- Familiarization with Horizon.
- "First-Guide-In" into the app.
- Website design (wireframe).
  - Demo with test data.
- Creating the database and importing test data.

#### Summer Semester

- Web server.
- Interfaces between the components.
