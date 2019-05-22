##libraries used for the game
import random
import msvcrt
import time

##global variables
height = 0
width = 0
snakeBody = [(0,0)]

##directions, to go up you need to subtract
DIR = (0,0)
UP = (-1,0)
DOWN = (1,0)
RIGHT = (0, 1)
LEFT = (0,-1)

##the apple's location
location = (0,0)

##this is for displaying the objects in the game
EMPTY = 0
HEAD = 1
BODY = 2
APPLE = 3

DISPLAY_CHAR = {
    EMPTY: " ",
    HEAD: "X",
    BODY: "0",
    APPLE: "*",
}

##Used to compare with user input
INPUT_CHAR_UP = "W"
INPUT_CHAR_DOWN = "S"
INPUT_CHAR_LEFT = "A"
INPUT_CHAR_RIGHT = "D"

##function that initializes the game. Takes two parameters h and w, which represent height and width of game space.
def initGame(h, w) :
    global height
    global width
    global UP
    height = h
    width = w
    initSnake(UP)

##initializes the snake with a list of coordinates body and a direction dire
def initSnake(dire) :
    global DIR
    DIR = dire

##makes snake take a step
def takeStep(position) :
    global snakeBody
    temp = snakeBody[:]
    for y in range(len(snakeBody)) :
        if y == len(snakeBody)-1 :
            snakeBody[y] = ((snakeBody[y][0] + position[0]) % height), ((snakeBody[y][1] + position[1]) % width)
        else :
            snakeBody[y] = ((temp[y+1][0]) % height), ((temp[y+1][1]) % width)

##extends the snake's body
def extendBody(position) :
    global snakeBody
    snakeBody.append(position)

##accepts a direction argument, and sets the argument as the snake’s direction
def setDirection(dire) :
    global DIR
    DIR = dire

##returns the position of the front of the snake’s body
def head() :
    global snakeBody
    return snakeBody[-1]

##function that initializes the apple location
def initApple(loc) :
    global location
    location = loc

##function that gives apple location
def appleLocation() :
    while True:
        apple_loc = (random.randint(0, height-1), random.randint(0, width-1))
        if apple_loc not in snakeBody:
            break
    initApple(apple_loc)

##calculates the next move for the snake
def next_position(position, step):
        return (
            (position[0] + step[0]) % height,
            (position[1] + step[1]) % width
        )

##function creates the board for the game
def gameBoard() :
    g_board = [[DISPLAY_CHAR[EMPTY] for _ in range(width)] for _ in range(height)]

    #used to store snake's body in board
    for y in range(len(snakeBody)) :
        g_board[snakeBody[y][0]][snakeBody[y][1]] = DISPLAY_CHAR[BODY]

    #used to store snake's head in board
    h = head()
    g_board[h[0]][h[1]] = DISPLAY_CHAR[HEAD]

    ##used to store apple in board
    g_board[location[0]][location[1]] = DISPLAY_CHAR[APPLE]

    return g_board

##function used to render the game
def gameRender() :
    board = gameBoard()

    top_and_bottom_border = "+" + "-" * width + "+"
    print(top_and_bottom_border)

    for x in range(height) :
        line = "|"
        for y in range(width) :
            line += board[x][y]
        line += "|"
        print(line)
    print (top_and_bottom_border)

##function that allows the user to play the game
def play_game() :
    appleLocation()
    gameRender()
    while True :

        #wait half a second
        time.sleep(0.3)

        ##this handles user input and assignes the new direction to the snake
        u_in = kbfunc()
        user_input = ""
        if u_in != False :
            user_input = u_in.decode().upper()
        if user_input == INPUT_CHAR_UP and DIR != DOWN :
            setDirection(UP)
        elif user_input == INPUT_CHAR_DOWN and DIR != UP :
            setDirection(DOWN)
        elif user_input == INPUT_CHAR_RIGHT and DIR != LEFT :
            setDirection(RIGHT)
        elif user_input == INPUT_CHAR_LEFT and DIR != RIGHT :
            setDirection(LEFT)
        
        #checks whether snake crashed into itself
        new_position = next_position(head(),DIR)
        if new_position in snakeBody :
            break

        ##chacks whether the snake ate the apple
        if new_position == location :
            extendBody(new_position)
            appleLocation()

        takeStep(DIR)

        gameRender()

##function to listen to key press
def kbfunc():
    #this is boolean for whether the keyboard has bene hit
    x = msvcrt.kbhit()
    if x:
        #getch acquires the character encoded in binary ASCII
        ret = msvcrt.getch()
    else:
        ret = False
    return ret

if __name__== "__main__":
    initGame(10, 20)
    play_game()
    