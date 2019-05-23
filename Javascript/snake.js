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
var gameInit = function (h = 10, w = 20) {
    HEIGHT = h;
    WIDTH = w;
    snakeInit(SNAKE_HEAD, UP);
}

//initializes the snake with a coordinate coor.
var snakeInit = function (coor, dir) {
    DIRECTION = [...dir];
    SNAKE_BODY.push([...coor]);
}

//function returns the cooordinate of the snake's head
var head = function () {
    return [...SNAKE_HEAD];
}

//function gives new location for apple
var appleLocation = function () {
    while (true) {
        APPLE_LOCATION[0] = Math.floor(Math.random() * HEIGHT);
        APPLE_LOCATION[1] = Math.floor(Math.random() * WIDTH);
        if (SNAKE_BODY.indexOf(APPLE_LOCATION) < 0) {
            break;
        }
    }
}

//sets the direction
var setDirection = function (dir) {
    DIRECTION = [...dir];
}

//extends the snake's body with coordinate position
var extendBody = function (position) {
    SNAKE_BODY.push([...position]);
}

//function that calculates the new position of the snake head
var nextPosition = function (position, step) {
    var new_pos = [mod(position[0] + step[0], HEIGHT), mod(position[0] + step[0], WIDTH)];
    return new_pos;
}

//this function makes the snake take a step
var takeStep = function (position) {
    var temp = [...SNAKE_BODY];
    for (var i = 0; i < temp.length; i++) {
        if (i == temp.length-1) {
            SNAKE_BODY[i] = position;
        } else {
            SNAKE_BODY[i] = temp[i+1];
        }
    }
}





//this solves the negative mod problem
var mod = function (x, m) {
    return (x % m + m) % m;
}