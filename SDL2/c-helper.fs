\ ----===< prefix >===-----
c-library c_helper

\c #include <stddef.h>
\c int sizeof_char() { return sizeof(char); }
\c int sizeof_short() { return sizeof(short); }
\c int sizeof_size_t() { return sizeof(size_t); }
\c int sizeof_int() { return sizeof(int); }
\c int sizeof_float() { return sizeof(float); }
\c int sizeof_double() { return sizeof(double); }
\c int sizeof_pointer() { return sizeof(void *); }

c-function sizeof_char      sizeof_char     -- n ( -- size )
c-function sizeof_short     sizeof_short    -- n ( -- size )
c-function sizeof_size_t    sizeof_size_t   -- n ( -- size )
c-function sizeof_int       sizeof_int      -- n ( -- size )
c-function sizeof_float     sizeof_float    -- n ( -- size )
c-function sizeof_double    sizeof_double   -- n ( -- size )
c-function sizeof_pointer   sizeof_pointer  -- n ( -- size )

\ ----===< postfix >===-----
end-c-library

sizeof_char     VALUE c-char
sizeof_int      VALUE c-enum
sizeof_size_t   VALUE c-size-t
sizeof_int      VALUE c-int
sizeof_int      VALUE c-uint
sizeof_short    VALUE c-short
sizeof_short    VALUE c-ushort
1               VALUE c-uint8
2               VALUE c-uint16
4               VALUE c-uint32
8               VALUE c-uint64
2               VALUE c-sint16
4               VALUE c-sint32
8               VALUE c-sint64
sizeof_float    VALUE c-float
sizeof_double   VALUE c-double
sizeof_pointer  VALUE c-pointer
sizeof_pointer  VALUE c-char-ptr
sizeof_pointer  VALUE c-int-ptr
sizeof_pointer  VALUE c-uint8-ptr
sizeof_pointer  VALUE c-struct-ptr
sizeof_pointer  VALUE c-func-ptr

: bytes:                        +field ;
: c-chars:      c-char *        +field ;
: c-short:      c-short         +field ;
: c-ushort:     c-ushort        +field ;
: c-enum:       c-enum          +field ;
: c-size-t:     c-size-t        +field ;
: c-int:        c-int           +field ;
: c-ints:       c-int *         +field ;
: c-uint:       c-uint          +field ;
: c-uint8:      c-uint8         +field ;
: c-uint8s:     c-uint8 *       +field ;
: c-uint16:     c-uint16        +field ;
: c-uint16s:    c-uint16 *      +field ;
: c-uint32:     c-uint32        +field ;
: c-uint32s:    c-uint32 *      +field ;
: c-uint64:     c-uint64        +field ;
: c-sint16:     c-sint16        +field ;
: c-sint16s:    c-sint16 *      +field ;
: c-sint32:     c-sint32        +field ;
: c-sint32s:    c-sint32 *      +field ;
: c-sint64:     c-sint64        +field ;
: c-float:      c-float         +field ;
: c-floats:     c-float *       +field ;
: c-double:     c-double        +field ;
: c-pointer:    c-pointer       +field ;
: c-char-ptr:   c-char-ptr      +field ;
: c-int-ptr:    c-int-ptr       +field ;
: c-uint8-ptr:  c-uint8-ptr     +field ;
: c-struct-ptr: c-struct-ptr    +field ;
: c-func-ptr:   c-func-ptr      +field ;
: c-func-ptrs:  c-func-ptr *    +field ;

