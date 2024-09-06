# Consuming REST from C# 

This project demonstrates how to consume REST APIs from a C# application, using technologies like `HttpClient` and JSON serialization.

## Features
- REST API consumption using `HttpClient`
- Asynchronous API calls with `async` and `await`
- Error handling and response validation
- JSON deserialization using `System.Text.Json`

## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/UCN-LANY-Technology3/ConsumingRESTFromCSharp.git
   ```
2. Open the project in Visual Studio or your preferred C# IDE.
3. Restore NuGet packages by building the solution.
4. Run the project.

## Usage
The application sends GET/POST requests to a sample API, parses JSON responses, and displays the data.

### Example Usage:
```csharp
var client = new HttpClient();
var response = await client.GetAsync("https://api.example.com/data");

## Contribution
Contributions are welcome! Please feel free to fork this repository, make changes, and submit a pull request.

## License
MIT License. See the [LICENSE](LICENSE) file for details.
 
