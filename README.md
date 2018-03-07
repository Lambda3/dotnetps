# DOTNETPS - .NET Execute

A tool that helps you check your dotnet processes, aka alias for `pgrep dotnet | xargs ps -p` on Unix or `Get-Process dotnet` on Windows.

.NET global tools are a new feature in .NET 2.1, which is currently in preview.

## Installing

Install .NET Core CLI at least 2.1 from [microsoft.com](https://www.microsoft.com/net/download/all).

Then run:

```bash
dotnet install tool -g dotnetps
```

## Running

Run `dotnetps` from the command line, for example:

```bash
dotnetps
```

## Testing install during development

Just cd to `src/dotnetps` and run `dotnet pack -C Release -o ../nupkg`.

Then cd to `dotnetps/nupkg` and run `dotnet install tool -g dotnetps`.

## Maintainers/Core team

* [Vinicius Quaiato](http://blog.lambda3.com.br/L3/vquaiato/), aka vquaiato, [Lambda3](http://www.lambda3.com.br), [@vquaiato](https://twitter.com/vquaiato)

Contributors can be found at the [contributors](https://github.com/lambda3/dotnetps/graphs/contributors) page on Github.

## Contact

Use Twitter.

## License

This software is open source, licensed under the Apache License, Version 2.0.
See [LICENSE.txt](https://github.com/lambda3/dnx/blob/master/LICENSE.txt) for details.
Check out the terms of the license before you contribute, fork, copy or do anything
with the code. If you decide to contribute you agree to grant copyright of all your contribution to this project, and agree to
mention clearly if do not agree to these terms. Your work will be licensed with the project at Apache V2, along the rest of the code.