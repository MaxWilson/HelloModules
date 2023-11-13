﻿//module Main

// For more information see https://aka.ms/fsharp-console-apps
open Fable.Core.JsInterop
open Fable.React
open UI.CharacterView
let breakHere () = System.Diagnostics.Debugger.Break();

let attach domNode =
    ReactDom.render(CharacterView(), domNode)

#if DEBUG
emitJsStatement attach """

Hooks.once("init", function() {
    CONFIG.debug.hooks = true;
});

console.log("Hello World! This code runs immediately when the file is loaded.");

Hooks.on("init", function() {
  console.log("This code runs once the Foundry VTT software begins its initialization workflow.");
});

Hooks.on("ready", function() {
  console.log("This code runs once core initialization is ready and game data is available.");
});

Hooks.on('renderActorSheet', function(sheet, html, data) {
  // I'm fuzzy on the distinction between data and sheet because I think the sheet might contain a DataModel of the data. But maybe it's a nephew, not a child. (Maybe it's the actor that's has the DataModel.)
  console.log("Rendering " + data.actor.name);
  let node = (html.find(".charname"))[0];
  if(node) {
    let f = $0;
    f(node);
  }
});
"""
#endif
Browser.Dom.window?hello<-"world"