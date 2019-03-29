open System.Text.RegularExpressions
open From_ionide

#load "b.fsx"
#load "from_ionide.fsx"

B.add 1 1

type PositionOfLoad =
    { Path: string
      Line: int
      Column: int }

// startPoint in ionide = the column

let findLoadPosition (path: string) (line: string) (lineNumber: int) (startPoint: int) =

    // first we nede to check if in the line there is a #load, if not we return None
    let result = FromLoad.tryParseLoad line startPoint
    match result with
    | None -> None
    | Some path ->
        // get the full path from `path` argument
        Some { Path = "E:\\ur\\b.fsx"; Line = 1; Column = 1 }

findLoadPosition "e:\\ur\\a.fsx" "#load \"b.fsx\"" 1 10

findLoadPosition "e:\\ur\\a.fsx" "B.add 1 1" 3 4


// a command like
(*
{
    "FileName": "e:\\ur\\a.fsx",
    "Line": 1,
    "Column": 10,
    "Filter": ""
}
*)
