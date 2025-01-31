# 🏰 ROG: ASCII Dungeon Crawler

**ROG** is a text-based, ASCII-styled dungeon crawler where players navigate through procedurally generated floors, collect keys, and evade various monsters while searching for the exit. Inspired by classic roguelike mechanics, the game offers turn-based movement, strategic enemy AI, and increasing difficulty across multiple levels.

---
## 👥 Team

### CPSC-370 Backend Team
- Cristian Melgoza
- Brent Matthew Ortizo
- Irene Ichwan
- Fares Alhezaimi
- Queenie Lin

## 📜 Table of Contents
- Features
- How to Play
- Installation
- Controls
- Game Mechanics
- Technologies Used
- Team
- Lessons Learned
- Future Improvements
- License

---

## 🎮 Features

- **ASCII Grid-Based Gameplay** – Navigate a dungeon floor-by-floor in a simple yet challenging world.  
- **Five Unique Dungeon Levels** – Each level increases in difficulty with different enemy layouts.  
- **Turn-Based Combat & AI** – Enemies follow unique movement patterns, requiring strategic planning.  
- **Mimic Door Trap** – A deadly fake exit on Floor 5 that deceives players.  
- **Procedural Generation** – Each playthrough provides a unique experience.  
- **Pixel Art & Thematic UI** – A mix of ASCII visuals and pixel art for a retro aesthetic.  

---

## 🏹 How to Play

1. Start the game and begin on **Floor 1**.
2. Navigate using **arrow keys** to move up, down, left, or right.
3. Collect **keys** to unlock the exit door.
4. Avoid or outmaneuver enemies – some track you, others move randomly.
5. Reach **Floor 5** and find the real exit – but beware of the **Mimic Door!**
6. Win by escaping the final dungeon.

---

## 🛠 Installation

### Prerequisites
- Windows, Linux, or MacOS (Console-based game)
- .NET 6.0+ installed
- C# compiler (`csc`)

### Clone & Run
```git clone https://github.com/your-repo/charizard.git```
```cd charizard```
```dotnet run```

## ⌨️ Controls
- Arrow Up (↑) – Move Up
- Arrow Left (←) – Move Left
- Arrow Down (↓) – Move Down
- Arrow Right (→) – Move Right

## 👾 Game Mechanics

### Enemies:
- Goblin – Moves one tile in a random direction each turn.
- Skeleton – Moves two spaces per turn, randomly choosing left or right.
- Bat – Moves side to side, reversing when hitting a wall.
- Bull – Charges in a straight line when it sees the player.
- Wraith – Uses pathfinding to teleport the player to a random location.

### Doors:
- Exit Door (D) – Unlocks when all keys are collected.
- Mimic Door (D) – A fake exit on Floor 13 that kills the player.

## 🛠 Technologies Used
- C# – Core game logic
- .NET 6.0+ – Game framework (using .NET 8.0)
- GitHub & GitKraken – Version control & collaboration
- Rider IDE – Development environment
- Trello (SCRUM) – Task management & sprint planning

## 🔥 Now, are you ready to escape the dungeon? 🏰🎮
