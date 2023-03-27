module Build

open Fake.Core

//Context.setExecutionContext false ""() |> ignore

let initTargets () =
    Target.create "Hello" (fun _ ->
        printfn "hello from FAKE!"
  
    )   

[<EntryPoint>]
let main argv =
    argv
    |> Array.toList
    |> Context.FakeExecutionContext.Create false "build.fsx"
    |> Context.RuntimeContext.Fake
    |> Context.setExecutionContext

    initTargets ()

    Target.runOrDefault "Hello"
    0