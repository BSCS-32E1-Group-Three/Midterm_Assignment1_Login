
In an Onion Architecture without a database, you can simulate persistence using an in-memory list. Here's how the architecture typically works:

Core Layer: This layer contains the core business logic and entities of your application. It should be independent of any specific technology or framework. In your case, you might have entities like User in the Core layer, representing the core domain model of your application.

Infrastructure Layer: This layer deals with the implementation details and external dependencies of your application, such as data access, services, and external APIs. In an Onion Architecture, this layer depends on the Core layer but should not have dependencies on higher-level layers. In your case, you can implement an in-memory IUserRepository interface in the Infrastructure layer that interacts with a list of users in memory.

Presentation Layer: This layer is responsible for handling user interactions, such as web interfaces or API endpoints. It depends on both the Core and Infrastructure layers but doesn't contain business logic or data access code. Controllers, view models, and views (for web applications) typically reside in this layer.

Here's a breakdown of how each layer works in your scenario:

Core Layer: Contains the User entity representing a user in your application. This layer defines interfaces like IUserRepository without specifying how data is actually retrieved or stored.

Infrastructure Layer: Implements the IUserRepository interface with an in-memory list of users (List<User> or similar). This implementation provides methods to interact with user data, such as GetUserByUsername, CreateUser, etc. However, it doesn't directly deal with database operations.

Presentation Layer: Contains controllers (like AccountController for handling user authentication) that use the IUserRepository interface to perform operations like user login, registration, etc. Views and view models are also part of this layer to handle the user interface and data presentation.
