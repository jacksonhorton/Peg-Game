# CS352-Group-Assignment
* Names: William Hayes & Jackson Horton
* Date: 4/4/2023

## Purpose


## Compilation Instructions


## Features


## Notes
* We added strategy pattern for the valid move checking algorithm. We figured this would make things easier when we add multiple board shapes, because
differently shaped boards will require different algorithms for checking valid moves. So, we can just use a strategy pattern to create and use these
different algorithms at runtime.
* We added a factory method pattern for the creation of buttons for the program. We noticed that we were not only using a lot of buttons but in most cases we were repeatedly
using the same kind of buttons. Therefore we decided to use a factory method to maintain the priniciples of DRY and to make it easier to set up the interfaces for multiple boards
or screens.
