CreationalPatterns — Agent Notes
=================================

Date: 2025-10-12

Purpose: This file is a quick summary of the projects in your CreationalPatterns workspace, what patterns are being learned, what is correct/missing, and short reminders for next steps. I (the agent) created this; use it as a reference within the chat.

Important ground rule (learning mode): This is a learning project. The agent should avoid writing code or editing files unless the user explicitly asks for it. Prefer brief guidance, design pointers, and small diffs only when requested.

Projects (quick overview)
-------------------------

1) Builder/
- File: `Builder/Program.cs`
- What’s there: A simple Enemy builder + EnemyDirector example.
- Learned: Builder and Director roles, step-by-step construction, Reset and Get/Build flow.
- Improvements: Fluent API, validation during Build, immutable Enemy (record or init-only), expose a `Build()` method and hide Reset.

2) Factory/ (removed)
- Status: This project was deleted by the user. The `Factory/` folder no longer exists in the repo.
- Impact: No Factory example right now; if you want a short example (Simple/FactoryMethod), we can add it under another project on demand.

3) Prototype/
- File: `Prototype/Program.cs`
- What’s there: Rectangle class and Clone() using MemberwiseClone.
- Learned: Prototype pattern (shallow clone), how MemberwiseClone behaves.
- Improvements: Add a deep clone example (nested objects), define an ICloneable-like interface, performance notes.

4) PrototypeRegister/
- Location: `PrototypeRegister/`
- What’s there: Weapon abstract + Sword/Bow/Staff concretes, WeaponRegister mapping name->prototype and returning Clone.
- Learned: Prototype registry pattern, encapsulating clone usage, runtime alternative to instantiation.
- Improvements: Register API (Add/Remove), thread-safety, serialize/deserialize examples, combine with factory via metadata.

General assessment — where you are
----------------------------------
- Solid start: You built practical examples for Builder and Prototype. PrototypeRegister shows a registry approach used in real-world systems.
- Missing: A Factory example is currently absent. We discussed Visitor/Export and PdfBuilder, but within CreationalPatterns the Factory piece is not materialized yet.
- Architecture note: We discussed using Visitor in Domain/Reporting; CreationalPatterns here focuses on creation patterns — good separation.

Short reminders (context)
-------------------------
- Builder: Focus on "how to construct" — let the Director apply presets; Builder should return an immutable object from Build.
- Prototype: MemberwiseClone yields a shallow copy; for nested references, deep copy may be needed.
- PrototypeRegister: Retrieve registered prototypes via Clone(); extend the register through a clean API.
- Factory: Missing — if you want, I can prep small tasks for Simple/FactoryMethod/AbstractFactory trio.

Next steps / suggested small tasks (5–60 mins)
-----------------------------------------------
1) (20–40m) In `Builder/`, make Enemy immutable with `record` or `init`, and update the builder to a fluent API.
2) (20–40m) In `Prototype/`, add a deep clone example (e.g., Rectangle with Point[] or a nested object) and demonstrate the difference.
3) (30–60m) In `PrototypeRegister/`, add a Register API and thread-safety (lock); optional: load the register from JSON.
4) (optional) Instead of a heavy `PdfBuilder/`, use a lighter Markdown/HTML builder to illustrate the pattern.

Notes for the agent
-------------------
- This file is created for the assistant’s own reference. Keep answers concise. Do not create or edit code unless explicitly asked by the user. When in doubt, ask before changing files.

How to continue?
----------------
- Do you want me to prepare one small task right now? (e.g., a SimpleFactory under a new folder, only if you request it.)
- Or tell me which one you want to do first, and I’ll outline a short, targeted patch plan — without making changes until you confirm.

