require SDL2/SDL.fs
require SDL2/SDL_image.fs
require SDL2/SDL_ttf.fs
require random.fs

0 CONSTANT NULL
s\" Player Sprite\0" DROP CONSTANT WINDOW_TITLE
800 CONSTANT WINDOW_WIDTH
600 CONSTANT WINDOW_HEIGHT
SDL_INIT_EVERYTHING CONSTANT SDL_FLAGS
IMG_INIT_PNG CONSTANT IMG_FLAGS
80 CONSTANT TEXT_SIZE
3 CONSTANT TEXT_VEL
5 CONSTANT SPRITE_VEL

0 VALUE exit-value
NULL VALUE window
NULL VALUE renderer
CREATE event SDL_Event ALLOT
NULL VALUE background
NULL VALUE text-font
CREATE text-color SDL_Color ALLOT
NULL VALUE text-image
CREATE text-rect SDL_Rect ALLOT
TEXT_VEL VALUE text-xvel
TEXT_VEL VALUE text-yvel
NULL VALUE sprite-image
CREATE sprite-rect SDL_Rect ALLOT
NULL VALUE keystate

: game-cleanup ( -- )
    sprite-image SDL_DestroyTexture
    NULL TO sprite-image
    text-font TTF_CloseFont
    NULL TO text-font
    text-image SDL_DestroyTexture
    NULL TO text-image
    background SDL_DestroyTexture
    NULL TO background
    renderer SDL_DestroyRenderer
    NULL TO renderer
    window SDL_DestroyWindow
    NULL TO window

    TTF_Quit
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

    IMG_FLAGS IMG_Init IMG_FLAGS AND IMG_FLAGS <> IF
        S" Error initializing SDL_image: " error
    THEN

    TTF_Init IF
        S" Error initializing SDL_ttf: " error
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

    utime DROP seed ! rnd DROP

    S\" images/Gforth-logo.png\0" DROP IMG_Load DUP 0= IF
        S" Error loading Surface: " error
    THEN
    window OVER SDL_SetWindowIcon
    SDL_FreeSurface

    NULL SDL_GetKeyboardState TO keystate
;

: load-media ( -- )
    renderer S\" images/background.png\0" DROP IMG_LoadTexture TO background
    background 0= IF
        S" Error loading Texture: " error
    THEN

    renderer S\" images/Gforth-logo.png\0" DROP IMG_LoadTexture TO sprite-image
    sprite-image 0= IF
        S" Error loading Texture: " error
    THEN

    sprite-image NULL NULL sprite-rect SDL_Rect-w sprite-rect SDL_Rect-h SDL_QueryTexture IF
        S" Error querying Texture: " error
    THEN
;

: random-color-renderer ( -- )
    renderer 256 random 256 random 256 random 255 SDL_SetRenderDrawColor DROP
;

: create-text ( -- )
    S\" fonts/freesansbold.ttf\0" DROP TEXT_SIZE TTF_OpenFont TO text-font
    text-font 0= IF
        S" Error creating font: " error
    THEN

    text-color
    255 OVER SDL_Color-r C!
    255 OVER SDL_Color-g C!
    255 OVER SDL_Color-b C!
    255 SWAP SDL_Color-a C!

    text-font S\" SDL\0" DROP text-color TTF_RenderText_Blended DUP 0= IF
        S" Error creating font surface: " error
    THEN

    text-rect
    OVER SDL_Surface-w SL@ OVER SDL_Rect-w L!
    OVER SDL_Surface-h SL@ SWAP SDL_Rect-h L!

    renderer OVER SDL_CreateTextureFromSurface TO text-image
    SDL_FreeSurface
    text-image 0= IF
        S" Error creating texuture from file: " error
    THEN
;

: update-text ( -- )
    text-rect SDL_Rect-x DUP SL@ text-xvel + DUP ROT L!
    DUP 0 < IF
        TEXT_VEL TO text-xvel
    THEN
    text-rect SDL_Rect-w SL@ + WINDOW_WIDTH > IF
        TEXT_VEL NEGATE TO text-xvel
    THEN

    text-rect SDL_Rect-y DUP SL@ text-yvel + DUP ROT L!
    DUP 0 < IF
        TEXT_VEL TO text-yvel
    THEN
    text-rect SDL_Rect-h SL@ + WINDOW_HEIGHT > IF
        TEXT_VEL NEGATE TO text-yvel
    THEN
;

: update-sprite ( -- )
    keystate SDL_Keysym-scancode 
    DUP SDL_SCANCODE_LEFT + C@ 1 = OVER SDL_SCANCODE_A + C@ 1 = OR IF
        sprite-rect SDL_Rect-x DUP SL@ SPRITE_VEL - SWAP L!
    THEN

    DUP SDL_SCANCODE_RIGHT + C@ 1 = OVER SDL_SCANCODE_D + C@ 1 = OR IF
        sprite-rect SDL_Rect-x DUP SL@ SPRITE_VEL + SWAP L!
    THEN

    DUP SDL_SCANCODE_UP + C@ 1 = OVER SDL_SCANCODE_W + C@ 1 = OR IF
        sprite-rect SDL_Rect-y DUP SL@ SPRITE_VEL - SWAP L!
    THEN

    DUP SDL_SCANCODE_DOWN + C@ 1 = SWAP SDL_SCANCODE_S + C@ 1 = OR IF
        sprite-rect SDL_Rect-y DUP SL@ SPRITE_VEL + SWAP L!
    THEN
;

: game-loop ( -- )
    BEGIN
        BEGIN event SDL_PollEvent WHILE
            event SDL_Event-type L@
            DUP SDL_QUIT_ENUM = IF
                game-cleanup
            THEN
            SDL_KEYDOWN = IF
                event SDL_KeyboardEvent-keysym SDL_Keysym-scancode SL@
                DUP SDL_SCANCODE_ESCAPE = IF
                    game-cleanup
                THEN
                SDL_SCANCODE_SPACE = IF
                    random-color-renderer
                THEN
            THEN
        REPEAT

        update-text
        update-sprite
        
        renderer SDL_RenderClear DROP
        
        renderer background NULL NULL SDL_RenderCopy DROP
        renderer text-image NULL text-rect SDL_RenderCopy DROP
        renderer sprite-image NULL sprite-rect SDL_RenderCopy DROP

        renderer SDL_RenderPresent

        16 SDL_Delay

    FALSE UNTIL
;

: play-game ( -- )
    initialize-sdl
    load-media
    create-text
    game-loop
;

play-game
