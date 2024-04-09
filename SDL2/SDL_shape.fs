\ ----===< prefix >===-----
c-library sdl_shape
s" SDL2" add-lib
\c #include <SDL2/SDL_shape.h>

\ ----===< int constants >===-----
#-1	constant SDL_NONSHAPEABLE_WINDOW
#-2	constant SDL_INVALID_SHAPE_ARGUMENT
#-3	constant SDL_WINDOW_LACKS_SHAPE

\ --------===< enums >===---------
#0	constant ShapeModeDefault
#1	constant ShapeModeBinarizeAlpha
#2	constant ShapeModeReverseBinarizeAlpha
#3	constant ShapeModeColorKey

\ -------===< unions >===--------

\ SDL_WindowShapeParams
begin-structure SDL_WindowShapeParams
	drop 0 SDL_Color bytes:	SDL_WindowShapeParams-colorKey
	drop 0 c-uint8:			SDL_WindowShapeParams-binarizationCutoff
end-structure

\ -------===< structs >===--------

\ struct SDL_WindowShapeMode
begin-structure SDL_WindowShapeMode
	c-enum:				SDL_WindowShapeMode-mode
	SDL_Color bytes:	SDL_WindowShapeMode-parameters
end-structure

\ ------===< functions >===-------
c-function SDL_CreateShapedWindow SDL_CreateShapedWindow a n n n n n -- a	( title x y w h flags -- )
c-function SDL_IsShapedWindow SDL_IsShapedWindow a -- n	( window -- )
c-function SDL_SetWindowShape SDL_SetWindowShape a a a -- n	( window shape shape_mode -- )
c-function SDL_GetShapedWindowMode SDL_GetShapedWindowMode a a -- n	( window shape_mode -- )

\ ----===< postfix >===-----
end-c-library
