# CS352-Group-Assignment
Names: William Hayes & Jackson Horton

Date: 4/4/2023

# Purpose


# Compilation Instructions
Open the solution file in Visual Studio 2022 and build the solution. The game will run automatically.

# Features
* A move checker that knows how pieces can be moved on a board and can validate moves for a given board.
* An undo button allows the player to undo moves all the way back to the first move. A user can undo moves until the game is over.
* A multiscreen interface for interacting with the game that feels cohesive. The information and style displayed is consistent across the entire game application.
* A move highlighter. When a peg is clicked, any possible moves are highlighted to help the player visualize their possible moves.
* The game over screen displays the score and a quip based on the value of their score. It really encourages the player to do better.

# Design Decisions and Notes
* We added strategy pattern for the valid move checking algorithm. We figured this would make things easier when we add multiple board shapes, because
differently shaped boards will require different algorithms for checking valid moves. So, we can just use a strategy pattern to create and use these
different algorithms at runtime.
* We added a factory method pattern for the creation of buttons for the program. We noticed that we were not only using a lot of buttons but in most cases we were repeatedly
using the same kind of buttons. Therefore we decided to use a factory method to maintain the priniciples of DRY and to make it easier to set up the interfaces for multiple boards
or screens.
* There are different XAML files/window classes for each screen. Most elements of each screen are generated programatically in other classes and added to the window. This makes adding extra features, like a new board, easier because the developer has to work less on the visual elements and can focus all their attention to the backend.
