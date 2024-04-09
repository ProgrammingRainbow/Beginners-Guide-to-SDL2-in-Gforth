\ ----===< prefix >===-----
c-library sdl_locale
s" SDL2" add-lib
\c #include <SDL2/SDL_locale.h>

\ -------===< structs >===--------
\ struct SDL_Locale
begin-structure SDL_Locale
	c-char-ptr: SDL_Locale-country
	c-char-ptr: SDL_Locale-language
end-structure

\ ------===< functions >===-------
c-function SDL_GetPreferredLocales SDL_GetPreferredLocales  -- a	( -- )

\ ----===< postfix >===-----
end-c-library
