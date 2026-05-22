# Cashier Mania

<p align="center">
  <img src="Assets/Sprites/Logo.png" width="300">
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

Project mainly developed by the team leader, members are contributors:

**Zarif**

**Den**

**Ralph**

**Faizi**

**Faqhry**

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

---

## License

MIT License

Copyright (c) 2026 madr3p

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
