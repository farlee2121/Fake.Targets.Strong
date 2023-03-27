# Fake.Targets.Strong

> !!! ⚠️ MOVED: I decided to preserve the experiment here and moved the released version to https://github.com/farlee2121/Fake-StrongTargets

Refer to fake targets by reference, not strings.

This repo is just a proof of concept at this point. No library has been released and there may be some conflicts with Fake.Core with how modules are currently named.
It does function though, and it enables targets to be referenced as values instead of as strings.

This increases compiler safety, but it does not circumvent the global side-effects when creating targets.

## Example

```fsharp
open Fake.Strong

let clean = 
    Target.def "clean" <| fun _ ->
        //...

let build = 
    Target.def "build" <| fun _ ->
        //...
    |> Target.softDependsOn [clean]

let test = 
    Target.def "test" <| fun _ ->
        //...
    |> Target.dependsOn [build]

let default' = 
    Target.def "default" <| fun _ -> 
        //...
    |> Target.dependsOn [clean; build; test]


Target.runOrDefault default'
```

## Other thoughts

It would be nice to have separation of target data initialization and the registration side-effects. Not sure if that can be done, and it probably wouldn't be done often.

Might look like
```fsharp
Target.construct "Name" func
|> Target.register
```

This way the target could be created with a builder pattern (no side-effects) and registered when complete.

Not convinced it would be worth the effort though. The build targets don't have much configuration, there aren't clear usecases for operating on unregistered target data, and the scope is never broad enough that the side-effects are a problem.
