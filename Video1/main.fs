require SDL2/SDL.fs

0 CONSTANT NULL
s\" Open Window\0" DROP CONSTANT WINDOW_TITLE
800 CONSTANT SCREEN_WIDTH
600 CONSTANT SCREEN_HEIGHT
SDL_INIT_EVERYTHING CONSTANT sdl-flags

0 VALUE exit-value
NULL VALUE window
NULL VALUE renderer

: game-cleanup ( -- )
    renderer SDL_DestroyRenderer
    NULL TO renderer
    window SDL_DestroyWindow
    NULL TO window

    SDL_Quit
    exit-value (BYE)
;

: c-str-len ( c-addr -- c-addr u ) 0 BEGIN 2DUP + C@ WHILE 1+ REPEAT ;

: error ( c-addr u -- )
    stderr write-file
    SDL_GetError c-str-len stderr write-file
    s\" \n" stderr write-file
    1 TO exit-value
    game-cleanup
;

: initialize-sdl ( -- )
    sdl-flags SDL_Init IF
        S" Error initializing SDL: " error
    THEN

    WINDOW_TITLE SDL_WINDOWPOS_CENTERED SDL_WINDOWPOS_CENTERED SCREEN_WIDTH SCREEN_HEIGHT 0
    SDL_CreateWindow TO window
    window 0= IF 
        S" Error creating Window: " error
    THEN

    window -1 0 SDL_CreateRenderer TO renderer
    renderer 0= IF
        S" Error creating Renderer: " error
    THEN
;

: game-loop ( -- )
    renderer SDL_RenderClear DROP
        
    renderer SDL_RenderPresent

    5000 SDL_Delay

    game-cleanup
;

: play-game ( -- )
    initialize-sdl
    game-loop
;

play-game
