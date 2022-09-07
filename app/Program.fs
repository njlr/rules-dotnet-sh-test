open System
open System.Threading
open System.Threading.Tasks
open Docker.DotNet
open Docker.DotNet.Models

[<EntryPoint>]
let main argv =
  let password =
    argv
    |> Array.tryHead
    |> Option.defaultValue ""

  if password = "abcdef" then
    printfn "Correct password"

    task {
      printfn "Starting Docker..."

      use client = (new DockerClientConfiguration()).CreateClient()

      printfn "Creating image..."

      let icps = ImagesCreateParameters()

      icps.FromImage <- "library/hello-world"

      do!
        client.Images.CreateImageAsync(
          icps,
          AuthConfig(),
          Progress<JSONMessage>())

      printfn "Creating container..."

      let ccps = CreateContainerParameters()

      ccps.Image <- "library/hello-world"

      let! ccr = client.Containers.CreateContainerAsync(ccps)

      printfn $"{ccr.ID}"

      printfn "Starting container..."

      let! wasStarted =
        client.Containers.StartContainerAsync(
          ccr.ID,
          ContainerStartParameters());

      printfn $"{wasStarted}"

      printfn "Stopping container..."

      let! wasStopped =
        client.Containers.StopContainerAsync(
          ccr.ID,
          ContainerStopParameters(),
          CancellationToken.None)

      printfn $"{wasStopped}"

      printfn "Done."
    }
    |> fun t -> t.Result

    0
  else
    printfn "Incorrect password"
    1
