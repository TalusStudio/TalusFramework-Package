This unity project template(ready to prototype) has essential SDK and Plugins implemented:

# :exclamation: Requirements 
- Unity 2020.3.9f1 

# :zap: Built-in Packages

- Unity Universal Rendering Pipeline(URP)
- DOTween PRO (https://assetstore.unity.com/packages/tools/visual-scripting/dotween-pro-32416)
- Odin Serializer & Inspector & Validator (https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041)
- Safe Area Helper (for notched phones) (https://assetstore.unity.com/packages/tools/gui/safe-area-helper-130488)
- Device Simulator (https://docs.unity3d.com/Packages/com.unity.device-simulator@3.0/manual/DeviceSimulatorView.html)
- Unity Recorder
- Talus Framework

# :hammer: Talus Framework

- Ready to use behaviours, scriptable objects, utilities etc.

  ## Game Events
  
  ## Behaviours
  - GameEventListener
  - AnimatorParameterSetter, ImageFillSetter, SliderSetter, TextReplacer
  - Thing, ThingDisabler, ThingEnabler

  ## Reference Types and Editor Utility
  
  ## Scriptable Objects
  - Bool, Float, Int, String, Vector2, Vector3, GameObject Variables
  - Bool, Float, Int, String, Vector3, Vector3, GameObject Constants
  - Runtime Set / Thing RunTime Set
  - GameEvent
  - TransitionData
  
  ## Editor Utilities & Tools
  - Scriptable Object Creator (shortcut: CTRL + T)
  - GameObject Replacer (shortcut : CTRL + Q) 
  - Watch Window (shortcut: CTRL + W)
  - Menu Editor (shorcut: CTRL + M)
    

# :thumbsup: Recommended Assets

- Animancer Pro(state machine, basic inverse kinematics etc.) (https://drive.google.com/file/d/1RMO55StKmmbf4858OHMOzJchCEUj0l4C/view?usp=sharing) 
- Lean Touch + (https://drive.google.com/file/d/1kbYvATtxYtp0ggfa506oKd5M_Gn9knvd/view?usp=sharing)

# :sparkles: Advices 
 - Avoid scene references as much as possible.
 - Use event mechanism whenever possible. (https://www.youtube.com/watch?v=raQ3iHhE_Kk)
 - Don't reinvent the wheel. (For example, use CineMachine Camera for player follow and camera shake).
 - Premature Optimization is the root of All Evil.
 - Follow Single-Responsibility Principle!
 - Use Odin Attributes(for example, [Required]) whenever possible. (https://odininspector.com/attributes)
 - Use Cache Server. (https://docs.unity3d.com/Manual/UnityAccelerator.html)
 - Don't forget Haptic! (MMVibrationManager)
     - MMVibrationManager.Haptic(HapticTypes.Failure); (When player die etc.)
     - MMVibrationManager.Haptic(HapticTypes.Success); (When player win etc.)
     - MMVibrationManager.Haptic(HapticTypes.Warning); (When player take damage etc.)
