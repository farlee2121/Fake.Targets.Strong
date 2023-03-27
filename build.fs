module Build

open Fake.Core
open Fake.Strong 

[<EntryPoint>]
let main argv =
    argv
    |> Array.toList
    |> Context.FakeExecutionContext.Create false "build.fsx"
    |> Context.RuntimeContext.Fake
    |> Context.setExecutionContext

    let hello = Target.def "Hello" (fun _ ->
        printfn "hello from FAKE!"
    )   

    Fake.Strong.Target.runOrDefault hello
    0