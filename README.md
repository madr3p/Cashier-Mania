# Cashier Mania

<p align="center">
  <img src="Assets/Images/logo.png" width="300">
</p>

## About The Project

**Cashier Mania** is a Windows-based 2D cashier simulation game developed in Unity by **NorthBorneo**.

Players take the role of a grocery store cashier and must handle customer transactions by interacting with draggable items, scanning products, calculating totals, and giving the correct balance. The gameplay focuses on speed, attention, and accuracy while handling customers under pressure.

The project is currently in active development and serves as a diploma-level game development project.

---

## Project Information

**Project Title:** Cashier Mania  
**Studio:** NorthBorneo  
**Status:** 🚧 In Development  
**Platform:** Windows  
**Engine:** Unity  

Project mainly developed by the team leader:

**Madrep / Zarif**

---

## Core Gameplay

Current gameplay loop:

```text
Customer arrives
↓
Random items spawn
↓
Player drags items
↓
Player scans items
↓
Total is calculated
↓
Customer pays
↓
Player gives balance manually
↓
System validates
↓
Next customer
```

Future gameplay flow may change as development progresses.

---

## Current Features

### Implemented Systems

✅ Customer spawning system

✅ Random item generation

✅ Drag & drop item interaction

✅ Scanner system

✅ Automatic total calculation

✅ Manual balance giving system

✅ Cursor state system

✅ Main menu

✅ Options menu

✅ Credits scene

---

## Cursor System

Cashier Mania currently includes multiple cursor interaction states:

| Cursor | Function |
|----------|----------|
| Pointer | Default cursor |
| Hand Point | Hovering over interactable elements |
| Hand Open | Reserved for grab interactions |
| Hand Closed | Grabbing/clicking objects |
| Loading | Scene transitions/loading |

---

## Technologies Used

- Unity Game Engine
- C#
- Visual Studio
- GitHub

---

## Project Structure

```text
Cashier Mania
│
├── Assets
│   ├── Scripts
│   │   ├── Managers
│   │   ├── UI
│   │   ├── Mechanics
│   │   └── Systems
│   │
│   ├── Prefabs
│   ├── Scenes
│   ├── Audio
│   └── Resources
│
├── ProjectSettings
└── Packages
```

---

## Future Plans

Planned features for future development:

- Difficulty system
    - Easy
    - Normal
    - Hard

- Life system

- Score system

- Win/Lose conditions

- Better customer behavior

- Sound effects and feedback system

- More item variations

- Improved UI animations

- Better customer flow logic

- Improved balancing system

- More polished interactions

- Gameplay optimization

- Visual improvements

---

## Current Development Notes

The project is still under active development.

Some systems currently act as temporary implementations and may change significantly in future versions as mechanics become more refined.

---

## Screenshots

Coming soon.

---

## Controls

| Action | Input |
|----------|----------|
| Drag item | Left Mouse |
| Scan item | Drag item to scanner |
| Give money | Left Mouse |
| Navigate UI | Mouse |

---

## Development Team

**NorthBorneo**

Main development contribution led by:

**Madrep / Zarif**

---

## License

This project is currently intended for educational purposes and internal project use.
