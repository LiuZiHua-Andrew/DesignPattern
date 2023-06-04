# Mediator Design Pattern
Facilitates communication between components. 

The motivation of the Mediator pattern is components may go in and out of a system at any time
  - chat room participants
  - players in a MMORPG
So it makes no sense for them to have direct references to one another.
The solution here is to have all refer to some central component that facilitates communication.

## Mediator
> A component that facilitates communication between other components without them necessarily being aware of each other or having direct access to each other.