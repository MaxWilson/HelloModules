module UI.CharacterView

open Feliz
open Fable.Core
// [<JSX.Component>]
// let Alternate() =
//     JSX.jsx """
//         <div>
//             <h1>Hello from React</h1>
//             <p>It is {DateTime.Now.ToString()}</p>
//         </div>
//     """

[<ReactComponent>]
let CharacterView() =
    Html.div [Html.button [prop.text "Hello from UI.CharacterView React"]]