# [5.3.0](https://www.nuget.org/packages/AutoMapper.Contrib.Autofac.DependencyInjection/5.3.0) (2021-03-01)

## Features

* Add support for `IValueConverter<,>`. Implements [issue #5](https://github.com/alsami/AutoMapper.Contrib.Autofac.DependencyInjection/issues/5).

# [5.2.0](https://www.nuget.org/packages/AutoMapper.Contrib.Autofac.DependencyInjection/5.2.0) (2021-01-01)

## Features

* Use different overload to register `AutoMapper` profiles so that profiles may contain dependencies. [(#4)](https://github.com/alsami/AutoMapper.Contrib.Autofac.DependencyInjection/issues/4)
* Upgrade `AutoMapper` to version `10.1.1`
* Update `Autofac` to version `6.1.0`

# [5.1.0](https://www.nuget.org/packages/AutoMapper.Contrib.Autofac.DependencyInjection/5.1.0) (2020-10-15)

## Fixes

* Fix obsolete-message for legacy-extensions: [7ec0b2e789ff6b7bb4ae9aa9cdba0e5e801e86a1](https://github.com/alsami/AutoMapper.Contrib.Autofac.DependencyInjection/commit/7ec0b2e789ff6b7bb4ae9aa9cdba0e5e801e86a1). Thanks to [benmccallum](https://github.com/benmccallum)!

## Features

* Upgrade `AutoMapper` to version 10.1.0

# [5.0.0](https://www.nuget.org/packages/AutoMapper.Contrib.Autofac.DependencyInjection/5.0.0) (2020-09-29)

## Breaking Changes

* `Autofac` has been updated to version `6.0.0`. This release contains many new features but also breaking-changes. Check out this [blog-post](https://alistairevans.co.uk/2020/09/28/autofac-6-0-released/) for more information.

## Deprecation notice

* `AddAutoMapper` has been marked as deprecated and will be removed with version `7.0.0`.

## Features

* New extensions were added that are more aligned with the `Autofac` syntax for registering dependencies. Please use `RegisterAutoMapper` instead of `AddAutoMapper`


# [4.0.0](https://www.nuget.org/packages/AutoMapper.Contrib.Autofac.DependencyInjection/4.0.0) (2020-07-15)

## Features

* Update `AutoMapper` to version `10.0.0`

# [3.2.0](https://www.nuget.org/packages/AutoMapper.Contrib.Autofac.DependencyInjection/3.2.0) (2020-06-11)

## Features

* Update `Autofac` to version `5.2.0`

# [3.1.0](https://www.nuget.org/packages/AutoMapper.Contrib.Autofac.DependencyInjection/3.1.0) (2020-02-22)

## Features

* Update `Autofac` to version `5.1.1`
* Expose `MapperConfiguration` as `IConfigurationProvider` as well

## Chore

* Optimize registration process and make sure that `AutoMapper` assemblies are excluded when scanning for types

# [3.0.0](https://www.nuget.org/packages/AutoMapper.Contrib.Autofac.DependencyInjection/3.0.0) (2020-01-29)

## Breaking changes

* `Autofac` has been updated to `5.0.0`. The release of `Autofac` contains breaking changes, mostly making the container immutable. You can read more about the changes [here](https://www.paraesthesia.com/archive/2020/01/27/autofac-5-released/).

# [2.0.1](https://www.nuget.org/packages/AutoMapper.Contrib.Autofac.DependencyInjection/2.0.1) (2019-12-26)

## Chore

* Update `Autofac` to version `4.9.4`

# [2.0.0](https://www.nuget.org/packages/AutoMapper.Contrib.Autofac.DependencyInjection/2.0.0) (2019-08-12)

## Breaking changes

* `AutoMapper` has completely removed all static-apis. If you still rely on any of them, please check out this [migration-guide](https://docs.automapper.org/en/stable/9.0-Upgrade-Guide.html).

## Chore

* Update `AutoMapper` to version `9.0.0`

# [1.0.1](https://www.nuget.org/packages/AutoMapper.Contrib.Autofac.DependencyInjection/1.0.0) (2019-06-13)

## Chore

* Update `AutoMapper` to version `8.1.1`

# [1.0.0](https://www.nuget.org/packages/AutoMapper.Contrib.Autofac.DependencyInjection/1.0.0) (2019-05-16)

## Intial Release

* Allow `AutoMapper` and it's components to be registered via an extension method for Autofac.

## Additional Note

This package is the same as the latest version from CleanCodeLabs.AutoMapper.Extensions.Autofac.DependencyInjection. It has been moved to this repository and will be continued to be mantained here.