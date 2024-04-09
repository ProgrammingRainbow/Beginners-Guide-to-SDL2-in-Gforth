\ ----===< prefix >===-----
c-library sdl_rect
s" SDL2" add-lib
\c #include <SDL2/SDL_rect.h>

\ -------===< structs >===--------

\ struct SDL_Point
begin-structure SDL_Point
	c-int: SDL_Point-x
	c-int: SDL_Point-y
end-structure

\ struct SDL_FPoint
begin-structure SDL_FPoint
	c-float: SDL_FPoint-x
	c-float: SDL_FPoint-y
end-structure

\ struct SDL_Rect
begin-structure SDL_Rect
	c-int: SDL_Rect-x
	c-int: SDL_Rect-y
    c-int: SDL_Rect-w
	c-int: SDL_Rect-h
end-structure

\ struct SDL_FRect
begin-structure SDL_FRect
	c-float: SDL_FRect-x
	c-float: SDL_FRect-y
    c-float: SDL_FRect-w
	c-float: SDL_FRect-h
end-structure

\ ------===< functions >===-------
c-function SDL_PointInRect SDL_PointInRect a a -- n	( p r -- )
c-function SDL_RectEmpty SDL_RectEmpty a -- n	( r -- )
c-function SDL_RectEquals SDL_RectEquals a a -- n	( a b -- )
c-function SDL_HasIntersection SDL_HasIntersection a a -- n	( A B -- )
c-function SDL_IntersectRect SDL_IntersectRect a a a -- n	( A B result -- )
c-function SDL_UnionRect SDL_UnionRect a a a -- void	( A B result -- )
c-function SDL_EnclosePoints SDL_EnclosePoints a n a a -- n	( points count clip result -- )
c-function SDL_IntersectRectAndLine SDL_IntersectRectAndLine a a a a a -- n	( rect X1 Y1 X2 Y2 -- )
c-function SDL_PointInFRect SDL_PointInFRect a a -- n	( p r -- )
c-function SDL_FRectEmpty SDL_FRectEmpty a -- n	( r -- )
c-function SDL_FRectEqualsEpsilon SDL_FRectEqualsEpsilon a a r -- n	( a b epsilon -- )
c-function SDL_FRectEquals SDL_FRectEquals a a -- n	( a b -- )
c-function SDL_HasIntersectionF SDL_HasIntersectionF a a -- n	( A B -- )
c-function SDL_IntersectFRect SDL_IntersectFRect a a a -- n	( A B result -- )
c-function SDL_UnionFRect SDL_UnionFRect a a a -- void	( A B result -- )
c-function SDL_EncloseFPoints SDL_EncloseFPoints a n a a -- n	( points count clip result -- )
c-function SDL_IntersectFRectAndLine SDL_IntersectFRectAndLine a a a a a -- n	( rect X1 Y1 X2 Y2 -- )

\ ----===< postfix >===-----
end-c-library
