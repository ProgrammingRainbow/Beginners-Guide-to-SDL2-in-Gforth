\ ----===< prefix >===-----
c-library sdl_haptic
s" SDL2" add-lib
\c #include <SDL2/SDL_haptic.h>

\ ----===< int constants >===-----
#1	        constant SDL_HAPTIC_CONSTANT
#2	        constant SDL_HAPTIC_SINE
#4	        constant SDL_HAPTIC_LEFTRIGHT
#8	        constant SDL_HAPTIC_TRIANGLE
#16	        constant SDL_HAPTIC_SAWTOOTHUP
#32	        constant SDL_HAPTIC_SAWTOOTHDOWN
#64	        constant SDL_HAPTIC_RAMP
#128	    constant SDL_HAPTIC_SPRING
#256	    constant SDL_HAPTIC_DAMPER
#512	    constant SDL_HAPTIC_INERTIA
#1024	    constant SDL_HAPTIC_FRICTION
#2048	    constant SDL_HAPTIC_CUSTOM
#4096	    constant SDL_HAPTIC_GAIN
#8192	    constant SDL_HAPTIC_AUTOCENTER
#16384	    constant SDL_HAPTIC_STATUS
#32768	    constant SDL_HAPTIC_PAUSE
#0	        constant SDL_HAPTIC_POLAR
#1	        constant SDL_HAPTIC_CARTESIAN
#2	        constant SDL_HAPTIC_SPHERICAL
#3	        constant SDL_HAPTIC_STEERING_AXIS
#4294967295	constant SDL_HAPTIC_INFINITY

\ -------===< structs >===--------

\ struct SDL_HapticDirection
begin-structure SDL_HapticDirection
	c-uint8:		SDL_HapticDirection-type
	3 bytes:		SDL_HapticDirection-padding
	3 c-sint32s:	SDL_HapticDirection-dir
end-structure

\ struct SDL_HapticConstant
begin-structure SDL_HapticConstant
	c-uint16:					SDL_HapticConstant-type
	c-uint16:					SDL_HapticConstant-padding
	SDL_HapticDirection bytes:	SDL_HapticConstant-direction
	c-uint32:					SDL_HapticConstant-length
	c-uint16:					SDL_HapticConstant-delay
	c-uint16:					SDL_HapticConstant-button
	c-uint16:					SDL_HapticConstant-interval
	c-sint16:					SDL_HapticConstant-level
	c-uint16:					SDL_HapticConstant-attack_length
	c-uint16:					SDL_HapticConstant-attack_level
	c-uint16:					SDL_HapticConstant-fade_length
	c-uint16:					SDL_HapticConstant-fade_level
end-structure

\ struct SDL_HapticPeriodic
begin-structure SDL_HapticPeriodic
	c-uint16:					SDL_HapticPeriodic-type
	c-uint16:					SDL_HapticPeriodic-padding
	SDL_HapticDirection bytes:	SDL_HapticPeriodic-direction
	c-uint32:					SDL_HapticPeriodic-length
	c-uint16:					SDL_HapticPeriodic-delay
	c-uint16:					SDL_HapticPeriodic-button
	c-uint16:					SDL_HapticPeriodic-interval
	c-uint16:					SDL_HapticPeriodic-period
	c-sint16:					SDL_HapticPeriodic-magnitude
	c-sint16:					SDL_HapticPeriodic-offset
	c-uint16:					SDL_HapticPeriodic-phase
	c-uint16:					SDL_HapticPeriodic-attack_length
	c-uint16:					SDL_HapticPeriodic-attack_level
	c-uint16:					SDL_HapticPeriodic-fade_length
	c-uint16:					SDL_HapticPeriodic-fade_level
	c-uint16:					SDL_HapticPeriodic-padding2
end-structure

\ struct SDL_HapticCondition
begin-structure SDL_HapticCondition
	c-uint16:					SDL_HapticCondition-type
	c-uint16:					SDL_HapticCondition-padding
	SDL_HapticDirection bytes:	SDL_HapticCondition-direction
	c-uint32:					SDL_HapticCondition-length
	c-uint16:					SDL_HapticCondition-delay
	c-uint16:					SDL_HapticCondition-button
	c-uint16:					SDL_HapticCondition-interval
	3 c-uint16s:				SDL_HapticCondition-right_sat
	3 c-uint16s:				SDL_HapticCondition-left_sat
	3 c-sint16s:				SDL_HapticCondition-right_coeff
	3 c-sint16s:				SDL_HapticCondition-left_coeff
	3 c-uint16s:				SDL_HapticCondition-deadband
	3 c-sint16s:				SDL_HapticCondition-center
	c-uint16:					SDL_HapticCondition-padding2
end-structure

\ struct SDL_HapticRamp
begin-structure SDL_HapticRamp
	c-uint16:					SDL_HapticRamp-type
	c-uint16:					SDL_HapticRamp-padding
	SDL_HapticDirection bytes:	SDL_HapticRamp-direction
	c-uint32:					SDL_HapticRamp-length
	c-uint16:					SDL_HapticRamp-delay
	c-uint16:					SDL_HapticRamp-button
	c-uint16:					SDL_HapticRamp-interval
	c-sint16:					SDL_HapticRamp-start
	c-sint16:					SDL_HapticRamp-end
	c-uint16:					SDL_HapticRamp-attack_length
	c-uint16:					SDL_HapticRamp-attack_level
	c-uint16:					SDL_HapticRamp-fade_length
	c-uint16:					SDL_HapticRamp-fade_level
	c-uint16:					SDL_HapticRamp-padding2
end-structure

\ struct SDL_HapticLeftRight
begin-structure SDL_HapticLeftRight
	c-uint16:	SDL_HapticLeftRight-type
	c-uint16:	SDL_HapticLeftRight-padding
	c-uint32:	SDL_HapticLeftRight-length
	c-uint16:	SDL_HapticLeftRight-large_magnitude
	c-uint16:	SDL_HapticLeftRight-small_magnitude
end-structure

\ struct SDL_HapticCustom
begin-structure SDL_HapticCustom
	c-uint16:					SDL_HapticCustom-type
	c-uint16:					SDL_HapticCustom-padding
	SDL_HapticDirection bytes:	SDL_HapticCustom-direction
	c-uint32:					SDL_HapticCustom-length
	c-uint16:					SDL_HapticCustom-delay
	c-uint16:					SDL_HapticCustom-button
	c-uint16:					SDL_HapticCustom-interval
	c-uint8:					SDL_HapticCustom-channels
	c-uint8:					SDL_HapticCustom-padding2
	c-uint16:					SDL_HapticCustom-period
	c-uint16:					SDL_HapticCustom-samples
	c-uint32:					SDL_HapticCustom-padding3
	c-pointer:					SDL_HapticCustom-data
	c-uint16:					SDL_HapticCustom-attack_length
	c-uint16:					SDL_HapticCustom-attack_level
	c-uint16:					SDL_HapticCustom-fade_length
	c-uint16:					SDL_HapticCustom-fade_level
end-structure

\ -------===< unions >===--------

\ union SDL_HapticEffect
begin-structure SDL_HapticEffect
	drop 0 c-uint16:					SDL_HapticEffect-type
	drop 0 SDL_HapticConstant bytes:	SDL_HapticEffect-constant
	drop 0 SDL_HapticPeriodic bytes:	SDL_HapticEffect-periodic
	drop 0 SDL_HapticCondition bytes:	SDL_HapticEffect-condition
	drop 0 SDL_HapticRamp bytes:		SDL_HapticEffect-ramp
	drop 0 SDL_HapticLeftRight bytes:	SDL_HapticEffect-leftright
	drop 0 SDL_HapticCustom bytes:		SDL_HapticEffect-custom
end-structure

\ ------===< functions >===-------
c-function SDL_NumHaptics SDL_NumHaptics  -- n	( -- )
c-function SDL_HapticName SDL_HapticName n -- a	( device_index -- )
c-function SDL_HapticOpen SDL_HapticOpen n -- a	( device_index -- )
c-function SDL_HapticOpened SDL_HapticOpened n -- n	( device_index -- )
c-function SDL_HapticIndex SDL_HapticIndex a -- n	( haptic -- )
c-function SDL_MouseIsHaptic SDL_MouseIsHaptic  -- n	( -- )
c-function SDL_HapticOpenFromMouse SDL_HapticOpenFromMouse  -- a	( -- )
c-function SDL_JoystickIsHaptic SDL_JoystickIsHaptic a -- n	( joystick -- )
c-function SDL_HapticOpenFromJoystick SDL_HapticOpenFromJoystick a -- a	( joystick -- )
c-function SDL_HapticClose SDL_HapticClose a -- void	( haptic -- )
c-function SDL_HapticNumEffects SDL_HapticNumEffects a -- n	( haptic -- )
c-function SDL_HapticNumEffectsPlaying SDL_HapticNumEffectsPlaying a -- n	( haptic -- )
c-function SDL_HapticQuery SDL_HapticQuery a -- n	( haptic -- )
c-function SDL_HapticNumAxes SDL_HapticNumAxes a -- n	( haptic -- )
c-function SDL_HapticEffectSupported SDL_HapticEffectSupported a a -- n	( haptic effect -- )
c-function SDL_HapticNewEffect SDL_HapticNewEffect a a -- n	( haptic effect -- )
c-function SDL_HapticUpdateEffect SDL_HapticUpdateEffect a n a -- n	( haptic effect data -- )
c-function SDL_HapticRunEffect SDL_HapticRunEffect a n n -- n	( haptic effect iterations -- )
c-function SDL_HapticStopEffect SDL_HapticStopEffect a n -- n	( haptic effect -- )
c-function SDL_HapticDestroyEffect SDL_HapticDestroyEffect a n -- void	( haptic effect -- )
c-function SDL_HapticGetEffectStatus SDL_HapticGetEffectStatus a n -- n	( haptic effect -- )
c-function SDL_HapticSetGain SDL_HapticSetGain a n -- n	( haptic gain -- )
c-function SDL_HapticSetAutocenter SDL_HapticSetAutocenter a n -- n	( haptic autocenter -- )
c-function SDL_HapticPause SDL_HapticPause a -- n	( haptic -- )
c-function SDL_HapticUnpause SDL_HapticUnpause a -- n	( haptic -- )
c-function SDL_HapticStopAll SDL_HapticStopAll a -- n	( haptic -- )
c-function SDL_HapticRumbleSupported SDL_HapticRumbleSupported a -- n	( haptic -- )
c-function SDL_HapticRumbleInit SDL_HapticRumbleInit a -- n	( haptic -- )
c-function SDL_HapticRumblePlay SDL_HapticRumblePlay a r n -- n	( haptic strength length -- )
c-function SDL_HapticRumbleStop SDL_HapticRumbleStop a -- n	( haptic -- )

\ ----===< postfix >===-----
end-c-library
