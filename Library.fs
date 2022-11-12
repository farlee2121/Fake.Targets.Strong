namespace Fake.Strong


module Target =
    open Fake.Core
    let def name f = 
        Target.create name f
        Target.get name

    let runOrDefault target =
        Target.runOrDefault target.Name

    let private getName target = target.Name
    let dependsOn deps target = 
        TargetOperators.(<==) target.Name (deps |> List.map getName)
        target

    let softDependsOn deps target = 
        deps
        |> List.map (getName >> (TargetOperators.(<=?) target.Name))
        |> ignore

        target

module Operators = 

    let (<==) dependent dependencies =
        dependent |> Target.dependsOn dependencies

    let (<=?) dependent dependency =
        dependent |> Target.softDependsOn [dependency]
    

