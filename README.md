# CLSS.ExtensionMethods.IEnumerable.MinMaxBy

### Problem

[`MinBy`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.minby) & [`MaxBy`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.maxby) are new LINQ extension methods first introduced in .NET 6. Visit their reference documentation links to learn what they do. These methods have the following drawbacks:

- They are not available in .NET runtime environments earlier than .NET 6, which are most of the .NET runtime environments.
- They do not statically ensure that key types implement the [`IComparable`](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable) or [`IComparable<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1) interface. It is possible to pass in a selector of invalid type and get no compile-time error, but you will get a runtime exception.
- They don't check for null key selector.
- They don't check for empty source collection.

### Solution

This package backports `MinBy` and `MaxBy` for .NET versions before .NET 6 that are also compatible with .NET Standard 1.0. Learn more about compatible runtime environments [here](https://dotnet.microsoft.com/en-us/platform/dotnet-standard#versions). In the process, they also rectified the above drawbacks.

Statically-checked type:

```
using CLSS;

public struct CustomType
{
  // System.Uri does not implement IComparable or IComparable<T>
  public System.Uri Schema;
}

var collection = new CustomType[]
{
  new CustomType { Schema = new System.Uri("uri1") },
  new CustomType { Schema = new System.Uri("uri2") },
  new CustomType { Schema = new System.Uri("uri3") }
};
// Compilation error with CLSS version of MaxBy
var max = collection.MaxBy(e => e.Schema);
```

Null-checked key selector:

```
using CLSS;

var numbers = new int[] { 6, 3, 17 };
var max = numbers.MaxBy(null); // Throws ArgumentNullException
```

Empty-checked source collection:
```
using CLSS;

var timestampts = new System.DateTime[0];
var max = numbers.MaxBy(t => t.Year); // Throws InvalidOperationException
```

Although this package's `MinBy` and `MaxBy` statically ensure that the key selector returns an `IComparable` or `IComparable<T>`, passing in an optional custom `IComparer<T>` will loosen this requirement and allow key selectors that return any type. 

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).