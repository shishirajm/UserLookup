Download and Run
* Clone the repository: git clone git@github.com:shishirajm/UserLookup.git
* Navigate to UserLookup: cd UserLookup
* Run the Console Project: dotnet run -p ./src/UserLookup.Console

Decisions:
* Though Ids are repeated (which is usually not the case) in JSON, nothing is discarded. Search by Id returns the first one.
* Caching implementation is fundamental, and it caches the whole API response. Based on how things would grow, the caching can be tuned.
* For Console display haven't spent much time. It might feel basic.
