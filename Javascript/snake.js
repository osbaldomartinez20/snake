//global variables that will be used in the game
//these are used to set the size of the board 
var HEIGHT = 10;
var WIDTH = 20;

//variables used for the location of game objects
var SNAKE_HEAD = [];
var SNAKE_BODY = [HEIGHT / 2, WIDTH / 2];
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