# numbers-to-words

Program that converts numbers to words

## How to run

The console app is built in .Net Core C#. To run it please download the Dotnet Core runtime from
<https://dotnet.microsoft.com/en-us/download>

After this, build the solution by cd into the solution folder and running:

```bash
dotnet build
```

After this you can navigate to the bin folder and run the command for example:

```bash
./bin/numbers-to-words.exe 3456, 23456, 678, 358906, 6553
```

This will give you the following output

```bash
three thousand, four hundred and fifty six
twenty three thousand, four hundred and fifty six
six hundred and seventy eight
Argument does not fall within expected range
six thousand, five hundred and fifty three
```

There are so many ways of attacking the problem and I was guilty of over thinking.