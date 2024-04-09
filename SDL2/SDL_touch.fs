\ ----===< prefix >===-----
c-library sdl_touch
s" SDL2" add-lib
\c #include <SDL2/SDL_touch.h>

\ --------===< enums >===---------
#-1	constant SDL_TOUCH_DEVICE_INVALID
#0	constant SDL_TOUCH_DEVICE_DIRECT
#1	constant SDL_TOUCH_DEVICE_INDIRECT_ABSOLUTE
#2	constant SDL_TOUCH_DEVICE_INDIRECT_RELATIVE

\ -------===< structs >===--------

\ struct SDL_Finger
begin-structure SDL_Finger
	c-sint64:   SDL_Finger-id
	c-float:    SDL_Finger-x
	c-float:    SDL_Finger-y
	c-float:    SDL_Finger-pressure
	c-uint32:	SDL_Finger-padding
end-structure

\ ------===< functions >===-------
c-function SDL_GetNumTouchDevices SDL_GetNumTouchDevices  -- n	( -- )
c-function SDL_GetTouchDevice SDL_GetTouchDevice n -- n	( index -- )
c-function SDL_GetTouchName SDL_GetTouchName n -- a	( index -- )
c-function SDL_GetTouchDeviceType SDL_GetTouchDeviceType n -- n	( touchID -- )
c-function SDL_GetNumTouchFingers SDL_GetNumTouchFingers n -- n	( touchID -- )
c-function SDL_GetTouchFinger SDL_GetTouchFinger n n -- a	( touchID index -- )

\ ----===< postfix >===-----
end-c-library
