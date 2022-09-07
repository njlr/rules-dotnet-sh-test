[<EntryPoint>]
let main argv =
  let password =
    argv
    |> Array.tryHead
    |> Option.defaultValue ""

  if password = "abcdef" then
    printfn "Correct password"
    0
  else
    printfn "Incorrect password"
    1
