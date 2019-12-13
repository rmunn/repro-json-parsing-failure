namespace Shared

type Counter = { Value : int }

type JsonSuccess<'a> = {
    ok : bool
    data : 'a
}

type JsonError = {
    ok : bool
    message : string
}

type Packages = {
    example : bool
    devDependencies : Map<string,string>
}
