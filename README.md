# C# Lambda Expressions, Delegates and Events
A lambda expression is a compact, inline function that you write without giving it a name. You can use the arrow operator `=>` to separate the parameter list from the body:
<pre>
  <code class="language-csharp">
x => x * 2
  </code>
</pre>

Reading left to right: `x` is the input parameter, `=>` means 'goes to', and `x * 2` is the body. It computes the value returned. When there are no parameters or more than one, wrap them in parentheses: `() => 42` or `(left, right) => left + right`.

## Delegates support lambda expressions
To use a lambda expression, the C# compiler needs to know two things: the types of the parameters and the return type. That description, the parameter types plus return type, is called a *delegate type*.

A delegate type is a type that represents a method signature. A variable of a delegate type can hold any matching method such as a lambda expression or a named method, as long as its parameter types and return type match.

## Built-in delegate types: `Func` and `Action`
Both families come in versions with zero to sixteen input type parameters, so they scale to any number of inputs. The key difference between the two families is:
- `System.Func<T,TResult>` (and `Func<T1, T2, TResult>`, and so on) represents a method that returns a value. The last type parameter is always the return type; all earlier ones are input types.
- `System.Action<T>` (and `Action<T1, T2>`, and so on) represents a method that returns nothing (`void`). All type parameters are input types. `System.Action` with no type parameters represents a method with no inputs and no return value.

## Keep lambda expressions self-contained
A lambda expression can reference variables from the surrounding code. Capturing means the lambda holds a reference to a variable declared outside its own body. The combination of the lambda and the variables it captures is called a closure.

When you don't need to capture anything, add the `static` modifier to the lambda. A static lambda can only use its own parameters and values declared inside its body. It can't capture local variables or instance state from the enclosing scope.

## Use discard parameters when inputs are irrelevant
Sometimes a delegate signature includes parameters you don't need. Use the discard `_` to signal that choice explicitly.

## Events provide optional notifications
An `event` is a mechanism that one object (the publisher) uses to notify other objects (the subscribers) when something happens. The publisher doesn't need to know who is listening or how many subscribers there are. Subscribers choose to opt in.

Events are built on delegates. An event is a delegate field with extra restrictions enforced by the `event` keyword: outside code can only subscribe (`+=`) or unsubscribe (`-=`) from the event; only the class that declares the event can invoke (raise) it.
