![](.common/joels-private-stock.png?raw=true)

# OktaGetUserByName (.NET)

This is an example of .NET code which uses the Okta SDK to retrieve a user by name.
The project is a simple console application.
It demonstrates a successful retrieval and handling the error on an unsuccessful retrieval.

## A Note on the SDK Documentation

The SDK documentation for [okta-sdk-dotnet](https://github.com/okta/okta-sdk-dotnet) is a little cryptic to find starting at the README.md.
The links to the Users, Grous APIs, etc. near the top go to the actual Okta API documentation, not the SDK.
The link to the actual SDK documentation is buried in the sentance right below that but easily missed because of the wording:
"Note: For more details about the APIs and models the SDK support, check out the [API docs](https://github.com/okta/okta-sdk-dotnet/blob/master/API_README.md)" (ignore the grammar too!).

And, when you follow that link all you will see a list of methods for each API, grouped by API.
Another, perhaps better, way to look at each API is to find each md files in [/docs](https://github.com/okta/okta-sdk-dotnet/tree/master/docs), e.g. [GroupsAPI.md](https://github.com/okta/okta-sdk-dotnet/blob/master/docs/GroupApi.md);
unfortunately these top-level MD files are not linked from any other MD file in the project, which is kind of interesting.
## License

The code is licensed under the MIT license. You may use and modify all or part of it as you choose, as long as attribution to the source is provided per the license. See the details in the [license file](./LICENSE.md) or at the [Open Source Initiative](https://opensource.org/licenses/MIT).

### Software Configuration

The library code targets .NET 6.0 and above.

Configure an Okta organization with an API token which has privileges to read user information.
Set the organization URL, API token, and two user names in the constants at the top of the program (one existing and one non-existant username).

<hr>
Copyright © 2023 Joel Mussman. All rights reserved.