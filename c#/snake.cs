using System;
using System.Collections.Generic;

namespace Snake {
    class snake {
        //global variables
        public static int HEIGHT;
        public static int WIDTH;
        public static IList<int[]> snakeBody = new List<int[]>();
        public static Random rand = new Random();

        //Directions. to go up you need to subtract because of how the coordinates work
        public static int[] DIRECTION = {0,0};
        public static int[] UP = {-1,0};
        public static int[] DOWN = {1,0};
        public static int[] RIGHT = {0,1};
        public static int[] LEFT = {0, -1};

        //apple's location
        public static int[] APPLE_LOCATION = {0,0};

        //this is to make easier to choose which charactter to display
        public static int EMPTY = 0;
        public static int HEAD = 1;
        public static int BODY = 2;
        public static int APPLE = 3;

        public static string[] DISPLAY_CHARS = {" ", "X", "0", "*"};

        //variables that will be used for input comparison
        public static string INPUT_UP = "W";
        public static string INPUT_DOWN = "S";
        public static string INPUT_RIGHT = "D";
        public static string INPUT_LEFT = "A";
        
        //function used to initialize the game
        public static void gameInit(int h, int w) {
            HEIGHT = h;
            WIDTH = w;
            sankeInit(UP);
        }

        //function used to initialize the snake
        public static void sankeInit(int[] dir) {
            snakeBody.Add(DIRECTION);
            DIRECTION = dir;
        }

        public static void appleInit(int[] dir) {
            APPLE_LOCATION = dir;
        }

        //this makes the snake move
        public static void takeStep(int[] dir) {
            IList<int[]> temp = copyList();
            for (int i = 0; i < temp.Count; i++) {
                if(i == temp.Count-1) {
                  int[]  x = {(temp[i][0] + dir[0]) % HEIGHT, (temp[i][1] + dir[1]) % WIDTH};
                  snakeBody[i] = x;
                } else {
                    int[] x = {temp[i+1][0] % HEIGHT, temp[i+1][1] % WIDTH};
                    snakeBody[i] = x;
                }
            }
        }

        //function that extends the body of the snake
        public static void extendBody(int[] position) {
            snakeBody.Add(position);
        }

        //function sets the direction in which the snake moves
        public static void setDirection(int[] dir) {
            DIRECTION = dir;
        }

        //returns the position of the headf of the snake
        public static int[] head() {
            return snakeBody[-1];
        }

        //assigns a new location for the apple
        public static void appleLocation() {
            int[] appleLoc = new int[2];
            while(true) {
                appleLoc[0] = rand.Next(0, HEIGHT-1);
                appleLoc[1] = rand.Next(0, WIDTH-1);
                if(snakeBody.IndexOf(appleLoc) < 0) {
                    break;
                }
            }
            appleInit(appleLoc);
        }

        //function that calculates the snake's new position
        public static int[] new_position(int[] position, int[] step) {
            int[] n_position = {(position[0] + step[0]) % HEIGHT, (position[1] + step[1]) % WIDTH};
            return n_position;
        }

        public static void Main(string[] args) {
            
        }

        //this copies the list and returns the copy
        public static List<int[]> copyList() {
            List<int[]> temp = new List<int[]>();
            for (int i = 0; i < snakeBody.Count; i++) {
                temp.Add(snakeBody[i]);
            }
            return temp;
        }
    }
}