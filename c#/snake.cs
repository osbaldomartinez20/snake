using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Snake {
    class snake {

        //global variables
        public static int HEIGHT = 10;
        public static int WIDTH = 20;
        public static List<int[]> snakeBody = new List<int[]>();
        public static Random rand = new Random();

        //Directions. to go up you need to subtract because of how the coordinates work
        public static int[] DIRECTION = {HEIGHT/2,WIDTH/2};
        public static int[] UP = {-1,0};
        public static int[] DOWN = {1,0};
        public static int[] RIGHT = {0,1};
        public static int[] LEFT = {0,-1};

        //apple's location
        public static int[] APPLE_LOCATION = {0,0};

        public static int[] SNAKE = {HEIGHT/2,WIDTH/2};

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
        public static void gameInit() {
            sankeInit(UP);
        }

        //function used to initialize the snake
        public static void sankeInit(int[] dir) {
            snakeBody.Add(DIRECTION);
            DIRECTION = dir;
        }

        //initializes apple location
        public static void appleInit(int[] dir) {
            APPLE_LOCATION = dir;
        }

        //this makes the snake move
        public static void takeStep(int[] dir) {
            List<int[]> temp = copyList();
            for (int i = 0; i < temp.Count; i++) {
                if(i == temp.Count-1) {
                  int[]  x = {mod(dir[0],HEIGHT), mod(dir[1],WIDTH)};
                  snakeBody[i] = x;
                } else {
                    int[] x = {temp[i+1][0], temp[i+1][1]};
                    snakeBody[i] = x;
                }
            }
            SNAKE = snakeBody[snakeBody.Count-1];
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
            return SNAKE;
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
        public static int[] newPosition(int[] position, int[] step) {
            int[] n_position = {mod(position[0] + step[0],HEIGHT), mod(position[1] + step[1],WIDTH)};
            return n_position;
        }

        public static string[,] gameBoard() {
            string[,] g_board = new string[HEIGHT, WIDTH];
            for (int i = 0; i < HEIGHT; i++) {
                for (int j = 0; j < WIDTH; j++) {
                    g_board[i, j] = DISPLAY_CHARS[EMPTY];
                }
            } 

            //used to store snake's body in board
            for (int i = 0; i < snakeBody.Count; i++) {
                g_board[snakeBody[i][0], snakeBody[i][1]] = DISPLAY_CHARS[BODY];
            }

            //used to store snake's head in board
            int[] h = head();
            g_board[h[0],h[1]] = DISPLAY_CHARS[HEAD];

            //used to store apple in board
            g_board[APPLE_LOCATION[0],APPLE_LOCATION[1]] = DISPLAY_CHARS[APPLE];

            return g_board;
        }

        //function used to render the game
        public static void gameRender() {
            string[,] board = gameBoard();

            string top_bottom_borders = "+";
            for (int i = 0; i < WIDTH; i++) {
                top_bottom_borders += "-";
            }
            top_bottom_borders += "+";
            Console.WriteLine(top_bottom_borders);

            for (int i = 0; i < HEIGHT; i++) {
                string line = "|";
                for (int j = 0; j < WIDTH; j++) {
                    line += board[i,j];
                }
                line += "|";
                Console.WriteLine(line);
            }

            Console.WriteLine(top_bottom_borders);
        }

        //function allows user to play game
        public static void playGame() {
            //these method calls initialize the game
            gameInit();
            appleLocation();
            gameRender();

            //the game loop
            while (true) {
                //sleeps for n miliseconds
                System.Threading.Thread.Sleep(300);

                //user input for the game
                string u_input = "";
                if(Console.KeyAvailable == true) {
                    u_input = Convert.ToString(Console.ReadKey().Key);
                }
                if (string.Compare(u_input, INPUT_UP) == 0 && !(DOWN.SequenceEqual(DIRECTION))) {
                    setDirection(UP);
                } else if(string.Compare(u_input, INPUT_DOWN) == 0 && !(UP.SequenceEqual(DIRECTION))) {
                    setDirection(DOWN);
                } else if(string.Compare(u_input, INPUT_RIGHT) == 0 && !(LEFT.SequenceEqual(DIRECTION))) {
                    setDirection(RIGHT);
                } else if(string.Compare(u_input, INPUT_LEFT) == 0 && !(RIGHT.SequenceEqual(DIRECTION))) {
                    setDirection(LEFT);
                }

                //checks to see if snake crashed into itself
                int[] n_pos = newPosition(head(), DIRECTION); 
                if (snakeBody.IndexOf(n_pos) >= 0) {
                    Console.WriteLine("You died!");
                }

                //if apple was eaten make new apple
                if(APPLE_LOCATION.SequenceEqual(n_pos)) {
                    extendBody(n_pos);
                    appleLocation();
                }

                //take the next step
                takeStep(n_pos);

                gameRender();

            }
        }

        public static void Main(string[] args) {
            playGame();
        }

        //this copies the list and returns the copy
        public static List<int[]> copyList() {
            List<int[]> temp = new List<int[]>();
            for (int i = 0; i < snakeBody.Count; i++) {
                temp.Add(snakeBody[i]);
            }
            return temp;
        }
    
        //solves the negative mod problem
        public static int mod(int x, int m) {
            return (x%m + m)%m;
        }

    }
}