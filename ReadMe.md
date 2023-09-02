# About ValidInputs

ValidInputs is a custom class I made a few years back when I was taking a `C#` class in CEGEP. The original code was made by my teacher, Philippe Miquelon, and was made with `C#` (obviously). It was during that class that I made a "translation", if you can even call it that, of the `SaisiesConsoleValides.cs` that was given to us into a `Python` version called `ValidInputs`. 

This repository was mainly made for me to keep track of which versions of the code I have made. For now the following languages can work with various levels of completion:

**C# - (Fall 2021)**

The `C#` version will work only with integers and will allow you to answer `y/n` to a given question. Since this is the original code, it was also written with comments in French and printouts in French.

**Python - (Fall 2021)**

The `Python` version has been coded to work with both numeric types the language has to offer, `int` (integers) and `float` (decimals). I made this code a long time ago (2021) and I didn't comment it back then. If I have time, I will come back on it to add documentation. The `Python` version also offers the `y/n` question that was original made in the `C#` version.

**Java - (Fall 2023)**

The `Java` version is very naked. I have only made it possible for `int` to work. This is the only thing that is currently coded for the `Java` version. If more is needed, I will code the rest at a later time.

**C++ - (Fall 2023)**

The `C++` version is probably the most complete one, and considering it was the last one I made, it doesn't fully make sense. This is mainly due to one aspect of `C++` I know very little about: templates! Templates are a great tool that allows a class to have more than one version of itself depending on the initializing type you give it. Here is a quick example of how the `ValidInputs.h` works:

```cpp
#include "ValidInputs.h"

double double_value_test;
int int_value_test;

int main(){
   int_value_test = ValidInputs<int>().CMDInputAtLeast(5); // Will require you to enter an integer of at least 5.
   double_value_test = ValidInputs<double>().CMDInput(); // Will require you to enter a double.
}
```

As you can see, mentioning `ValidInputs<int>` will force `ValidInputs` into its integer form. Since this will work for any numeric type and was made using templates, it is very easy and convenient to code hence why you could consider this version to be the most complete one. Once again, no comments for now since this is just a first draft and more functions like the `y/n` question will come at a later date.
