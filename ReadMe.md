# Hello.NPlant

An example on *Continuous Documentation* - introducing a feedback loop for documentation as part of your build. This example shows how you can generate

- full blown documentation using [mkdocs](http://www.mkdocs.org/) 
- architectural documentation that lives with your code using [NPlant](https://github.com/nplant/nplant) & [plantuml](http://plantuml.com/)
- UI sketches & prototypes for use cases with [Salt](http://plantuml.com/salt.html) 

## Install 

You will need

  - [plantuml](http://plantuml.sourceforge.net/), install by 
	  
		choco install plantuml

  - [mkdocs](http://www.mkdocs.org/), install by 
  
		choco install python
		pip install mkdocs

## Build documentation

Build the documentation using

	build.bat /t:Docs /v:m

The documentation is built into the `\site` subdirectory. Best way to view is

	mkdocs serve

and browse to [http://localhost:8000](http://localhost:8000). Note that changes in the markdown documentation files within `\docs` are automatically tracked by `mkdocs` rebuilding & refreshing the served documentation.
