---
title: Complexity
---

# Complexity
### 06/05/21

Move generation is the biggest challenge to making chess work. The AI spends most of its time generating moves, so the loop needs to be as fast and efficient as possible. It can be surprisingly complicated, mostly due to three special moves: castling, en passant, and pawn promotion. As soon as you think you've got a good design, suddenly you remember you have to handle those moves too. Then, it's back to the drawing board. Speaking of:

## Representation

Previously I've gone with a piece array implementation. This time I've decided to go with a collection of `Square` objects containing their piece state. This is actually a critical choice, as instead of pre-generating moves on each position for the AI, I'm attempting to use `IEnumerable` state machines. Moving pieces will change the states of the squares, but not the board array itself, allowing the state machine to avoid any mutation problems. This should make it extremely memory efficient.

That's the hope anyways.
