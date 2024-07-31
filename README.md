# ToSic.Sxc.PersonaBar.Utils.dll

## Overview
This library manages the visibility of the DNN PersonaBar based on the HidePersonaBar cookie.

DNN PersonaBar can be problematic on mobile devices. Many users with edit permissions do not need the PersonaBar regularly. However, it consumes nearly 20% of the mobile screen space and significantly slows down page load times, especially on slower mobile connections.

The [2sxc App PersonaBar](https://github.com/2sxc-dev/app-personabar) introduces a button on the page to remove or re-add the PersonaBar and relies on this ToSic.Sxc.PersonaBar.Utils.dll for its functionality. This approach genuinely removes the bar rather than using a JavaScript-based show/hide method, which would still consume bandwidth and CPU resources for loading and running scripts.

Ensure this DLL is in the DNN bin folder for the 2sxc app to function correctly.
