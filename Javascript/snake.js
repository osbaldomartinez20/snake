//global variables that will be used in the game
//these are used to set the size of the board 
var HEIGHT = 10;
var WIDTH = 20;

//variables used for the location of game objects
var SNAKE_HEAD = [HEIGHT / 2, WIDTH / 2];
var SNAKE_BODY = [];
var APPLE_LOCATION = [0, 0];

//variables used for direction
var DIRECTION = [0, 0];
var UP = [-1, 0];
var DOWN = [1, 0];
var RIGHT = [0, 1];
var LEFT = [0, -1];

//variables that help with displaying characters
var EMPTY = 0;
var HEAD = 1;
var BODY = 2;
var APPLE = 3;
var DISPLAY_CHARS = [" ", "X", "0", "*"];

//variables used for user input comparison
var INPUT_UP = "W";
var INPUT_DOWN = "S";
var INPUT_RIGHT = "D";
var INPUT_LEFT = "A";

//function that initializes the game with a board of height h and width w.
var gameInit = function (h=10, w=20) {
    HEIGHT = h;
    WIDTH = w;
    snakeInit(SNAKE_HEAD);
}

//initializes the snake with a coordinate coor.
var snakeInit = function (coor) {
    SNAKE_BODY.push(coor);
}

//initializes the apple with a coordinate coor.
var appleInit = function (coor) {
    APPLE_LOCATION = [...coor];
}