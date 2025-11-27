# 🏴‍☠️ Pirate Adventure

A thrilling 2D pirate-themed platformer built in Unity.  Embark on an epic journey across mysterious islands, battle dangerous enemies, and discover hidden treasures in this action-packed adventure game.


## 🎮 Game Features

### Core Gameplay
- 🏃 **Platforming Action**: Navigate through challenging island terrain with smooth character movement
- ⚔️ **Combat System**: Fight against various enemy types with engaging combat mechanics
- 💰 **Treasure Collection**: Collect gold and silver coins scattered throughout the levels
- 🗺️ **Multiple Levels**: Explore diverse environments across different scenes
- 🎯 **Interactive Objects**: Discover and interact with various in-game elements

### Game Mechanics
- **Character Movement**: Responsive controls with keyboard (WASD/Arrow keys) and gamepad support
- **Jumping**: Smooth jump mechanics with Space bar or gamepad button
- **Enemy AI**: Various enemy types with different behaviors
- **Collectibles**: Gold coins and silver coins to gather
- **Layer-Based Physics**: Optimized collision detection system
- **Audio System**: Immersive sound effects for actions and interactions

## 🛠️ Built With

- **Engine**: Unity (2D Template)
- **Language**: C# 100%
- **Input System**: Unity New Input System
- **Physics**: Unity 2D Physics Engine
- **Audio**: Unity Audio System

## 📋 Prerequisites

To run or modify this project, you need:

- Unity Editor (Version matching the project - check ProjectVersion.txt)
- Basic knowledge of Unity 2D development
- C# programming knowledge (for modifications)

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/mirce085/Pirate-Adventure.git
cd Pirate-Adventure
```

### 2. Open in Unity

1. Open Unity Hub
2. Click "Add" and select the cloned project folder
3. Unity will automatically import all assets and dependencies
4. Wait for the project to load and compile

### 3. Run the Game

1. Open the **MainMenuScene** in `Assets/Scenes/`
2. Click the Play button in the Unity Editor
3. Use keyboard or gamepad controls to play

## 🎮 Controls

### Keyboard
- **Movement**: Arrow Keys or WASD
- **Jump**: Space Bar
- **Attack/Action**: Left Ctrl or Mouse Left Click
- **Interact**: E (if applicable)

### Gamepad
- **Movement**: Left Analog Stick
- **Jump**: A Button (Xbox) / X Button (PlayStation)
- **Attack**: Various buttons mapped in Input Manager

## 📁 Project Structure

```
Pirate-Adventure/
├── Assets/
│   ├── Scenes/          # Game scenes
│   │   ├── MainMenuScene.unity
│   │   ├── Scene1.unity
│   │   ├── Scene2.unity
│   │   └── Hud.unity
│   ├── Scripts/         # C# game scripts
│   ├── Sprites/         # 2D graphics and animations
│   ├── Prefabs/         # Reusable game objects
│   ├── Audio/           # Sound effects and music
│   └── Materials/       # Materials and shaders
├── Packages/            # Unity packages
├── ProjectSettings/     # Unity project configuration
└── . gitignore
```

## 🎯 Game Systems

### Scene Management
- **MainMenuScene**: Main menu and game start
- **Scene1**: First level/island
- **Scene2**: Second level/island
- **Hud**: Heads-up display for game UI

### Tags & Layers
- **Tags**: GoldCoin, SilverCoin, Enemy, Interactable, SfxAudioSource
- **Layers**: 
  - Ground (collision layer)
  - Hero (player layer)
  - Enemies (enemy layer)
  - Collectables (pickup items)
  - Interactables (interactive objects)
  - CollidableEnemies (enemy collision)

### Collision System
The game uses Unity's layer-based collision system for optimized physics interactions between:
- Player and ground
- Player and enemies
- Player and collectibles
- Enemy and environment interactions

## 🎨 Visual Elements

- **Sorting Layers**:
  - Default
  - Level (background and environment)
  - Hero (player character on top)

## 🔊 Audio System

- Sound effects triggered by player actions
- Enemy audio feedback
- Collectible pickup sounds
- Ambient environment audio

## 🚧 Future Enhancements

- [ ] Additional levels and islands
- [ ] More enemy types and boss battles
- [ ] Power-ups and special abilities
- [ ] Achievement system
- [ ] Leaderboard integration
- [ ] Mobile platform optimization
- [ ] Multiplayer co-op mode
- [ ] Save/Load game system
- [ ] Shop for upgrades and cosmetics

## 🎓 Learning Resources

This project demonstrates:
- Unity 2D game development
- Character controller implementation
- Enemy AI programming
- Collision detection and physics
- Scene management
- UI/HUD implementation
- Audio integration
- Input handling (keyboard + gamepad)

## 🤝 Contributing

Contributions are welcome! If you'd like to improve the game:

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 Development Notes

- The project uses Unity's New Input System for better input handling
- Layer-based collision detection improves performance
- Modular scene design allows for easy level expansion
- Audio sources are tagged for easy management

## 📧 Contact

**Developer**: [mirce085](https://github.com/mirce085)

For questions, suggestions, or bug reports, please open an issue on GitHub.

## 📄 License

This project is maintained by mirce085.  Please check the repository for license information. 

---

⚓ **Set sail for adventure!  Happy treasure hunting!** 🏴‍☠️💎

Built with ❤️ using Unity and C#
