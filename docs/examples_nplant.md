# Architectural Diagrams with NPlant

Code Examples adapted [nplant/Samples](https://github.com/nplant/nplant/tree/master/Samples), e.g.

```csharp
public record Foo(string SomeString, Bar TheBar, Baz TheBaz);
public record Bar(DateTime? SomeDate, BarTypes Type);
public record Baz(Foo TheFoo);
public enum RandomEnum { Member1 = 0, Member2 = 1, Member3 = 2 }
public enum BarTypes { HighBar = 0, LowBar = 1 }
```

## Enums

![SimpleEnumDiagram](img/Hello.NPlant.Diagrams/SimpleEnumDiagram.png)

## Inheritance

![SimpleInheritanceDiagram](img/Hello.NPlant.Diagrams/SimpleInheritanceDiagram.png)

## CircularReferences

![SimpleRecursiveDiagram](img/Hello.NPlant.Diagrams/SimpleRecursiveDiagram.png)

## Legends

![SimpleLegendDiagram](img/Hello.NPlant.Diagrams/SimpleLegendDiagram.png)

## Notes

![SimpleNotesDiagram](img/Hello.NPlant.Diagrams/SimpleNotesDiagram.png)

## Packages

![SimplePackageDiagram](img/Hello.NPlant.Diagrams/SimplePackageDiagram.png)

## Relationships

![BidirectionalAssociationDiagram](img/Hello.NPlant.Diagrams/BidirectionalAssociationDiagram.png)

## ScanMode

![SimpleScanModeDiagram](img/Hello.NPlant.Diagrams/SimpleScanModeDiagram.png)

## FullMonty

![FullMontyClassDiagram](img/Hello.NPlant.Diagrams/FullMontyClassDiagram.png)

## Titles

![SimpleTitledClassDiagram](img/Hello.NPlant.Diagrams/SimpleTitledClassDiagram.png)

```

```
