# UI Sketches with Salt

[Salt](http://plantuml.com/salt.html) is a sub-project included in [PlantUML](http://plantuml.com) that may help you to design graphical interface.
You can use either `@startsalt` keyword, or `@startuml` followed by a line with salt keyword.

## Basic widgets

A window must start and end with brackets. You can then define:

- Button using `[` and `]`.
- Radio button using `(` and `)`.
- Checkbox using `[` and `]`.
- User text area using `"`

```plantuml
@startuml
salt
{
  Just plain text
  [This is my button]
  () Unchecked radio
  (X) Checked radio
  [] Unchecked box
  [X] Checked box
  "Enter text here "
  ^This is a droplist^
}
@enduml
```

![Basic widget](./img/examples_salt_ui-1.png)

The goal of this tool is to discuss about simple and sample windows.

## Using grid

A table is automatically created when you use an opening bracket `{`.
And you have to use `|` to separate columns.
For example:

```plantuml
@startsalt
{
	Login    | "MyName   "
	Password | "****     "
	[Cancel] | [  OK   ]
}
@endsalt
```

![Using grid](./img/examples_salt_ui-2.png)

Just after the opening bracket, you can use a character to define if you want to draw lines or columns of the grid :

- `#` To display all vertical and horizontal lines
- `!` To display all vertical lines
- `-` To display all horizontal lines
- `+` To display external lines

```plantuml
@startsalt
{+
  Login | "MyName "
  Password | "\*\*\*\* "
  [Cancel] | [ OK ]
  }
@endsalt
```

![Using grid with border](./img/examples_salt_ui-3.png)

## Using separator

You can use several horizontal lines as separator.

```plantuml
@startsalt
{
      Text1
      ..
      "Some field"
      ==
      Note on usage
      ~~
      Another text
      --
      [Ok]
    }
@endsalt
```

![Using separator](./img/examples_salt_ui-4.png)

## Tree widget

To have a Tree, you have to start with `{T` and to use `+` to denote hierarchy.

```plantuml
@startsalt
{
    {T
     + World
     ++ America
     +++ Canada
     +++ USA
     ++++ New York
     ++++ Boston
     +++ Mexico
     ++ Europe
     +++ Italy
     +++ Germany
     ++++ Berlin
     ++ Africa
    }
}
@endsalt
```

![Tree widget](./img/examples_salt_ui-5.png)

## Enclosing brackets

You can define sub-elements by opening a new opening bracket.

```plantuml
@startsalt
{
    Name         | "                 "
    Modifiers:   | { (X) public | () default | () private | () protected
                    [] abstract | [] final   | [] static }
    Superclass:  | { "java.lang.Object " | [Browse...] }
}
@endsalt
```

![Enclosing brackets](./img/examples_salt_ui-6.png)

## Adding tabs

You can add tabs using `{/` notation. Note that you can use HTML code to have bold text.

```plantuml
@startsalt
{+
    {/ <b>General | Fullscreen | Behavior | Saving }
    {
    	{ Open image in: | ^Smart Mode^ }
    	[X] Smooth images when zoomed
    	[X] Confirm image deletion
    	[ ] Show hidden images
    }
    [Close]
}
@endsalt
```

![Adding tabs](./img/examples_salt_ui-7.png)

Tab could also be vertically oriented:

```plantuml
@startsalt
{+
    {/ <b>General
    Fullscreen
    Behavior
    Saving } |
    {
    	{ Open image in: | ^Smart Mode^ }
    	[X] Smooth images when zoomed
    	[X] Confirm image deletion
    	[ ] Show hidden images
    	[Close]
    }
}
@endsalt
```

![Adding tabs (vertical)](./img/examples_salt_ui-8.png)

## Using menu

You can add a menu by using `{*` notation.

```plantuml
@startsalt
{+
    {* File | Edit | Source | Refactor }
    {/ General | Fullscreen | Behavior | Saving }
    {
    	{ Open image in: | ^Smart Mode^ }
    	[X] Smooth images when zoomed
    	[X] Confirm image deletion
    	[ ] Show hidden images
    }
    [Close]
}
@endsalt
```

![Using menu](./img/examples_salt_ui-9.png)

It is also possible to open a menu:

```plantuml
@startsalt
{+
    {* File | Edit | Source | Refactor
     Refactor | New | Open File | - | Close | Close All }
    {/ General | Fullscreen | Behavior | Saving }
    {
    	{ Open image in: | ^Smart Mode^ }
    	[X] Smooth images when zoomed
    	[X] Confirm image deletion
    	[ ] Show hidden images
    }
    [Close]
}
@endsalt
```

![Using menu (open)](./img/examples_salt_ui-10.png)

## Advanced table

You can use two special notations for tables:

- `*` for a cell with span with left
- `.` for an empty cell

```plantuml
@startsalt
{#
  . | Column 2 | Column 3
  Row header 1 | value 1 | value 2
  Row header 2 | A long cell | \*
}
@endsalt
```

![Advanced table](./img/examples_salt_ui-11.png)

## OpenIconic

[OpenIconic]((https://useiconic.com/open/) is an very nice open source icon set. Those icons have been integrated into the creole parser, so you can use them out-of-the-box.
You can use the following syntax: `<&ICON_NAME>`.

```plantuml
@startsalt
{
	Login<&person> | "MyName   "
	Password<&key> | "****     "
	[Cancel <&circle-x>] | [OK <&account-login>]
}
@endsalt
```

![Open Iconic](./img/examples_salt_ui-12.png)

The complete list is available on [OpenIconic Website](https://useiconic.com/open/), or you can use the following special diagram:

```plantuml
@startuml
listopeniconic
@enduml
```

![Open Iconic (complete)](./img/examples_salt_ui-13.png)
