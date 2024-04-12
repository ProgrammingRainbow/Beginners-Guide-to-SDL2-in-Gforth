require SDL2/SDL.fs
require SDL2/SDL_image.fs

0 CONSTANT NULL
s\" Background\0" DROP CONSTANT WINDOW_TITLE
800 CONSTANT WINDOW_WIDTH
600 CONSTANT WINDOW_HEIGHT
SDL_INIT_EVERYTHING CONSTANT SDL_FLAGS
IMG_INIT_PNG CONSTANT IMG_FLAGS

0 VALUE exit-value
NULL VALUE window
NULL VALUE renderer
CREATE event SDL_Event ALLOT
NULL VALUE background

: game-cleanup ( -- )
    background SDL_DestroyTexture
    NULL TO background
    renderer SDL_DestroyRenderer
    NULL TO renderer
    window SDL_DestroyWindow
    NULL TO window

    IMG_Quit
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
    SDL_FLAGS SDL_Init IF
        S" Error initializing SDL: " error
    THEN

    IMG_FLAGS IMG_Init img-flags AND img-flags <> IF
        S" Error initializing SDL_image: " error
    THEN

    WINDOW_TITLE SDL_WINDOWPOS_CENTERED SDL_WINDOWPOS_CENTERED WINDOW_WIDTH WINDOW_HEIGHT 0
    SDL_CreateWindow TO window
    window 0= IF 
        S" Error creating Window: " error
    THEN

    window -1 0 SDL_CreateRenderer TO renderer
    renderer 0= IF
        S" Error creating Renderer: " error
    THEN
;

: load-media ( -- )
    renderer S\" images/background.png\0" DROP IMG_LoadTexture TO background
    background 0= IF
        S" Error loading Texture: " error
    THEN
;

: game-loop ( -- )
    BEGIN
        BEGIN event SDL_PollEvent WHILE
            event SDL_Event-type L@
            DUP SDL_QUIT_ENUM = IF
                game-cleanup
            THEN
            SDL_KEYDOWN = IF event SDL_KeyboardEvent-keysym L@
                SDL_SCANCODE_ESCAPE = IF
                    game-cleanup
                THEN
            THEN
        REPEAT

        renderer SDL_RenderClear DROP
        
        renderer background NULL NULL SDL_RenderCopy DROP

        renderer SDL_RenderPresent

        16 SDL_Delay

    FALSE UNTIL
;

: play-game ( -- )
    initialize-sdl
    load-media
    game-loop
;

play-game
