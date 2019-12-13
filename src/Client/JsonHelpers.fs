module JsonHelpers

open Fable.Core
open Shared
open Browser

[<Erase>]
type JsonResult<'a> =
    | Success of JsonSuccess<'a>
    | Failure of JsonError

// Server helper functions

let success data = Success { ok = true; data = data }
let failure msg = Failure { ok = false; message = msg }

// Client helper functions

let toResult (jsonResult : JsonResult<'a>) =
    match jsonResult with
    | Success { ok = true; data = data } -> Ok data
    | Success _ -> Error (sprintf "Invalid JsonResult: Success case should have ok = true. JsonResult was %A" jsonResult)
    | Failure { ok = false; message = msg } -> Error msg
    | Failure _ -> Error (sprintf "Invalid JsonResult: Success case should have ok = true. JsonResult was %A" jsonResult)

let unpackJsonResult currentModel jsonResult fn =
        console.log("Unpacking", jsonResult, "now...")
        match toResult jsonResult with
        | Ok newData ->
            fn newData
        | Error msg ->
            console.log("Error:", msg)
            currentModel, []
