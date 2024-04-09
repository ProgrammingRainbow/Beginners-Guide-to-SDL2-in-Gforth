\ ----===< prefix >===-----
c-library sdl_events
s" SDL2" add-lib
\c #include <SDL2/SDL_events.h>

\ ----===< int constants >===-----
#0	constant SDL_RELEASED
#1	constant SDL_PRESSED
#32	constant SDL_TEXTEDITINGEVENT_TEXT_SIZE
#32	constant SDL_TEXTINPUTEVENT_TEXT_SIZE
#-1	constant SDL_QUERY
#0	constant SDL_IGNORE
#0	constant SDL_DISABLE
#1	constant SDL_ENABLE

\ --------===< enums >===---------
#0	    constant SDL_FIRSTEVENT
#256	constant SDL_QUIT_ENUM
#257	constant SDL_APP_TERMINATING
#258	constant SDL_APP_LOWMEMORY
#259	constant SDL_APP_WILLENTERBACKGROUND
#260	constant SDL_APP_DIDENTERBACKGROUND
#261	constant SDL_APP_WILLENTERFOREGROUND
#262	constant SDL_APP_DIDENTERFOREGROUND
#263	constant SDL_LOCALECHANGED
#336	constant SDL_DISPLAYEVENT_ENUM
#512	constant SDL_WINDOWEVENT_ENUM
#513	constant SDL_SYSWMEVENT_ENUM
#768	constant SDL_KEYDOWN
#769	constant SDL_KEYUP
#770	constant SDL_TEXTEDITING
#771	constant SDL_TEXTINPUT
#772	constant SDL_KEYMAPCHANGED
#773	constant SDL_TEXTEDITING_EXT
#1024	constant SDL_MOUSEMOTION
#1025	constant SDL_MOUSEBUTTONDOWN
#1026	constant SDL_MOUSEBUTTONUP
#1027	constant SDL_MOUSEWHEEL
#1536	constant SDL_JOYAXISMOTION
#1537	constant SDL_JOYBALLMOTION
#1538	constant SDL_JOYHATMOTION
#1539	constant SDL_JOYBUTTONDOWN
#1540	constant SDL_JOYBUTTONUP
#1541	constant SDL_JOYDEVICEADDED
#1542	constant SDL_JOYDEVICEREMOVED
#1543	constant SDL_JOYBATTERYUPDATED
#1616	constant SDL_CONTROLLERAXISMOTION
#1617	constant SDL_CONTROLLERBUTTONDOWN
#1618	constant SDL_CONTROLLERBUTTONUP
#1619	constant SDL_CONTROLLERDEVICEADDED
#1620	constant SDL_CONTROLLERDEVICEREMOVED
#1621	constant SDL_CONTROLLERDEVICEREMAPPED
#1622	constant SDL_CONTROLLERTOUCHPADDOWN
#1623	constant SDL_CONTROLLERTOUCHPADMOTION
#1624	constant SDL_CONTROLLERTOUCHPADUP
#1625	constant SDL_CONTROLLERSENSORUPDATE
#1792	constant SDL_FINGERDOWN
#1793	constant SDL_FINGERUP
#1794	constant SDL_FINGERMOTION
#2048	constant SDL_DOLLARGESTURE
#2049	constant SDL_DOLLARRECORD
#2050	constant SDL_MULTIGESTURE
#2304	constant SDL_CLIPBOARDUPDATE
#4096	constant SDL_DROPFILE
#4097	constant SDL_DROPTEXT
#4098	constant SDL_DROPBEGIN
#4099	constant SDL_DROPCOMPLETE
#4352	constant SDL_AUDIODEVICEADDED
#4353	constant SDL_AUDIODEVICEREMOVED
#4608	constant SDL_SENSORUPDATE_ENUM
#8192	constant SDL_RENDER_TARGETS_RESET
#8193	constant SDL_RENDER_DEVICE_RESET
#32512	constant SDL_POLLSENTINEL
#32768	constant SDL_USEREVENT_ENUM
#65535	constant SDL_LASTEVENT
#0      constant SDL_ADDEVENT
#1      constant SDL_PEEKEVENT
#2      constant SDL_GETEVENT

\ -------===< structs >===--------

\ struct SDL_CommonEvent
begin-structure SDL_CommonEvent
	c-uint32:   SDL_CommonEvent-type
	c-uint32:   SDL_CommonEvent-timestamp
end-structure

\ struct SDL_DisplayEvent
begin-structure SDL_DisplayEvent
	c-uint32:   SDL_DisplayEvent-type
	c-uint32:   SDL_DisplayEvent-timestamp
	c-uint32:   SDL_DisplayEvent-display
	c-uint8:    SDL_DisplayEvent-event
	c-uint8:    SDL_DisplayEvent-padding1
	c-uint8:    SDL_DisplayEvent-padding2
	c-uint8:    SDL_DisplayEvent-padding3
	c-sint32:   SDL_DisplayEvent-data1
end-structure

\ struct SDL_WindowEvent
begin-structure SDL_WindowEvent
	c-uint32:   SDL_WindowEvent-type
	c-uint32:   SDL_WindowEvent-timestamp
	c-uint32:   SDL_WindowEvent-windowID
	c-uint8:    SDL_WindowEvent-event
	c-uint8:    SDL_WindowEvent-padding1
	c-uint8:    SDL_WindowEvent-padding2
	c-uint8:    SDL_WindowEvent-padding3
	c-sint32:   SDL_WindowEvent-data1
	c-sint32:   SDL_WindowEvent-data2
end-structure

\ struct SDL_KeyboardEvent
begin-structure         SDL_KeyboardEvent
	c-uint32:           SDL_KeyboardEvent-type
	c-uint32:           SDL_KeyboardEvent-timestamp
	c-uint32:           SDL_KeyboardEvent-windowID
	c-uint8:            SDL_KeyboardEvent-state
	c-uint8:            SDL_KeyboardEvent-repeat
	c-uint8:            SDL_KeyboardEvent-padding2
	c-uint8:            SDL_KeyboardEvent-padding3
	SDL_Keysym bytes:   SDL_KeyboardEvent-keysym
end-structure

\ struct SDL_TextEditingEvent
begin-structure SDL_TextEditingEvent
	c-uint32:   SDL_TextEditingEvent-type
	c-uint32:   SDL_TextEditingEvent-timestamp
	c-uint32:   SDL_TextEditingEvent-windowID
	32 c-chars: SDL_TextEditingEvent-text
	c-sint32:   SDL_TextEditingEvent-start
	c-sint32:   SDL_TextEditingEvent-length
end-structure

\ struct SDL_TextEditingExtEvent
begin-structure SDL_TextEditingExtEvent
	c-uint32:   SDL_TextEditingExtEvent-type
	c-uint32:   SDL_TextEditingExtEvent-timestamp
	c-uint32:   SDL_TextEditingExtEvent-windowID
	c-uint32:   SDL_TextEditingExtEvent-padding
	c-char-ptr: SDL_TextEditingExtEvent-text
	c-sint32:   SDL_TextEditingExtEvent-start
	c-sint32:   SDL_TextEditingExtEvent-length
end-structure

\ struct SDL_TextInputEvent
begin-structure SDL_TextInputEvent
	c-uint32:   SDL_TextInputEvent-type
	c-uint32:   SDL_TextInputEvent-timestamp
	c-uint32:   SDL_TextInputEvent-windowID
	32 bytes:   SDL_TextInputEvent-text
end-structure

\ struct SDL_MouseMotionEvent
begin-structure SDL_MouseMotionEvent
	c-uint32:   SDL_MouseMotionEvent-type
	c-uint32:   SDL_MouseMotionEvent-timestamp
	c-uint32:   SDL_MouseMotionEvent-windowID
	c-uint32:   SDL_MouseMotionEvent-which
	c-uint32:   SDL_MouseMotionEvent-state
	c-sint32:   SDL_MouseMotionEvent-x
	c-sint32:   SDL_MouseMotionEvent-y
	c-sint32:   SDL_MouseMotionEvent-xrel
	c-sint32:   SDL_MouseMotionEvent-yrel
end-structure

\ struct SDL_MouseButtonEvent
begin-structure SDL_MouseButtonEvent
	c-uint32:   SDL_MouseButtonEvent-type
	c-uint32:   SDL_MouseButtonEvent-timestamp
	c-uint32:   SDL_MouseButtonEvent-windowID
	c-uint32:   SDL_MouseButtonEvent-which
	c-uint8:    SDL_MouseButtonEvent-button
	c-uint8:    SDL_MouseButtonEvent-state
	c-uint8:    SDL_MouseButtonEvent-clicks
	c-uint8:    SDL_MouseButtonEvent-padding1
	c-sint32:   SDL_MouseButtonEvent-x
	c-sint32:   SDL_MouseButtonEvent-y
end-structure

\ struct SDL_MouseWheelEvent
begin-structure SDL_MouseWheelEvent
	c-uint32:   SDL_MouseWheelEvent-type
	c-uint32:   SDL_MouseWheelEvent-timestamp
	c-uint32:   SDL_MouseWheelEvent-windowID
	c-uint32:   SDL_MouseWheelEvent-which
	c-sint32:   SDL_MouseWheelEvent-x
	c-sint32:   SDL_MouseWheelEvent-y
	c-uint32:   SDL_MouseWheelEvent-direction
	c-float:    SDL_MouseWheelEvent-preciseX
	c-float:    SDL_MouseWheelEvent-preciseY
	c-sint32:   SDL_MouseWheelEvent-mouseX
	c-sint32:   SDL_MouseWheelEvent-mouseY
end-structure

\ struct SDL_JoyAxisEvent
begin-structure SDL_JoyAxisEvent
	c-uint32:   SDL_JoyAxisEvent-type
	c-uint32:   SDL_JoyAxisEvent-timestamp
	c-sint32:   SDL_JoyAxisEvent-which
	c-uint8:    SDL_JoyAxisEvent-axis
	c-uint8:    SDL_JoyAxisEvent-padding1
	c-uint8:    SDL_JoyAxisEvent-padding2
	c-uint8:    SDL_JoyAxisEvent-padding3
	c-sint16:   SDL_JoyAxisEvent-value
	c-uint16:   SDL_JoyAxisEvent-padding4
end-structure

\ struct SDL_JoyBallEvent
begin-structure SDL_JoyBallEvent
	c-uint32:   SDL_JoyBallEvent-type
	c-uint32:   SDL_JoyBallEvent-timestamp
	c-sint32:   SDL_JoyBallEvent-which
	c-uint8:    SDL_JoyBallEvent-ball
	c-uint8:    SDL_JoyBallEvent-padding1
	c-uint8:    SDL_JoyBallEvent-padding2
	c-uint8:    SDL_JoyBallEvent-padding3
	c-sint16:   SDL_JoyBallEvent-xrel
	c-sint16:   SDL_JoyBallEvent-yrel
end-structure

\ struct SDL_JoyHatEvent
begin-structure SDL_JoyHatEvent
	c-uint32:   SDL_JoyHatEvent-type
	c-uint32:   SDL_JoyHatEvent-timestamp
	c-sint32:   SDL_JoyHatEvent-which
	c-uint8:    SDL_JoyHatEvent-hat
	c-uint8:    SDL_JoyHatEvent-value
	c-uint8:    SDL_JoyHatEvent-padding1
	c-uint8:    SDL_JoyHatEvent-padding2
end-structure

\ struct SDL_JoyButtonEvent
begin-structure SDL_JoyButtonEvent
	c-uint32:   SDL_JoyButtonEvent-type
	c-uint32:   SDL_JoyButtonEvent-timestamp
	c-sint32:   SDL_JoyButtonEvent-which
	c-uint8:    SDL_JoyButtonEvent-button
	c-uint8:    SDL_JoyButtonEvent-state
	c-uint8:    SDL_JoyButtonEvent-padding1
	c-uint8:    SDL_JoyButtonEvent-padding2
end-structure

\ struct SDL_JoyDeviceEvent
begin-structure SDL_JoyDeviceEvent
	c-uint32:   SDL_JoyDeviceEvent-type
	c-uint32:   SDL_JoyDeviceEvent-timestamp
	c-sint32:   SDL_JoyDeviceEvent-which
end-structure

\ struct SDL_JoyBatteryEvent
begin-structure SDL_JoyBatteryEvent
	c-uint32:   SDL_JoyBatteryEvent-type
	c-uint32:   SDL_JoyBatteryEvent-timestamp
	c-sint32:   SDL_JoyBatteryEvent-which
	c-enum:     SDL_JoyBatteryEvent-level
end-structure

\ struct SDL_ControllerAxisEvent
begin-structure SDL_ControllerAxisEvent
	c-uint32:   SDL_ControllerAxisEvent-type
	c-uint32:   SDL_ControllerAxisEvent-timestamp
	c-sint32:   SDL_ControllerAxisEvent-which
	c-uint8:    SDL_ControllerAxisEvent-axis
	c-uint8:    SDL_ControllerAxisEvent-padding1
	c-uint8:    SDL_ControllerAxisEvent-padding2
	c-uint8:    SDL_ControllerAxisEvent-padding3
	c-sint16:   SDL_ControllerAxisEvent-value
	c-uint16:   SDL_ControllerAxisEvent-padding4
end-structure

\ struct SDL_ControllerButtonEvent
begin-structure SDL_ControllerButtonEvent
	c-uint32:   SDL_ControllerButtonEvent-type
	c-uint32:   SDL_ControllerButtonEvent-timestamp
	c-sint32:   SDL_ControllerButtonEvent-which
	c-uint8:    SDL_ControllerButtonEvent-button
	c-uint8:    SDL_ControllerButtonEvent-state
	c-uint8:    SDL_ControllerButtonEvent-padding1
	c-uint8:    SDL_ControllerButtonEvent-padding2
end-structure

\ struct SDL_ControllerDeviceEvent
begin-structure SDL_ControllerDeviceEvent
	c-uint32:   SDL_ControllerDeviceEvent-type
	c-uint32:   SDL_ControllerDeviceEvent-timestamp
	c-sint32:   SDL_ControllerDeviceEvent-which
end-structure

\ struct SDL_ControllerTouchpadEvent
begin-structure SDL_ControllerTouchpadEvent
	c-uint32:   SDL_ControllerTouchpadEvent-type
	c-uint32:   SDL_ControllerTouchpadEvent-timestamp
	c-sint32:   SDL_ControllerTouchpadEvent-which
	c-sint32:   SDL_ControllerTouchpadEvent-touchpad
	c-sint32:   SDL_ControllerTouchpadEvent-finger
	c-float:    SDL_ControllerTouchpadEvent-x
	c-float:    SDL_ControllerTouchpadEvent-y
	c-float:    SDL_ControllerTouchpadEvent-pressure
end-structure

\ struct SDL_ControllerSensorEvent
begin-structure SDL_ControllerSensorEvent
	c-uint32:   SDL_ControllerSensorEvent-type
	c-uint32:   SDL_ControllerSensorEvent-timestamp
	c-sint32:   SDL_ControllerSensorEvent-which
	c-sint32:   SDL_ControllerSensorEvent-sensor
	3 c-floats: SDL_ControllerSensorEvent-data
	c-uint32:   SDL_ControllerSensorEvent-padding
	c-uint64:   SDL_ControllerSensorEvent-timestamp_us
end-structure

\ struct SDL_AudioDeviceEvent
begin-structure SDL_AudioDeviceEvent
	c-uint32:   SDL_AudioDeviceEvent-type
	c-uint32:   SDL_AudioDeviceEvent-timestamp
	c-uint32:   SDL_AudioDeviceEvent-which
	c-uint8:    SDL_AudioDeviceEvent-iscapture
	c-uint8:    SDL_AudioDeviceEvent-padding1
	c-uint8:    SDL_AudioDeviceEvent-padding2
	c-uint8:    SDL_AudioDeviceEvent-padding3
end-structure

\ struct SDL_TouchFingerEvent
begin-structure SDL_TouchFingerEvent
	c-uint32:   SDL_TouchFingerEvent-type
	c-uint32:   SDL_TouchFingerEvent-timestamp
	c-sint64:   SDL_TouchFingerEvent-touchId
	c-sint64:   SDL_TouchFingerEvent-fingerId
	c-float:    SDL_TouchFingerEvent-x
	c-float:    SDL_TouchFingerEvent-y
	c-float:    SDL_TouchFingerEvent-dx
	c-float:    SDL_TouchFingerEvent-dy
	c-float:    SDL_TouchFingerEvent-pressure
	c-uint32:   SDL_TouchFingerEvent-windowID
end-structure

\ struct SDL_MultiGestureEvent
begin-structure SDL_MultiGestureEvent
	c-uint32:   SDL_MultiGestureEvent-type
	c-uint32:   SDL_MultiGestureEvent-timestamp
	c-sint64:   SDL_MultiGestureEvent-touchId
	c-float:    SDL_MultiGestureEvent-dTheta
	c-float:    SDL_MultiGestureEvent-dDist
	c-float:    SDL_MultiGestureEvent-x
	c-float:    SDL_MultiGestureEvent-y
	c-uint16:   SDL_MultiGestureEvent-numFingers
	6 bytes:	SDL_MultiGestureEvent-padding
end-structure

\ struct SDL_DollarGestureEvent
begin-structure SDL_DollarGestureEvent
	c-uint32:   SDL_DollarGestureEvent-type
	c-uint32:   SDL_DollarGestureEvent-timestamp
	c-sint64:   SDL_DollarGestureEvent-touchId
	c-sint64:   SDL_DollarGestureEvent-gestureId
	c-uint32:   SDL_DollarGestureEvent-numFingers
	c-float:    SDL_DollarGestureEvent-error
	c-float:    SDL_DollarGestureEvent-x
	c-float:    SDL_DollarGestureEvent-y
end-structure

\ struct SDL_DropEvent
begin-structure SDL_DropEvent
	c-uint32:   SDL_DropEvent-type
	c-uint32:   SDL_DropEvent-timestamp
	c-char-ptr: SDL_DropEvent-file
	c-uint32:   SDL_DropEvent-windowID
	c-uint32:   SDL_DropEvent-padding
end-structure

\ struct SDL_SensorEvent
begin-structure SDL_SensorEvent
	c-uint32:   SDL_SensorEvent-type
	c-uint32:   SDL_SensorEvent-timestamp
	c-sint32:   SDL_SensorEvent-which
	6 c-floats: SDL_SensorEvent-data
	c-uint32:   SDL_SensorEvent-padding
	c-uint64:   SDL_SensorEvent-timestamp_us
end-structure

\ struct SDL_QuitEvent
begin-structure SDL_QuitEvent
	c-uint32:   SDL_QuitEvent-type
	c-uint32:   SDL_QuitEvent-timestamp
end-structure

\ struct SDL_OSEvent
begin-structure SDL_OSEvent
	c-uint32:   SDL_OSEvent-type
	c-uint32:   SDL_OSEvent-timestamp
end-structure

\ struct SDL_UserEvent
begin-structure SDL_UserEvent
	c-uint32:   SDL_UserEvent-type
	c-uint32:   SDL_UserEvent-timestamp
	c-uint32:   SDL_UserEvent-windowID
	c-sint32:   SDL_UserEvent-code
	c-pointer:  SDL_UserEvent-data1
	c-pointer:  SDL_UserEvent-data2
end-structure

\ struct SDL_SysWMEvent
begin-structure SDL_SysWMEvent
	c-uint32:       SDL_SysWMEvent-type
	c-uint32:       SDL_SysWMEvent-timestamp
	c-struct-ptr:   SDL_SysWMEvent-msg
end-structure

\ -------===< unions >===--------

\ union SDL_Event
begin-structure SDL_Event
	drop 0 c-uint32: 								SDL_Event-type
	drop 0 56 bytes:							SDL_Event-padding
	drop 0 SDL_CommonEvent bytes:				SDL_Event-common
	drop 0 SDL_DisplayEvent bytes:				SDL_Event-display
	drop 0 SDL_WindowEvent bytes:				SDL_Event-window
	drop 0 SDL_KeyboardEvent bytes:				SDL_Event-key
	drop 0 SDL_TextEditingEvent bytes:			SDL_Event-edit
	drop 0 SDL_TextEditingExtEvent bytes:		SDL_Event-editExt
	drop 0 SDL_TextInputEvent bytes:			SDL_Event-text
	drop 0 SDL_MouseMotionEvent bytes:			SDL_Event-motion
	drop 0 SDL_MouseButtonEvent bytes:			SDL_Event-button
	drop 0 SDL_MouseWheelEvent bytes:			SDL_Event-wheel
	drop 0 SDL_JoyAxisEvent bytes:				SDL_Event-jaxis
	drop 0 SDL_JoyBallEvent bytes:				SDL_Event-jball
	drop 0 SDL_JoyHatEvent bytes:				SDL_Event-jhat
	drop 0 SDL_JoyButtonEvent bytes:			SDL_Event-jbutton
	drop 0 SDL_JoyDeviceEvent bytes:			SDL_Event-jdevice
	drop 0 SDL_JoyBatteryEvent bytes:			SDL_Event-jbattery
	drop 0 SDL_ControllerAxisEvent bytes:		SDL_Event-caxis
	drop 0 SDL_ControllerButtonEvent bytes:		SDL_Event-cbutton
	drop 0 SDL_ControllerDeviceEvent bytes:		SDL_Event-cdevice
	drop 0 SDL_ControllerTouchpadEvent bytes:	SDL_Event-ctouchpad
	drop 0 SDL_ControllerSensorEvent bytes:		SDL_Event-csensor
	drop 0 SDL_AudioDeviceEvent bytes:			SDL_Event-adevice
	drop 0 SDL_TouchFingerEvent bytes:			SDL_Event-tfinger
	drop 0 SDL_MultiGestureEvent bytes:			SDL_Event-mgesture
	drop 0 SDL_DollarGestureEvent bytes:		SDL_Event-dgesture
	drop 0 SDL_DropEvent bytes:					SDL_Event-drop
	drop 0 SDL_SensorEvent bytes:				SDL_Event-sensor
	drop 0 SDL_QuitEvent bytes:					SDL_Event-quit
	drop 0 SDL_UserEvent bytes:					SDL_Event-user
	drop 0 SDL_SysWMEvent bytes:				SDL_Event-syswm
end-structure

\ ------===< functions >===-------
c-function SDL_PumpEvents SDL_PumpEvents  -- void	( -- )
c-function SDL_PeepEvents SDL_PeepEvents a n n n n -- n	( events numevents action minType maxType -- )
c-function SDL_HasEvent SDL_HasEvent n -- n	( type -- )
c-function SDL_HasEvents SDL_HasEvents n n -- n	( minType maxType -- )
c-function SDL_FlushEvent SDL_FlushEvent n -- void	( type -- )
c-function SDL_FlushEvents SDL_FlushEvents n n -- void	( minType maxType -- )
c-function SDL_PollEvent SDL_PollEvent a -- n	( event -- )
c-function SDL_WaitEvent SDL_WaitEvent a -- n	( event -- )
c-function SDL_WaitEventTimeout SDL_WaitEventTimeout a n -- n	( event timeout -- )
c-function SDL_PushEvent SDL_PushEvent a -- n	( event -- )
c-function SDL_SetEventFilter SDL_SetEventFilter a a -- void	( filter userdata -- )
c-function SDL_GetEventFilter SDL_GetEventFilter a a -- n	( filter userdata -- )
c-function SDL_AddEventWatch SDL_AddEventWatch a a -- void	( filter userdata -- )
c-function SDL_DelEventWatch SDL_DelEventWatch a a -- void	( filter userdata -- )
c-function SDL_FilterEvents SDL_FilterEvents a a -- void	( filter userdata -- )
c-function SDL_EventState SDL_EventState n n -- n	( type state -- )
c-function SDL_RegisterEvents SDL_RegisterEvents n -- n	( numevents -- )

\ ----===< postfix >===-----
end-c-library
