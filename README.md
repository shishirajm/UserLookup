## How to run the app?
### Prerequisite
Use the Windows or Mac with dotnet core 5.0 installed: https://dotnet.microsoft.com/download

### Download and Run
* Clone the repository: `git clone git@github.com:shishirajm/UserLookup.git`
* Navigate to UserLookup: `cd UserLookup`
* Run the Console Project: `dotnet run -p ./src/UserLookup.Console`

## Decisions:
### Assumptions
* Current payload structure of repeated Id is valid.
* All Gender values are considered valid.

### Coding decisions
* Though Ids are repeated (which is usually not the case) in JSON, nothing is discarded. Search by Id returns the first one.
* Gender with M and F are considered Male and Female respectively. Gender without M or F not accounted for either Male or Female.
* Caching implementation is fundamental, and it caches the whole API response. Based on how things would grow, the caching can be tuned.
* For Console display haven't spent much time. It might feel basic.
* More validations can be added after the API records are read.
