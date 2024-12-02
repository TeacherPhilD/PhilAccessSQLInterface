# PhilAccessSQLInterface
## An interface to manually run SQL queries on an Access Database.
---

### Version 1.1
This is a simple program that lets you run SQL queries on an Access Database.
It will then attempt to display the output in a pretty way. You can edit the spacing by changing RESULTS_COLUMN_WIDTH in Consts.cs.
In order for this to work you will need to download the [Microsoft Access Database Engine 2016 Redistributable](https://www.microsoft.com/en-us/download/details.aspx?id=54920).
This program automatically logs all queries and results, these text files are located wherever the executable is.

## Update Log
### Version 1.1
Validated SQL string: can't be empty.
Refactored some code for neatness.

### Version 1.0a
Refactored Custom Message Box to About Message Box. Improved internal documentation.