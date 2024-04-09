require SDL2/SDL.fs
require SDL2/SDL_image.fs
require SDL2/SDL_ttf.fs
require random.fs

0 CONSTANT NULL
s\" Moving Text\0" DROP CONSTANT WINDOW_TITLE
800 CONSTANT SCREEN_WIDTH
600 CONSTANT SCREEN_HEIGHT
SDL_INIT_EVERYTHING CONSTANT sdl-flags
IMG_INIT_PNG CONSTANT img-flags
80 CONSTANT TEXT_SIZE
3 CONSTANT TEXT_VEL

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

: game-cleanup ( -- )
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
    sdl-flags SDL_Init IF
        S" Error initializing SDL: " error
    THEN

    img-flags IMG_Init img-flags AND img-flags <> IF
        S" Error initializing SDL_image: " error
    THEN

    TTF_Init IF
        S" Error initializing SDL_ttf: " error
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

    utime DROP seed ! rnd DROP

    S\" images/Gforth-logo.png\0" DROP IMG_Load DUP 0= IF
        S" Error loading Surface: " error
    THEN
    window OVER SDL_SetWindowIcon
    SDL_FreeSurface
;

: load-media ( -- )
    renderer S\" images/background.png\0" DROP IMG_LoadTexture TO background
    background 0= IF
        S" Error loading Texture: " error
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
    text-rect SDL_Rect-w SL@ + SCREEN_WIDTH > IF
        TEXT_VEL NEGATE TO text-xvel
    THEN

    text-rect SDL_Rect-y DUP SL@ text-yvel + DUP ROT L!
    DUP 0 < IF
        TEXT_VEL TO text-yvel
    THEN
    text-rect SDL_Rect-h SL@ + SCREEN_HEIGHT > IF
        TEXT_VEL NEGATE TO text-yvel
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
                DUP SDL_SCANCODE_ESCAPE = IF
                    game-cleanup
                THEN
                SDL_SCANCODE_SPACE = IF
                    random-color-renderer
                THEN
            THEN
        REPEAT

        update-text
        
        renderer SDL_RenderClear DROP
        
        renderer background NULL NULL SDL_RenderCopy DROP
        renderer text-image NULL text-rect SDL_RenderCopy DROP

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
