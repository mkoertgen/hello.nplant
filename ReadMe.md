# Hello.NPlant

An example on how to use [NPlant](https://github.com/nplant/nplant) & [mkdocs](http://www.mkdocs.org/) for generating documentation & class diagrams in a CI-friendly way.

## Install 

You will need

  - [plantuml](http://plantuml.sourceforge.net/), install by 
      
	    choco install plantuml

  - [mkdocs](http://www.mkdocs.org/), install by 
  
        choco install python
		pip install mkdocs

## Build documentation

Build the documentation & diagrams using

   build.bat /t:Docs /v:m

The documentation is built into the `\site` subdirectory. You can view it

   mkdocs serve
   start http://localhost:8000
   
Note that changes in the markdown documentation files within `\docs` are automatically tracked by `mkdocs` rebuilding & refreshing the served documentation.
