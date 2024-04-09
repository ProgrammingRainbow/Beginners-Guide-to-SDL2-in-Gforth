\ ----===< prefix >===-----
c-library sdl_guid
s" SDL2" add-lib
\c #include <SDL2/SDL_guid.h>

\ -------===< structs >===--------

\ SDL_GUID
begin-structure SDL_GUID
	16 c-uint8s:    SDL_GUID-data
end-structure

\ ------===< functions >===-------
\ c-function SDL_GUIDToString SDL_GUIDToString a{*(SDL_GUID*)} a n -- void	( guid pszGUID cbGUID -- )
\ c-function SDL_GUIDFromString SDL_GUIDFromString a -- struct	( pchGUID -- )

\ ----===< postfix >===-----
end-c-library
