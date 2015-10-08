# UI Sketches with [Salt](http://plantuml.com/salt.html)

Salt is a subproject included in [PlantUML](http://plantuml.com) that may help you to design graphical interface.
You can use either `@startsalt` keyword, or `@startuml` followed by a line with salt keyword.

## Basic widgets

A window must start and end with brackets. You can then define:

- Button using `[` and `]`.
- Radio button using `(` and `)`.
- Checkbox using `[` and `]`.
- User text area using `"`

    @startuml
    salt
    {
      Just plain text
      [This is my button]
      ()  Unchecked radio
      (X) Checked radio
      []  Unchecked box
      [X] Checked box
      "Enter text here   "
      ^This is a droplist^
    }
    @enduml

  ![Basic widget](img/examples_salt_ui.png)
  
The goal of this tool is to discuss about simple and sample windows.

## Using grid

A table is automatically created when you use an opening bracket `{`. 
And you have to use `|` to separate columns. 
For example:

    @startsalt
    {
      Login    | "MyName   "
      Password | "****     "
      [Cancel] | [  OK   ]
    }
    @endsalt

  ![Using grid](img/examples_salt_ui_001.png)
  
Just after the opening bracket, you can use a character to define if you want to draw lines or columns of the grid :

- `#`	To display all vertical and horizontal lines
- `!`	To display all vertical lines
- `-`	To display all horizontal lines
- `+`	To display external lines

    @startsalt
    {+
      Login    | "MyName   "
      Password | "****     "
      [Cancel] | [  OK   ]
    }
    @endsalt

  ![Using grid with border](img/examples_salt_ui_002.png)
  
## Using separator

You can use several horizontal lines as separator.

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

  ![Using separator](img/examples_salt_ui_003.png)
  
## Tree widget

To have a Tree, you have to start with `{T` and to use `+` to denote hierarchy.

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

  ![Tree widget](img/examples_salt_ui_004.png)
  
## Enclosing brackets

You can define subelements by opening a new opening bracket.

	@startsalt
	{
	Name         | "                 "
	Modifiers:   | { (X) public | () default | () private | () protected
	                [] abstract | [] final   | [] static }
	Superclass:  | { "java.lang.Object " | [Browse...] }
	}
	@endsalt
		
  ![Enclosing brackets](img/examples_salt_ui_005.png)
  
## Adding tabs

You can add tabs using `{/` notation. Note that you can use HTML code to have bold text.

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

  ![Adding tabs](img/examples_salt_ui_006.png)
  
Tab could also be vertically oriented:

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

  ![Adding tabs (vertical)](img/examples_salt_ui_007.png)
  
## Using menu

You can add a menu by using `{*` notation.

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

  ![Using menu](img/examples_salt_ui_008.png)
  
It is also possible to open a menu:

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

  ![Using menu (open)](img/examples_salt_ui_009.png)
  
## Advanced table

You can use two special notations for table :

- `*` to indicate that a cell with span with left
- `.` to denotate an empty cell

	@startsalt
	{#
	. | Column 2 | Column 3
	Row header 1 | value 1 | value 2
	Row header 2 | A long cell | *
	}
	@endsalt

  ![Advanced table](img/examples_salt_ui_010.png)
  
## OpenIconic

[OpenIconic]((https://useiconic.com/open/) is an very nice open source icon set. Those icons have been integrated into the creole parser, so you can use them out-of-the-box.
You can use the following syntax: `<&ICON_NAME>`.

	@startsalt
	{
	  Login<&person> | "MyName   "
	  Password<&key> | "****     "
	  [Cancel <&circle-x>] | [OK <&account-login>]
	}
	@endsalt

  ![Open Iconic](img/examples_salt_ui_011.png)
  
The complete list is available on [OpenIconic Website](https://useiconic.com/open/), or you can use the following special diagram:

	@startuml
	listopeniconic
	@enduml

  ![Open Iconic (complete)](img/examples_salt_ui_012.png)
  
