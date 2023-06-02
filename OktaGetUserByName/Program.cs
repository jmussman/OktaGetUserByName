// OktaGetUserByName
// Copyright © 2023 Joel Mussman. All rights reserved.
//
// This project is distributed under the MIT license.
//
// This is a simple command-line example that uses the Okta SDK to locate and return a user by username or email
// address. The API token has been revoked before this was published, use your own okta org and token. Try it
// with a name that doesn't exist to handle failure.
//

using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;

const String oktaOrg = "https://pirates.potc.live";
const String apiToken = "00BSGy0JazqN7hbyez1amAGi0x7JdBqRA_DoyVVxQ1";

const String nameOne = "annebonny@potc.live";       // Existing login.
const String nameTwo = "annebonny";                 // Existing login shortname.
const String nameThree = "00u4y1pseqBf6KlWh5d7";    // Existing user ID.
const String nameFour = "nobody@potc.live";         // Non-existant user.

// Set up the agent pool (app instance) to connect to the organization,
// and then use it to instantiate the UserApi and search for the user.

Configuration config = new Configuration();

config.OktaDomain = oktaOrg;
config.Token = apiToken;

AgentPoolsApi apiInstance = new AgentPoolsApi(config);
UserApi userApi = new UserApi(config);
GroupApi groupApi = new GroupApi(config);

try {

    // Get the existing user by login.

    User user = await userApi.GetUserAsync(nameOne);

    Console.WriteLine(nameOne + ", login: " + user.Profile.Login + ", id: " + user.Id);

    // Get the existing user by login shortname.

    user = await userApi.GetUserAsync(nameTwo);

    Console.WriteLine(nameTwo + ", login: " + user.Profile.Login + ", id: " + user.Id);

    // Get the existing user by ID.

    user = await userApi.GetUserAsync(nameThree);

    Console.WriteLine(nameThree + ", login: " + user.Profile.Login + ", id: " + user.Id);

    // Just for kicks get the groups for the user to show using the SDK.

    List<Group> groups = await userApi.ListUserGroups(user.Id).ToListAsync();
    int count = 0;

    Console.Write("group membership: ");

    foreach (Group group in groups) {

        Console.Write(String.Format("{0}{1} ({2})", count > 0 ? ", " : "", group.Profile.Name, group.Id));
        ++count;
    }

    Console.WriteLine();

    // Get the non-existant user (fails).

    user = await userApi.GetUserAsync(nameFour);

    Console.WriteLine(nameFour + ", id: " + user.Id);
}

catch (ApiException e) {

    dynamic jToken = JToken.Parse(e.ErrorContent.ToString());

    Console.WriteLine("Get user failed with error code: " + jToken.errorCode + ", " + jToken.errorSummary);
}