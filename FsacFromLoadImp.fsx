#load "fromLoadModule.fsx"
open FromLoadModule
open System.IO

type PathOfLoad =
    { 
      Path: string
      Column: int }

let findAndGoToLoad (path: string) (line: string) (column: int) =
    let result = FromLoadModule.tryParseLoad line column
    match result with
    | None -> None
    | Some path ->
        Some { Path = Path.GetFullPath(path); Column = column }

findAndGoToLoad "e:\\ur\\a.fsx" "#load \"FromLoadModule.fsx\"" 1
findAndGoToLoad "e:\\ur\\a.fsx" "B.add 1 1" 4

