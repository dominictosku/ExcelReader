# Blazor Excel File Upload and Processing
For managing and analysing your stock and cryptos in one place. Useful for filling out tax return.

This Blazor WebAssembly project allows to upload Excel files (.xlsx, .xls), parse them, and display their contents as objects within the application. The project uses EPPlus to read Excel files client-side and converts them into a list of custom class objects.

## Features

- File upload limited to Excel files (.xlsx and .xls).
- Parsing Excel files to read data into a custom `Stock` class.
- Displaying the parsed data in a user-friendly format.

## Supported Broker
- Swissquote
- Degiro
- Coinbase
- Crypto.com

## Prerequisites

- .NET 8.0 SDK or later
- A compatible web browser (Chrome, Firefox, Edge, etc.)
- Visual Studio 2022 or Visual Studio Code

## Getting Started

Follow these steps to get your project up and running:

1. **Clone the repository:**

```bash
git clone https://github.com/dominictosku/ExcelReader
cd ExcelReader
```

2. **Run the application:**

You can run the application using the following command:

```bash
dotnet run
````

Navigate to https://localhost:[Portnumber] in your web browser to see the application in action.

## Usage
Use the file input to select an Excel file to upload.
The file contents will be displayed on the page once the file is processed.

## License Notice for EPPlus

This project uses EPPlus (version 7.x), which operates under the Polyform Noncommercial License 1.0.0. This license allows the use, modification, and sharing of the software for noncommercial purposes. For any commercial use, you must either obtain a commercial license or use an alternative library that fits the commercial usage criteria.

For more details on the licensing terms and conditions, please visit EPPlus Licensing at https://www.epplussoftware.com/.
