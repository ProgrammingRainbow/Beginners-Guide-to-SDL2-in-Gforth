require SDL_stdinc.fs
require SDL_error.fs

\ ----===< prefix >===-----
c-library sdl_rwops
s" SDL2" add-lib
\c #include <SDL2/SDL_rwops.h>

\ ----===< int constants >===-----
#0	constant SDL_RWOPS_UNKNOWN
#1	constant SDL_RWOPS_WINFILE
#2	constant SDL_RWOPS_STDFILE
#3	constant SDL_RWOPS_JNIFILE
#4	constant SDL_RWOPS_MEMORY
#5	constant SDL_RWOPS_MEMORY_RO
#0	constant RW_SEEK_SET
#1	constant RW_SEEK_CUR
#2	constant RW_SEEK_END

\ -------===< structs >===--------

\ SDL_RWops_hidden_unknown
begin-structure SDL_RWops_hidden_unknown
	c-pointer:	SDL_RWops_hidden_unknown-data1
	c-pointer:	SDL_RWops_hidden_unknown-data2
end-structure

\ SDL_RWops_hidden_mem
begin-structure SDL_RWops_hidden_mem
	c-uint8-ptr:	SDL_RWops_hidden_mem-base
	c-uint8-ptr:	SDL_RWops_hidden_mem-here
	c-uint8-ptr:	SDL_RWops_hidden_mem-stop
end-structure

\ SDL_RWops_hidden
begin-structure SDL_RWops_hidden
	SDL_RWops_hidden_unknown bytes:	SDL_RWops_hidden-unknown
	SDL_RWops_hidden_mem bytes:		SDL_RWops_hidden-mem
end-structure

\ struct SDL_RWops
begin-structure SDL_RWops
	c-func-ptr:				SDL_RWops-size
	c-func-ptr:				SDL_RWops-seek
	c-func-ptr:				SDL_RWops-read
	c-func-ptr:				SDL_RWops-write
	c-func-ptr:				SDL_RWops-close
	c-uint32:				SDL_RWops-type
	c-uint32:				SDL_RWops-padding
	SDL_RWops_hidden bytes:	SDL_RWops-hidden
end-structure

\ --===< function pointers >===---
\ c-funptr SDL_RWops-size() {((struct SDL_RWops*)ptr)->size} a -- n	( context -- )
\ c-funptr SDL_RWops-seek() {((struct SDL_RWops*)ptr)->seek} a n n -- n	( context offset whence -- )
\ c-funptr SDL_RWops-read() {((struct SDL_RWops*)ptr)->read} a a n n -- n	( context ptr size maxnum -- )
\ c-funptr SDL_RWops-write() {((struct SDL_RWops*)ptr)->write} a a n n -- n	( context ptr size num -- )
\ c-funptr SDL_RWops-close() {((struct SDL_RWops*)ptr)->close} a -- n	( context -- )

\ ------===< functions >===-------
c-function SDL_RWFromFile SDL_RWFromFile a a -- a	( file mode -- )
c-function SDL_RWFromFP SDL_RWFromFP a n -- a	( fp autoclose -- )
c-function SDL_RWFromMem SDL_RWFromMem a n -- a	( mem size -- )
c-function SDL_RWFromConstMem SDL_RWFromConstMem a n -- a	( mem size -- )
c-function SDL_AllocRW SDL_AllocRW  -- a	( -- )
c-function SDL_FreeRW SDL_FreeRW a -- void	( area -- )
c-function SDL_RWsize SDL_RWsize a -- n	( context -- )
c-function SDL_RWseek SDL_RWseek a n n -- n	( context offset whence -- )
c-function SDL_RWtell SDL_RWtell a -- n	( context -- )
c-function SDL_RWread SDL_RWread a a n n -- n	( context ptr size maxnum -- )
c-function SDL_RWwrite SDL_RWwrite a a n n -- n	( context ptr size num -- )
c-function SDL_RWclose SDL_RWclose a -- n	( context -- )
c-function SDL_LoadFile_RW SDL_LoadFile_RW a a n -- a	( src datasize freesrc -- )
c-function SDL_LoadFile SDL_LoadFile a a -- a	( file datasize -- )
c-function SDL_ReadU8 SDL_ReadU8 a -- n	( src -- )
c-function SDL_ReadLE16 SDL_ReadLE16 a -- n	( src -- )
c-function SDL_ReadBE16 SDL_ReadBE16 a -- n	( src -- )
c-function SDL_ReadLE32 SDL_ReadLE32 a -- n	( src -- )
c-function SDL_ReadBE32 SDL_ReadBE32 a -- n	( src -- )
c-function SDL_ReadLE64 SDL_ReadLE64 a -- n	( src -- )
c-function SDL_ReadBE64 SDL_ReadBE64 a -- n	( src -- )
c-function SDL_WriteU8 SDL_WriteU8 a n -- n	( dst value -- )
c-function SDL_WriteLE16 SDL_WriteLE16 a n -- n	( dst value -- )
c-function SDL_WriteBE16 SDL_WriteBE16 a n -- n	( dst value -- )
c-function SDL_WriteLE32 SDL_WriteLE32 a n -- n	( dst value -- )
c-function SDL_WriteBE32 SDL_WriteBE32 a n -- n	( dst value -- )
c-function SDL_WriteLE64 SDL_WriteLE64 a n -- n	( dst value -- )
c-function SDL_WriteBE64 SDL_WriteBE64 a n -- n	( dst value -- )

\ ----===< postfix >===-----
end-c-library
