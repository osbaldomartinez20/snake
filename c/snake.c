//libraries to be used by the prgram
#include <stdio.h> 
#include <stdlib.h> 
#include <time.h>

//global variables useed by the game
int height = 0;
int width = 0;

//function that initializes the game. Takes two parameters h and w, which represent height and width of game space.
void gameInit(int h, int w) {
    height = h;
    width = w;
}

//function creates the board for the game
char** gameBoard() {
    return NULL;
}

//function used to render the game
void gameRender() {
    printf("Height: %i Width: %i", height, width);
}

int main() {
    gameInit(10, 20);
    gameRender();
    return 0;
}