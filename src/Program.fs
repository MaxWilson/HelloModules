// For more information see https://aka.ms/fsharp-console-apps

open Fable.Core.JsInterop
#if DEBUG
emitJsStatement () """Hooks.once("init", function() {
    CONFIG.debug.hooks = true;
});"""
#endif