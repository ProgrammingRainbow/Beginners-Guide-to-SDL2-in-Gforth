# An in-depth guide to getting started with SDL2 in the Forth Language
![Screenshot](screenshot.png)

# SDL2 Bindings for Gforth
A complete set of bindings for `SDL2`, `SDL_image`, `SDL_mixer`, and `SDL_ttf`. Note that these are simply the SDL2 Gforth bindings. SDL2 with headerfiles needs to be installed and added to your library and include paths. For example on ArchLinux simply installing sdl2, sdl2_image, sdl2_mixer, sdl2_ttf packages and Gforth 0.7.3 are all you need. Again these are only bindings so you will need to have Gforth and SDL2 with headerfiles installed and in your systems searchable path. This is assuming SDL2 is in the standard SDL2 folder. If you just want the bindings for your own project, the SDL2 folder here is all you need, the rest is for the examples.

## SDL Event Enum name collisions.
Because Forth is not case-sensitive, there are some naming collisions with the Event Enums. For example, the function `SDL_Quit` and the Event Enum `SDL_QUIT` are viewed as the same. For the 6 Event Enums, _ENUM has been added to their names. The `SDL_Quit` function will still close SDL, but for checking if an `SDL_QUIT` event has occurred, `SDL_QUIT_ENUM` is used.
```forth
SDL_QUIT_ENUM
SDL_DISPLAYEVENT_ENUM
SDL_WINDOWEVENT_ENUM
SDL_SYSWMEVENT_ENUM
SDL_SENSORUPDATE_ENUM
SDL_USEREVENT_ENUM
```
## SDL_Color struct in SDL_ttf fuctions.
Many functions in `SDL_ttf` take an `SDL_Color` struct directly instead of a pointer to a struct. Pointers to C structs are easily passed to functions in Forth but not structs directly. There are wrapper functions so that a pointer to a struct can be passed instead. The bindings use the original `SDL_ttf` function names that point to the wrapper functions so the only change is `SDL_Color` structs are passed as pointers like all others.

## Take care storing and retrieving from SDL structs and unions.
Gforth stores numbers on a 64bit system as a 64bit two's compliment signed int. However, SDL uses different data types in their structs and unions. When storing into a struct, you must make sure to store the right number of bytes or it will overwrite the next memory blocks. However, simply using `L@` to write to 4 bytes instead of 8 will only solve part of the problem. `@L` will not cast the number but simply truncate it.
```forth
CREATE test SDL_Rect ALLOT  ok
-1 test SDL_Rect-x L!  ok
test SDL_Rect-x L@ . 4294967295  ok
```
You will need to think about the size of the data you are writing and also the type. specifically for 32bit signed int in Rects i have will use a `int32<@` and `int32>!` that will be shown below. For 1 byte events simply `C@` will work.

## Accessing members of C Structs and Unions
https://wiki.libsdl.org/SDL2/SDL_Rect \
SDL uses structs and unions that have members. An example is the `SDL_Rect` struct, which has 4 members: x, y, w, h. Each member of an `SDL_Rect` is of type 32-bit signed int. In C, `SDL_Rect myrect;` creates the variable myrect, and to access x, we would use `myrect.x`. This is just a fancy way of offsetting the address to the position of its member. The bindings in Forth will have an `SDL_Rect` for allocating the size of the struct, but it also has `SDL_Rect-x`, `SDL_Rect-y`, `SDL_Rect-w`, and `SDL_Rect-h` for use as offsets. So in Gforth, `myrect SDL_Rect-x int32<@` will put on the stack the address to the x member. As I said above, you need to constrain the fetch to only 4 bytes and convert it. Remember, all the bindings structs and unions will have the type-member to get the offset. Here is an example of a fetch and store using `int32>!` and `int32<@`.
```forth
// C SDL2 assignment and retrieve
SDL_Rect myrect;
myrect.x = 10
int getx = myrect.x

\ Forth SDL2 store and fetch
CREATE myrect SDL_Rect ALLOT
VALUE getx
10 myrect SDL_Rect-x int32>!
myrect SDL_Rect-x int32<@ TO getx
```
## C style strings.
Gforth uses a string and length pair but C requires only the string but there must be a `NULL` terminator at the end. For sending, you can simply use `s\” c string\0" DROP` but for converting back, I have also shown below `>c-str` and `c-str>` words to help out.

# How to use SDL2 Bindings.
Using the SDL2 bindings for Gforth is just as it is in C. The function names are exactly the same. All arguments are placed on the stack in the same order as the C version. The return value is placed on the stack afterward. All the SDL2 Constants and Enums are included. NULL is simply 0, below I will create a CONSTANT for convenience. Below is an example.

C version from https://wiki.libsdl.org/SDL2/SDL_CreateWindow
```c
// SDL_Window * SDL_CreateWindow(const char *title, int x, int y, int w, int h, Uint32 flags);
SDL_Window *window = SDL_CreateWindow("Window Title", SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, 800, 600, 0);
```
Gforth version
```forth
S\"Window Title\0" DROP SDL_WINDOWPOS_CENTERED SDL_WINDOWPOS_CENTERED 800 600 0 SDL_CreateWindow TO window
```
## To help working with C and SDL2
`NULL` is used often it’s simply 0 but I have added a constant. To get strings back from SDL such as `SDL_GetError c-str>` will return a string length pair. To send strings into C functions, `>c-str` will take a string length pair and return a C style `NULL` terminated string. To convert Gforth’s 64bit signed to a 32bit size and store it in 4 bytes, `int32<!` this is used for setting `SDL_Rect` x, y, w, and h. To pull a number out, `int32<@` will put onto the stack a 64bit version.
```forth
\ Helpers for C
0 CONSTANT NULL
: c-str> ( c-str -- string u ) 0 BEGIN 2DUP + C@ WHILE 1+ REPEAT ;
: >c-str ( string u -- c-str )
    1+ DUP ALLOCATE
    DROP ROT OVER 3 PICK 1- MOVE
    DUP ROT 1- + 0 SWAP C!
;
: int32>! ( 64bit signed -- 32bit signed ) DUP 0< IF 0x100000000 + THEN L! ;
: int32<@ ( 32bit signed -- 64bit signed ) L@ DUP 0x7FFFFFFF > IF 0x100000000 - THEN ;
```
